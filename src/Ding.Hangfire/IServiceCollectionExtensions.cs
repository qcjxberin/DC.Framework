using Ding.Hangfire.Models;
using Hangfire;
using Hangfire.Annotations;
using Hangfire.MemoryStorage;
using Hangfire.SQLite;
using Microsoft.Extensions.DependencyInjection;
using System;
using Hangfire.RecurringJobExtensions;
using Ding.Extension;

namespace Ding.Hangfire
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddFivePowerHangfire(this IServiceCollection services)
        {
            return services.AddFivePowerHangfire(_ => { });
        }

        public static IServiceCollection AddFivePowerHangfire(this IServiceCollection services, [NotNull] DingHangfireOptions options)
        {
            return services.AddFivePowerHangfire(_ =>
            {
                _.Url = options.Url;
                _.AccessKey = options.AccessKey;
                _.BackToUrl = options.BackToUrl;
                _.HangfireDatabaseConnectionString = options.HangfireDatabaseConnectionString;
                _.IsDisableJobDashboard = options.IsDisableJobDashboard;
                _.Provider = options.Provider;
                _.StatsPollingInterval = options.StatsPollingInterval;
                _.UnAuthorizeMessage = options.UnAuthorizeMessage;
                _.ExtendOptions = options.ExtendOptions;
            });
        }

        public static IServiceCollection AddFivePowerHangfire(this IServiceCollection services, [NotNull] Action<DingHangfireOptions> configuration)
        {
            services.Configure(configuration);

            var options = configuration.GetValue();

            switch (options.Provider)
            {
                case HangfireProvider.Memory:
                    {
                        services.AddHangfire(config =>
                        {
                            config.UseMemoryStorage();
                            options.ExtendOptions?.Invoke(config, options);
                            #region Berin添加
                            //使用json配置文件自动构建RecurringJob。
                            if (!string.IsNullOrEmpty(options.JobJsonPath))
                            {
                                config.UseRecurringJob(options.JobJsonPath);
                            }
                            //使用RecurringJobAttribute自动构建RecurringJob。
                            if (options.JobTypes != null && options.JobTypes.Length > 0)
                            {
                                config.UseRecurringJob(options.JobTypes);
                            }
                            config.UseDefaultActivator();
                            #endregion
                        });
                        break;
                    }
                case HangfireProvider.SqlServer:
                    {
                        services.AddHangfire(config =>
                        {
                            config.UseSqlServerStorage(options.HangfireDatabaseConnectionString);
                            options.ExtendOptions?.Invoke(config, options);
                            #region Berin添加
                            //使用json配置文件自动构建RecurringJob。
                            if (!string.IsNullOrEmpty(options.JobJsonPath))
                            {
                                config.UseRecurringJob(options.JobJsonPath);
                            }
                            //使用RecurringJobAttribute自动构建RecurringJob。
                            if (options.JobTypes != null && options.JobTypes.Length > 0)
                            {
                                config.UseRecurringJob(options.JobTypes);
                            }
                            config.UseDefaultActivator();
                            #endregion
                        });
                        break;
                    }
                #region Berin添加
                case HangfireProvider.Sqlite:
                    {
                        services.AddHangfire(config =>
                        {
                            config.UseSQLiteStorage(options.HangfireDatabaseConnectionString);
                            options.ExtendOptions?.Invoke(config, options);
                            //使用json配置文件自动构建RecurringJob。
                            if (!string.IsNullOrEmpty(options.JobJsonPath))
                            {
                                config.UseRecurringJob(options.JobJsonPath);
                            }
                            //使用RecurringJobAttribute自动构建RecurringJob。
                            if (options.JobTypes != null && options.JobTypes.Length > 0)
                            {
                                config.UseRecurringJob(options.JobTypes);
                            }
                            config.UseDefaultActivator();
                        });
                        break;
                    }
                    #endregion
            }

            return services;
        }
    }
}
