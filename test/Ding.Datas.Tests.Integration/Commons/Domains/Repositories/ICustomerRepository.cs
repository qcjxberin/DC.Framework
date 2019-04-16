using Ding.Datas.Tests.Commons.Domains.Models;
using Ding.Domains.Repositories;

namespace Ding.Datas.Tests.Commons.Domains.Repositories {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer,string> {
    }
}
