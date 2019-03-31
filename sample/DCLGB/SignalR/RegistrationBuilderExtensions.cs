using Autofac;
using Microsoft.Extensions.Options;
using System;

namespace DCLGB.SignalR
{
    public static class RegistrationBuilderExtensions
    {
        /// <summary>
        /// 注册用于配置特定类型选项的操作。
        /// </summary>
        /// <typeparam name="TOptions">要配置的选项类型。</typeparam>
        /// <param name="builder">将服务添加到<see cref="ContainerBuilder" /></param>
        /// <param name="configureOptions">用于配置选项的操作。</param>
        /// <returns>The <see cref="ContainerBuilder" />以便可以链接其他调用。</returns>
        public static ContainerBuilder Configure<TOptions>(this ContainerBuilder builder, Action<TOptions> configureOptions = null) where TOptions : class
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder
                .Register<IConfigureOptions<TOptions>>(ctx => new ConfigureOptions<TOptions>(configureOptions))
                .SingleInstance();

            return builder;
        }
    }
}
