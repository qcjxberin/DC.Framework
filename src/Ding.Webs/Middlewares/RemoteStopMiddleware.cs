using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Ding.Webs.Middlewares
{
    /// <summary>
    /// 远程关闭系统中间件
    /// 发起请求的Header头上加上Stop-Application:Yes
    /// </summary>
    public class RemoteStopMiddleware
    {
        /// <summary>
        /// 方法
        /// </summary>
        private RequestDelegate _next;

        /// <summary>
        /// 请求时Header中附带的参数名
        /// </summary>
        private const string RequestHeader = "Stop-Application";

        /// <summary>
        /// 响应时Header中附带的参数名
        /// </summary>
        private const string ResponseHeader = "Application-Stopped";

        /// <summary>
        /// 初始化错误日志中间件
        /// </summary>
        /// <param name="next">方法</param>
        public RemoteStopMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <param name="lifetime">应用程序生命周期</param>
        public async Task Invoke(HttpContext context, IApplicationLifetime lifetime)
        {
            if (context.Request.Method == "HEAD" && context.Request.Headers[RequestHeader].FirstOrDefault() == "Yes")
            {
                context.Response.Headers.Add(ResponseHeader, "Yes");
                lifetime.StopApplication();
            }
            else
            {
                await _next(context);
            }
        }

    }
}
