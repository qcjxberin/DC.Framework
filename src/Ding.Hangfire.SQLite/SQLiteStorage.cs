using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.Server;
using Hangfire.Storage;
using Microsoft.Data.Sqlite;

namespace Hangfire.SQLite
{
    public class SQLiteStorage : JobStorage
    {
        private readonly DbConnection _existingConnection;
        private readonly SQLiteStorageOptions _options;
        private readonly string _connectionString;
        private static readonly TimeSpan ReaderWriterLockTimeout = TimeSpan.FromSeconds(30);
        private static readonly Dictionary<string, ReaderWriterLockSlim> DbMonitorCache = new Dictionary<string, ReaderWriterLockSlim>();

        public SQLiteStorage(string nameOrConnectionString)
            : this(nameOrConnectionString, new SQLiteStorageOptions())
        {
        }

        /// <summary>
        /// Initializes SqlServerStorage from the provided SQLiteStorageOptions and either the provided connection
        /// string or the connection string with provided name pulled from the application config file.       
        /// </summary>
        /// <param name="nameOrConnectionString">Either a SQL Server connection string or the name of 
        /// a SQL Server connection string located in the connectionStrings node in the application config</param>
        /// <param name="options"></param>
        /// <exception cref="ArgumentNullException"><paramref name="nameOrConnectionString"/> argument is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> argument is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="nameOrConnectionString"/> argument is neither 
        /// a valid SQL Server connection string nor the name of a connection string in the application
        /// config file.</exception>
        public SQLiteStorage(string nameOrConnectionString, SQLiteStorageOptions options)
        {
            if (string.IsNullOrEmpty(nameOrConnectionString)) throw new ArgumentNullException(nameof(nameOrConnectionString));

            _connectionString = GetConnectionString(nameOrConnectionString);
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (!DbMonitorCache.ContainsKey(_connectionString))
            {
                DbMonitorCache.Add(_connectionString, new ReaderWriterLockSlim());
            }

            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLiteStorage"/> class with
        /// explicit instance of the <see cref="DbConnection"/> class that will be used
        /// to query the data.
        /// </summary>
        /// <param name="existingConnection">Existing connection</param>
        public SQLiteStorage([NotNull] DbConnection existingConnection)
            : this(existingConnection, new SQLiteStorageOptions())
        {
        }

        public SQLiteStorage([NotNull] DbConnection existingConnection, [NotNull] SQLiteStorageOptions options)
        {
            _existingConnection = existingConnection ?? throw new ArgumentNullException(nameof(existingConnection));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            Initialize();
        }

        public PersistentJobQueueProviderCollection QueueProviders { get; private set; }

        internal string SchemaName => _options.SchemaName;

        public override IMonitoringApi GetMonitoringApi()
        {
            return new SQLiteMonitoringApi(this, _options.DashboardJobListLimit);
        }

        public override IStorageConnection GetConnection()
        {
            return new SQLiteStorageConnection(this);
        }

        public override IEnumerable<IServerComponent> GetComponents()
        {
            yield return new ExpirationManager(this, _options.JobExpirationCheckInterval);
            //yield return new CountersAggregator(this, _options.CountersAggregateInterval);
        }

        //public override void WriteOptionsToLog(ILog logger)
        //{
        //    logger.Info("Using the following options for SQL Server job storage:");
        //    logger.InfoFormat("    Queue poll interval: {0}.", _options.QueuePollInterval);        
        //}

        public override string ToString()
        {
            const string canNotParseMessage = "<Connection string can not be parsed>";

            try
            {
                var parts = _connectionString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => new { Key = x[0].Trim(), Value = x[1].Trim() })
                    .ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);

                var builder = new StringBuilder();

                foreach (var alias in new[] { "Data Source", "Server", "Address" })
                {
                    if (parts.ContainsKey(alias))
                    {
                        builder.Append(parts[alias]);
                        break;
                    }
                }

                return builder.Length != 0
                    ? $"SQLite Server: {builder}"
                    : canNotParseMessage;
            }
            catch (Exception)
            {
                return canNotParseMessage;
            }
        }

        internal void UseConnection([InstantHandle] Action<DbConnection> action, bool isWriteLock = false)
        {
            UseConnection(connection =>
            {
                action(connection);
                return true;
            }, isWriteLock);
        }

        internal T UseConnection<T>([InstantHandle] Func<DbConnection, T> func, bool isWriteLock = false)
        {
            DbConnection connection = null;

            try
            {
                connection = CreateAndOpenConnection(isWriteLock);
                return func(connection);
            }
            finally
            {
                ReleaseConnection(connection);
            }
        }

        internal void UseTransaction([InstantHandle] Action<DbConnection, DbTransaction> action)
        {
            UseTransaction((connection, transaction) =>
            {
                action(connection, transaction);
                return true;
            }, null);
        }

        internal T UseTransaction<T>([InstantHandle] Func<DbConnection, DbTransaction, T> func, IsolationLevel? isolationLevel)
        {
            return UseConnection(connection =>
            {
                using (var transaction = connection.BeginTransaction(isolationLevel ?? _options.TransactionIsolationLevel ?? IsolationLevel.ReadCommitted))
                {
                    var result = func(connection, transaction);
                    transaction.Commit();

                    return result;
                }
            }, true);
        }

        internal DbConnection CreateAndOpenConnection(bool isWriteLock = false)
        {
            if (_existingConnection != null)
            {
                return _existingConnection;
            }

            if (isWriteLock)
            {
                DbMonitorCache[_connectionString].TryEnterWriteLock(ReaderWriterLockTimeout);
            }

            var connection = new SqliteConnection(_connectionString);
            connection.Open();

            return connection;
        }

        internal bool IsExistingConnection(IDbConnection connection)
        {
            return connection != null && ReferenceEquals(connection, _existingConnection);
        }

        internal void ReleaseConnection(IDbConnection connection)
        {
            if (connection != null && !IsExistingConnection(connection))
            {
                connection.Dispose();

                ReleaseDbWriteLock();
            }
        }

        internal void ReleaseDbWriteLock()
        {
            var dbMonitor = DbMonitorCache[_connectionString];
            if (dbMonitor.IsWriteLockHeld)
            {
                dbMonitor.ExitWriteLock();
            }
        }

        private void Initialize()
        {
            if (_options.PrepareSchemaIfNecessary)
            {
                UseConnection(connection =>
                {
                    SQLiteObjectsInstaller.Install(connection, _options.SchemaName);
                });
            }

            InitializeQueueProviders();
        }

        private void InitializeQueueProviders()
        {
            var defaultQueueProvider = new SQLiteJobQueueProvider(this, _options);
            QueueProviders = new PersistentJobQueueProviderCollection(defaultQueueProvider);
        }

        private string GetConnectionString(string nameOrConnectionString)
        {
            if (IsConnectionString(nameOrConnectionString))
            {
                return nameOrConnectionString;
            }

            if (IsConnectionStringInConfiguration(nameOrConnectionString))
            {
                return ConfigurationManager.ConnectionStrings[nameOrConnectionString].ConnectionString;
            }

            throw new ArgumentException(
                $"Could not find connection string with name '{nameOrConnectionString}' in application config file");
        }

        private bool IsConnectionString(string nameOrConnectionString)
        {
            return nameOrConnectionString.Contains(";");
        }

        private bool IsConnectionStringInConfiguration(string connectionStringName)
        {
            var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringName];

            return connectionStringSetting != null;
        }

    }
}
