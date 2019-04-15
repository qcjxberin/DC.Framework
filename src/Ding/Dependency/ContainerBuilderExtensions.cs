using Autofac;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Ding.Dependency
{
    public static class ContainerBuilderExtensions
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

        /// <summary>
        /// EntityFramework AutoFac扩展方法
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="builder"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static ContainerBuilder AddDbContext<TContext>(this ContainerBuilder builder,
     Action<DbContextOptionsBuilder, IConfiguration> optionsAction = null) where TContext : DbContext
        {
            if (optionsAction != null)
            {
                builder.Register<DbContextOptions<TContext>>(p => DbContextOptionsFactory<TContext>(optionsBuilder =>
                {
                    IConfiguration config = p.Resolve<IConfiguration>();
                    optionsAction(optionsBuilder, config);
                }));
            }
            else
            {
                builder.Register<DbContextOptions<TContext>>(_ => DbContextOptionsFactory<TContext>(null));
            }

            builder.Register<DbContextOptions>(p => p.Resolve<DbContextOptions<TContext>>()).InstancePerLifetimeScope();
            builder.RegisterType<TContext>().As<DbContext>().InstancePerLifetimeScope();
            return builder;
        }

        private static DbContextOptions<TContext> DbContextOptionsFactory<TContext>(
            Action<DbContextOptionsBuilder> optionsAction)
            where TContext : DbContext
        {
            var options = new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>());
            if (optionsAction != null)
            {
                var builder = new DbContextOptionsBuilder<TContext>(options);
                optionsAction(builder);
                options = builder.Options;
            }

            return options;
        }

        /// <summary>
        /// SignalR AutoFac扩展类
        /// </summary>
        /// <returns></returns>
        public static ContainerBuilder AddSignalR(this ContainerBuilder builder)
        {
            builder.RegisterType<HubOptionsSetup>().As(typeof(IConfigureOptions<HubOptions>)).SingleInstance();
            builder.RegisterGeneric(typeof(DefaultHubLifetimeManager<>)).As(typeof(HubLifetimeManager<>)).SingleInstance();
            builder.RegisterType(typeof(DefaultHubProtocolResolver)).As(typeof(IHubProtocolResolver)).SingleInstance();
            builder.RegisterGeneric(typeof(HubConnectionHandler<>)).As(typeof(HubConnectionHandler<>)).SingleInstance();
            builder.RegisterType(typeof(DefaultUserIdProvider)).As(typeof(IUserIdProvider)).SingleInstance();
            builder.RegisterGeneric(typeof(DefaultHubDispatcher<>)).As(typeof(HubDispatcher<>)).SingleInstance();

            var assembly = System.Reflection.Assembly.Load("Microsoft.AspNetCore.SignalR.Core");
            builder.RegisterGeneric(assembly.GetType("Microsoft.AspNetCore.SignalR.Internal.HubContext`1", true)).As(typeof(IHubContext<>)).SingleInstance();
            builder.RegisterGeneric(assembly.GetType("Microsoft.AspNetCore.SignalR.Internal.HubContext`2", true)).As(typeof(IHubContext<,>)).SingleInstance();
            builder.RegisterType(assembly.GetType("Microsoft.AspNetCore.SignalR.Internal.SignalRCoreMarkerService", true)).SingleInstance();

            builder.Configure<HubOptions>(o =>
            {
                o.EnableDetailedErrors = true;
            });

            //builder.RegisterType(typeof(JsonHubProtocol)).As(typeof(IHubProtocol)).SingleInstance();
            builder.Configure<JsonHubProtocolOptions>();

            builder.RegisterGeneric(typeof(DefaultHubActivator<>)).As(typeof(IHubActivator<>)).InstancePerLifetimeScope();

            return builder;
        }
    }
}
