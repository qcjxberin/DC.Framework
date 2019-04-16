using Microsoft.AspNetCore.Builder;
using Ding.Webs.Middlewares;

namespace Ding.Webs.Extensions {
    /// <summary>
    /// 中间件扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册错误日志管道
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        public static IApplicationBuilder UseErrorLog( this IApplicationBuilder builder ) {
            return builder.UseMiddleware<ErrorLogMiddleware>();
        }

        /// <summary>
        /// 注册请求日志中间件
        /// </summary>
        /// <param name="builder">应用程序生成器</param>
        /// <returns></returns>
        public static IApplicationBuilder UseRequestLog(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}
