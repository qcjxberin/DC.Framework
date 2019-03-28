using Microsoft.EntityFrameworkCore;
using Ding.Datas.Tests.Commons.Datas.PgSql.Configs;
using Ding.Datas.UnitOfWorks;

namespace Ding.Datas.Tests.Ef.PgSql.UnitOfWorks {
    /// <summary>
    /// PgSql工作单元
    /// </summary>
    public class PgSqlUnitOfWork : Util.Datas.Ef.PgSql.UnitOfWork, IPgSqlUnitOfWork {
        /// <summary>
        /// 初始化PgSql工作单元
        /// </summary>
        public PgSqlUnitOfWork( IUnitOfWorkManager unitOfWorkManager) : base( new DbContextOptionsBuilder().UseNpgsql( AppConfig.Connection ).Options, unitOfWorkManager ) {
        }
    }
}