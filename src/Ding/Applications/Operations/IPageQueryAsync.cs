﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ding.Applications.Dtos;
using Ding.Datas.Queries;
using Ding.Domains.Repositories;

namespace Ding.Applications.Operations {
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IPageQueryAsync<TDto, in TQueryParameter>
        where TDto : IResponse, new()
        where TQueryParameter : IQueryParameter {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<List<TDto>> QueryAsync( TQueryParameter parameter );
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<PagerList<TDto>> PagerQueryAsync( TQueryParameter parameter );
    }
}