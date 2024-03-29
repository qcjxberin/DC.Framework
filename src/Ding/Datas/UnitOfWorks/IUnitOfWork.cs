﻿using System;
using System.Threading.Tasks;
using Ding.Aspects;

namespace Ding.Datas.UnitOfWorks {
    /// <summary>
    /// 工作单元
    /// </summary>
    [Ignore]
    public interface IUnitOfWork : IDisposable {
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        int Commit();
        /// <summary>
        /// 提交,返回影响的行数
        /// </summary>
        Task<int> CommitAsync();
    }
}
