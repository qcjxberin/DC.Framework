using Ding.Domains.Repositories;
using Ding.Security.Identity.Models;

namespace Ding.Security.Identity.Repositories {
    /// <summary>
    /// 用户仓储
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    /// <typeparam name="TKey">用户标识类型</typeparam>
    public interface IUserRepository<TUser, in TKey> : IRepository<TUser, TKey> where TUser: User<TUser,TKey> {
    }
}