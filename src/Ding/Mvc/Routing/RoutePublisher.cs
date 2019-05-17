using System;
using System.Linq;
using Ding.Reflections;
using Microsoft.AspNetCore.Routing;

namespace Ding.Mvc.Routing
{
    /// <summary>
    /// 路由发布者的实现
    /// </summary>
    public class RoutePublisher : IRoutePublisher
    {
        #region Fields

        /// <summary>
        /// 类型查找器
        /// </summary>
        protected readonly IFind _typeFinder;

        #endregion

        #region Ctor

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="typeFinder">类型查找器</param>
        public RoutePublisher(IFind typeFinder)
        {
            _typeFinder = typeFinder;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public virtual void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //查找其他程序集提供的路由提供程序
            var routeProviders = _typeFinder.Find<IRouteProvider>();

            //创建和排序路由提供程序的实例
            var instances = routeProviders
                .Select(routeProvider => (IRouteProvider)Activator.CreateInstance(routeProvider))
                .OrderByDescending(routeProvider => routeProvider.Priority);

            //注册所有提供的路线
            foreach (var routeProvider in instances)
                routeProvider.RegisterRoutes(routeBuilder);
        }

        #endregion
    }
}
