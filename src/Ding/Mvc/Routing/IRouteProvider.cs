using Microsoft.AspNetCore.Routing;

namespace Ding.Mvc.Routing
{
    /// <summary>
    /// 路由提供器
    /// </summary>
    public interface IRouteProvider
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        void RegisterRoutes(IRouteBuilder routeBuilder);

        /// <summary>
        /// 获取路由提供程序的优先级
        /// </summary>
        int Priority { get; }
    }
}
