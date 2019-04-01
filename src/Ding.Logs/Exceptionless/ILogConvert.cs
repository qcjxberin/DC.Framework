using Ding.Utils.Helpers;
using System.Collections.Generic;

namespace Ding.Logs.Exceptionless {
    /// <summary>
    /// 日志转换器
    /// </summary>
    public interface ILogConvert {
        /// <summary>
        /// 转换
        /// </summary>
        List<Item> To();
    }
}
