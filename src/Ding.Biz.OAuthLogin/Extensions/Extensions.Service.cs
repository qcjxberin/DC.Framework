using Ding.Biz.OAuthLogin.QQ.Configs;
using Ding.Biz.OAuthLogin.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Ding.Biz.OAuthLogin.Extensions
{
    /// <summary>
    /// 登录扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 注册登录操作
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">配置操作</param>
        public static void AddLogin(this IServiceCollection services, Action<LoginOptions> setupAction)
        {
            var options = new LoginOptions();
            setupAction?.Invoke(options);
            services.TryAddSingleton<IQQConfigProvider>(new QQConfigProvider(options.QqOptions));
            services.TryAddScoped<ILoginFactory, LoginFactory>();
        }
    }
}
