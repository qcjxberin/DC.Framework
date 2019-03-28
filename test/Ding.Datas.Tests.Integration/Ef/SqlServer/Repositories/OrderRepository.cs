﻿using Ding.Datas.Ef.Core;
using Ding.Datas.Tests.Commons.Domains.Models;
using Ding.Datas.Tests.Commons.Domains.Repositories;
using Ding.Datas.Tests.Ef.SqlServer.UnitOfWorks;

namespace Ding.Datas.Tests.Ef.SqlServer.Repositories {
    /// <summary>
    /// 订单仓储
    /// </summary>
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository {
        /// <summary>
        /// 初始化订单仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public OrderRepository( ISqlServerUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
