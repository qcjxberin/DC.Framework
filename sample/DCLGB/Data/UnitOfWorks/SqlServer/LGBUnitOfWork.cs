using Microsoft.EntityFrameworkCore;
using System;

namespace DCLGB.Data.SqlServer
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class LGBUnitOfWork : Ding.Datas.Ef.SqlServer.UnitOfWork, ILGBUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        public LGBUnitOfWork( DbContextOptions<LGBUnitOfWork> options, IServiceProvider serviceProvider ) 
            : base( options, serviceProvider ) {
        }
    }
}
