using Microsoft.Extensions.DependencyInjection;
using Ding.Webs.Razors;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Ding.Webs.Extensions {
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 注册Razor静态Html生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        public static IServiceCollection AddRazorHtml( this IServiceCollection services ) {
            services.AddScoped<IRouteAnalyzer, RouteAnalyzer>();
            services.AddScoped<IRazorHtmlGenerator, DefaultRazorHtmlGenerator>();
            return services;
        }

        public static IServiceCollection AddContextAccessor(this IServiceCollection self)
        {
            if (self.Count(x => x.ServiceType == typeof(IHttpContextAccessor)) == 0)
                self.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            if (self.Count(x => x.ServiceType == typeof(IActionContextAccessor)) == 0)
                self.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return self;
        }
    }
}
