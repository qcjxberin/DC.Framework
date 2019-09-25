using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using System;

#if __COREAPP30__
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
#endif

namespace Ding.VueCliMiddle
{
    /// <summary>
    /// Extension methods for enabling Vue development server middleware support.
    /// </summary>
    public static class VueCliMiddlewareExtensions
    {
#if __CORE20__
        /// <summary>
        /// 通过将请求传递给vue-cli服务器的实例来处理请求。
        /// 这意味着您可以随时提供最新的CLI构建资源
        /// 手动运行vue-cli服务器。
        ///
        /// 此功能仅应在开发中使用。 对于生产部署，请
        /// 确保不启用vue-cli服务器。
        /// </summary>
        /// <param name="spaBuilder"><see cref="ISpaBuilder"/>对象.</param>
        /// <param name="npmScript">package.json文件中启动vue-cli服务器的脚本名称。</param>
        /// <param name="port">指定vue cli服务器端口号。 如果＆lt; 80，使用随机端口。</param>
        /// <param name="runner">指定运行器，Npm和Yarn是有效选项。 纱线支撑是高度实验性的。</param>
        /// <param name="regex">指定要在日志中搜索的自定义正则表达式字符串，表示vue-cli服务已完成。</param>
        public static void UseVueCli(
            this ISpaBuilder spaBuilder,
            string npmScript,
            int port = 0,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            if (spaBuilder == null)
            {
                throw new ArgumentNullException(nameof(spaBuilder));
            }

            var spaOptions = spaBuilder.Options;

            if (string.IsNullOrEmpty(spaOptions.SourcePath))
            {
                throw new InvalidOperationException($"To use {nameof(UseVueCli)}, you must supply a non-empty value for the {nameof(SpaOptions.SourcePath)} property of {nameof(SpaOptions)} when calling {nameof(SpaApplicationBuilderExtensions.UseSpa)}.");
            }

            VueCliMiddleware.Attach(spaBuilder, npmScript, port, runner: runner, regex: regex);
        }
#elif __COREAPP30__
        /// <summary>
        /// Handles requests by passing them through to an instance of the vue-cli server.
        /// This means you can always serve up-to-date CLI-built resources without having
        /// to run the vue-cli server manually.
        ///
        /// This feature should only be used in development. For production deployments, be
        /// sure not to enable the vue-cli server.
        /// </summary>
        /// <param name="spaBuilder">The <see cref="ISpaBuilder"/>.</param>
        /// <param name="npmScript">The name of the script in your package.json file that launches the vue-cli server.</param>
        /// <param name="port">Specify vue cli server port number. If &lt; 80, uses random port. </param>
        /// <param name="runner">Specify the runner, Npm and Yarn are valid options. Yarn support is HIGHLY experimental.</param>
        /// <param name="regex">Specify a custom regex string to search for in the log indicating vue-cli serve is complete.</param>
        public static void UseVueCli(
            this ISpaBuilder spaBuilder,
            string npmScript,
            int port = 8080,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            if (spaBuilder == null)
            {
                throw new ArgumentNullException(nameof(spaBuilder));
            }

            var spaOptions = spaBuilder.Options;

            if (string.IsNullOrEmpty(spaOptions.SourcePath))
            {
                throw new InvalidOperationException($"To use {nameof(UseVueCli)}, you must supply a non-empty value for the {nameof(SpaOptions.SourcePath)} property of {nameof(SpaOptions)} when calling {nameof(SpaApplicationBuilderExtensions.UseSpa)}.");
            }

            VueCliMiddleware.Attach(spaBuilder, npmScript, port, runner: runner, regex: regex);
        }

        public static IEndpointConventionBuilder MapToVueCliProxy(
            this IEndpointRouteBuilder endpoints,
            string pattern,
            SpaOptions options,
            string npmScript,
            int port = 8080,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            if (pattern == null) { throw new ArgumentNullException(nameof(pattern)); }
            return endpoints.MapFallback(pattern, CreateProxyRequestDelegate(endpoints, options, npmScript, port, runner, regex));
        }

        public static IEndpointConventionBuilder MapToVueCliProxy(
            this IEndpointRouteBuilder endpoints,
            string pattern,
            string sourcePath,
            string npmScript,
            int port = 8080,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            if (pattern == null) { throw new ArgumentNullException(nameof(pattern)); }
            if (sourcePath == null) { throw new ArgumentNullException(nameof(sourcePath)); }
            return endpoints.MapFallback(pattern, CreateProxyRequestDelegate(endpoints, new SpaOptions { SourcePath = sourcePath }, npmScript, port, runner, regex));
        }

        public static IEndpointConventionBuilder MapToVueCliProxy(
            this IEndpointRouteBuilder endpoints,
            SpaOptions options,
            string npmScript,
            int port = 8080,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            return endpoints.MapFallback("{*path}", CreateProxyRequestDelegate(endpoints, options, npmScript, port, runner, regex));
        }

        public static IEndpointConventionBuilder MapToVueCliProxy(
            this IEndpointRouteBuilder endpoints,
            string sourcePath,
            string npmScript,
            int port = 8080,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            if (sourcePath == null) { throw new ArgumentNullException(nameof(sourcePath)); }
            return endpoints.MapFallback("{*path}", CreateProxyRequestDelegate(endpoints, new SpaOptions { SourcePath = sourcePath }, npmScript, port, runner, regex));
        }


        // based on CreateRequestDelegate() https://github.com/aspnet/AspNetCore/blob/master/src/Middleware/StaticFiles/src/StaticFilesEndpointRouteBuilderExtensions.cs#L194
        private static RequestDelegate CreateProxyRequestDelegate(
            IEndpointRouteBuilder endpoints,
            SpaOptions options,
            string npmScript,
            int port = 8080,
            ScriptRunnerType runner = ScriptRunnerType.Npm,
            string regex = VueCliMiddleware.DefaultRegex)
        {
            if (endpoints == null) { throw new ArgumentNullException(nameof(endpoints)); }
            if (options == null) { throw new ArgumentNullException(nameof(options)); }
            if (npmScript == null) { throw new ArgumentNullException(nameof(npmScript)); }

            var app = endpoints.CreateApplicationBuilder();
            app.Use(next => context =>
            {
                // Set endpoint to null so the SPA middleware will handle the request.
                context.SetEndpoint(null);
                return next(context);
            });

            app.UseSpa(opt =>
            {
                if (options != null)
                {
                    opt.Options.DefaultPage = options.DefaultPage;
                    opt.Options.DefaultPageStaticFileOptions = options.DefaultPageStaticFileOptions;
                    opt.Options.SourcePath = options.SourcePath;
                    opt.Options.StartupTimeout = options.StartupTimeout;
                }
                opt.UseVueCli(npmScript, port, runner, regex);
            });

            return app.Build();
        }
#endif
    }
}
