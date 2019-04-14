using System.Collections.Generic;
using Ding.Applications.Dtos;

namespace Ding.Applications.Operations {
    /// <summary>
    /// 获取全部数据
    /// </summary>
    public interface IGetAll<TDto> where TDto : IResponse, new() {
        /// <summary>
        /// 获取全部
        /// </summary>
        List<TDto> GetAll();
    }
}
