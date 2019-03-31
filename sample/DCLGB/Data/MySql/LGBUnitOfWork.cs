using Ding.Datas.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace DCLGB.Data.MySql
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class LGBUnitOfWork : Ding.Datas.Ef.MySql.UnitOfWork, ILGBUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="unitOfWorkManager">工作单元服务</param>
        public LGBUnitOfWork(DbContextOptions options, IUnitOfWorkManager unitOfWorkManager) : base(options, unitOfWorkManager)
        {
        }
    }
}
