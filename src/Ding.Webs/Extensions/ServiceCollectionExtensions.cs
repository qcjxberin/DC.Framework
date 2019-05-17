using Ding.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Ding.Webs.Extensions
{
    /// <summary>
    /// 表示IServiceCollection的扩展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册自定义路由
        /// </summary>
        /// <param name="services">服务的集合</param>
        public static void AddMvcRouting(this IServiceCollection services)
        {
            services.AddScoped<IRoutePublisher, RoutePublisher>();
        }
    }
}
