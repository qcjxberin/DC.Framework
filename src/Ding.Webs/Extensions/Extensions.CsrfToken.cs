using Ding.Helpers;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ding.Webs.Extensions
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions
    {

        /// <summary>
        /// 注册CSRF令牌服务
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddCsrfToken(this IServiceCollection services)
        {
            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
            return services;
        }

        /// <summary>
        /// 配置CSRF令牌
        /// </summary>
        /// <param name="app">应用程序生成器</param>
        public static IApplicationBuilder UseCsrfToken(this IApplicationBuilder app)
        {
            var antiforgery = Ioc.Create<IAntiforgery>();
            app.Use(next => context => {
                if (string.Equals(context.Request.Path.Value, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(context.Request.Path.Value, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    var tokens = antiforgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("CSRF-TOKEN", tokens.RequestToken, new CookieOptions() { HttpOnly = false });
                }
                return next(context);
            });
            return app;
        }

    }
}
