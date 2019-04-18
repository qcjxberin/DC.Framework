using Autofac;
using Ding.Datas.Dapper;
using Ding.Datas.Dapper.SqlServer;
using Ding.Datas.Sql;
using Ding.Datas.Sql.Matedatas;
using Ding.Datas.Sql.Queries;
using Ding.Datas.Tests.Commons.Domains.Repositories;
using Ding.Datas.Tests.Ef.SqlServer.Repositories;
using Ding.Datas.Tests.Ef.SqlServer.Stores;
using Ding.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Ding.Datas.Transactions;
using Ding.Datas.UnitOfWorks;
using Ding.Dependency;
using Ding.Sessions;

namespace Ding.Datas.Tests.Commons.Datas.SqlServer.Configs {
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            LoadInfrastructure( builder );
            LoadRepositories( builder );
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadInfrastructure( ContainerBuilder builder ) {
            builder.AddSingleton<ISession>( new Session( AppConfig.UserId ) );
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<ITransactionActionManager, TransactionActionManager>();
            builder.RegisterType<SqlServerUnitOfWork>().AsSelf().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<ISqlServerUnitOfWork>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<IDatabase>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.Register( t => t.Resolve<SqlServerUnitOfWork>() ).As<IEntityMatedata>().InstancePerLifetimeScope().PropertiesAutowired();
            builder.AddScoped<ISqlQuery, SqlQuery>();
            builder.AddScoped<ISqlBuilder, SqlServerBuilder>();
            builder.AddScoped<IProductPoStore, ProductPoStore>();
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.AddScoped<IOrderRepository, OrderRepository>();
            builder.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}