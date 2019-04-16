using Ding.Datas.Ef.Core;
using Ding.Datas.Tests.Commons.Domains.Models;
using Ding.Datas.Tests.Commons.Domains.Repositories;
using Ding.Datas.Tests.Ef.PgSql.UnitOfWorks;

namespace Ding.Datas.Tests.Ef.PgSql.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer,string>, ICustomerRepository {
        /// <summary>
        /// 初始化客户仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public CustomerRepository( IPgSqlUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}
