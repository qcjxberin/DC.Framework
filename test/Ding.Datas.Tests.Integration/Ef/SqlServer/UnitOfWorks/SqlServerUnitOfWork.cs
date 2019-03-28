using Microsoft.EntityFrameworkCore;
using Ding.Aspects;
using Ding.Datas.Tests.Commons.Datas.SqlServer.Configs;
using Ding.Datas.UnitOfWorks;

namespace Ding.Datas.Tests.Ef.SqlServer.UnitOfWorks {
    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    [Ignore]
    public class SqlServerUnitOfWork : Ding.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化SqlServer工作单元
        /// </summary>
        public SqlServerUnitOfWork(IUnitOfWorkManager unitOfWorkManager) : base( new DbContextOptionsBuilder().UseSqlServer( AppConfig.Connection ).Options, unitOfWorkManager ) {
        }
    }

    /// <summary>
    /// SqlServer工作单元
    /// </summary>
    public class SqlServerUnitOfWork2 : Ding.Datas.Ef.SqlServer.UnitOfWork, ISqlServerUnitOfWork {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="unitOfWorkManager">工作单元服务</param>
        public SqlServerUnitOfWork2( DbContextOptions options, IUnitOfWorkManager unitOfWorkManager ) : base( options, unitOfWorkManager ) {
        }
    }
}