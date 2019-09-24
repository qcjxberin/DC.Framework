using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ding.Dependency
{
    public static class ServiceCollectionExtenion
    {
        /// <summary>
        /// 批量注册服务
        /// </summary>
        /// <param name="services">DI服务</param>
        /// <param name="typeList">需要批量注册的类型集合</param>
        /// <param name="serviceLifetime">服务生命周期</param>
        /// <returns></returns>
        public static IServiceCollection BatchRegisterService(this IServiceCollection services, Type[] typeList, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            var typeDic = new Dictionary<Type, Type[]>(); //待注册集合
            foreach (var type in typeList)
            {
                var interfaces = type.GetInterfaces();   //获取接口
                typeDic.Add(type, interfaces);
            }
            if (typeDic.Keys.Count() > 0)
            {
                foreach (var instanceType in typeDic.Keys)
                {
                    foreach (var interfaceType in typeDic[instanceType])
                    {
                        //根据指定的生命周期进行注册
                        switch (serviceLifetime)
                        {
                            case ServiceLifetime.Scoped:
                                services.AddScoped(interfaceType, instanceType);
                                break;
                            case ServiceLifetime.Singleton:
                                services.AddSingleton(interfaceType, instanceType);
                                break;
                            case ServiceLifetime.Transient:
                                services.AddTransient(interfaceType, instanceType);
                                break;
                        }
                    }
                }
            }
            return services;
        }
    }
}
