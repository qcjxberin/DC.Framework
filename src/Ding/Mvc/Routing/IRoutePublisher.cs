using Microsoft.AspNetCore.Routing;

namespace Ding.Mvc.Routing
{
    /// <summary>
    /// 路由发布者
    /// </summary>
    public interface IRoutePublisher
    {
        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        void RegisterRoutes(IRouteBuilder routeBuilder);
    }
}
