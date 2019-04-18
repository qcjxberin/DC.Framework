using System;
using Ding.Domains.Repositories;
using Ding.Domains.Trees;
using Ding.Security.Identity.Models;

namespace Ding.Tests.Samples {
    /// <summary>
    /// 角色
    /// </summary>
    public class Role : Role<Role,Guid,Guid?> {
        /// <summary>
        /// 初始化角色
        /// </summary>
        public Role()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化角色
        /// </summary>
        /// <param name="id">角色标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Role( Guid id, string path, int level )
            : base( id, path, level ) {
        }
    }

    /// <summary>
    /// 角色仓储
    /// </summary>
    public interface IRoleRepository : ITreeRepository<Role> {
    }
}