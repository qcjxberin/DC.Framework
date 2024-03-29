﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Ding.Applications.Dtos;

namespace Ding.Applications.Operations {
    /// <summary>
    /// 获取全部数据
    /// </summary>
    public interface IGetAllAsync<TDto> where TDto : IResponse, new() {
        /// <summary>
        /// 获取全部
        /// </summary>
        Task<List<TDto>> GetAllAsync();
    }
}
