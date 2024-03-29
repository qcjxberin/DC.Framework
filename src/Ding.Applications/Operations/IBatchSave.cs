﻿using System.Collections.Generic;
using Ding.Applications.Dtos;

namespace Ding.Applications.Operations {
    /// <summary>
    /// 批量保存操作
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TRequest">参数类型</typeparam>
    public interface IBatchSave<TDto, TRequest>
        where TDto : IResponse, new()
        where TRequest : IRequest, IKey, new() {
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        List<TDto> Save( List<TRequest> addList, List<TRequest> updateList, List<TRequest> deleteList );
    }
}