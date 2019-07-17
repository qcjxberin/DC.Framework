using Ding.Biz.OAuthLogin.QQ.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Ding.Biz.OAuthLogin.WeChat.Configs;
using Ding.Biz.OAuthLogin.GitHub.Configs;
using Ding.Biz.OAuthLogin.Taobao.Configs;
using Ding.Biz.OAuthLogin.MicroSoft.Configs;
using Ding.Biz.OAuthLogin.Weibo.Configs;

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
        public static void AddLogin(this IServiceCollection services)
        {
            services.TryAddScoped<ILoginFactory, LoginFactory>();
        }
    }
}
