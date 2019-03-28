﻿using System.Threading.Tasks;
using Ding.Applications.Aspects;
using Ding.Applications.Dtos;
using Ding.Validations.Aspects;

namespace Ding.Applications.Operations {
    /// <summary>
    /// 保存操作
    /// </summary>
    /// <typeparam name="TRequest">参数类型</typeparam>
    public interface ISaveAsync<in TRequest> where TRequest : IRequest, IKey, new() {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">参数</param>
        [UnitOfWork]
        Task SaveAsync( [Valid] TRequest request );
    }
}