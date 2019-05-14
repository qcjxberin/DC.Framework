using Ding.Helpers;
using Ding.Mvc.Routing;
using Ding.Reflections;
using Microsoft.AspNetCore.Builder;
using Serilog;
using System;
using System.Linq;

namespace Ding.Webs.Extensions
{
    /// <summary>
    /// 表示IApplicationBuilder的扩展
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// 配置MVC路由
        /// </summary>
        /// <param name="application">用于配置应用程序请求管道的构建器</param>
        public static void UseDingMvc(this IApplicationBuilder application)
        {
            application.UseMvc(routeBuilder =>
            {
                //注册所有路由

                var finder = Ioc.Create<IFind>();
                //查找其他程序集提供的路由提供程序
                var routeProviders = finder.Find<IRouteProvider>();

                //创建和排序路由提供程序的实例
                var instances = routeProviders
                    .Select(routeProvider => (IRouteProvider)Activator.CreateInstance(routeProvider))
                    .OrderByDescending(routeProvider => routeProvider.Priority);

                //注册所有提供的路线
                foreach (var routeProvider in instances)
                    routeProvider.RegisterRoutes(routeBuilder);
            });
        }
    }
}
