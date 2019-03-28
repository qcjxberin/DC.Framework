using Autofac;
using Ding.Datas.Tests.Commons.Domains.Repositories;
using Ding.Datas.Tests.Ef.PgSql.Repositories;
using Ding.Datas.Tests.Ef.PgSql.UnitOfWorks;
using Ding.Datas.Transactions;
using Ding.Datas.UnitOfWorks;
using Ding.Dependency;
using Ding.Sessions;

namespace Ding.Datas.Tests.Commons.Datas.PgSql.Configs {
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
            builder.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            builder.AddScoped<ITransactionActionManager, TransactionActionManager>();
            builder.AddScoped<IPgSqlUnitOfWork, PgSqlUnitOfWork>().PropertiesAutowired();
            builder.AddSingleton<ISession>( new Ding.Datas.Tests.Commons.Session( AppConfig.UserId ) );
        }

        /// <summary>
        /// 加载仓储
        /// </summary>
        private void LoadRepositories( ContainerBuilder builder ) {
            builder.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}