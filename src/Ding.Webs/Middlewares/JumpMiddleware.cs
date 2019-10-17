using Ding.Webs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;
using IMiddleware = Ding.AspNetCore.IMiddleware;

namespace Ding.Webs.Middlewares
{
    /// <summary>
    /// 将指定网址永久跳转到网址
    /// </summary>
    public class JumpMiddleware : IMiddleware
    {
        /// <summary>
        /// 下一个中间件
        /// </summary>
        private readonly RequestDelegate _next;

        public JumpMiddleware(RequestDelegate next)
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

            var list = cdb.findAll<JumpMap>();
            foreach (var row in list)
            {
                if (row.Url == url)
                {
                    response.Redirect(row.JumpTo, true);
                    return;
                }
            }

            await _next.Invoke(context);
        }

    }
}
