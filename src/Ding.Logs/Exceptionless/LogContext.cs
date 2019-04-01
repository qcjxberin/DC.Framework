using System;
using Ding.Helpers;
using Ding.Logs.Internal;
using Ding.Utils.Helpers;

namespace Ding.Logs.Exceptionless {
    /// <summary>
    /// Exceptionless日志上下文
    /// </summary>
    public class LogContext : Ding.Logs.Core.LogContext {
        /// <summary>
        /// 创建日志上下文信息
        /// </summary>
        protected override LogContextInfo CreateInfo() {
            return new LogContextInfo {
                TraceId = Guid.NewGuid().ToString(),
                Stopwatch = GetStopwatch(),
                Url = Web.Url
            };
        }
    }
}
