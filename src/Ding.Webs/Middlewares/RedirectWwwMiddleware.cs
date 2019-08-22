using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;
using IMiddleware = Ding.AspNetCore.IMiddleware;

namespace Ding.Webs.Middlewares
{
    /// <summary>
    /// 将不带www的顶级域名转向带www的
    /// </summary>
    public class RedirectWwwMiddleware : IMiddleware
    {
        /// <summary>
        /// 下一个中间件
        /// </summary>
        private readonly RequestDelegate _next;

        public RedirectWwwMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 执行中间件拦截逻辑
        /// </summary>
        /// <param name="context">Http上下文</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                return;
            }

            var response = context.Response;
            var request = context.Request;
            var host = request.Host.Value;
            var url = request.GetDisplayUrl();

            if (!host.Contains("localhost") && host.Split('.').Length == 2)
            {
                response.Redirect(url.Replace(host, $"www.{host}"));
                return;
            }

            await _next.Invoke(context);
        }
    }
}
