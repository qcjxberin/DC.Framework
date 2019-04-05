using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using System;

namespace Ding.VueCliMiddle
{
    /// <summary>
    /// Extension methods for enabling Vue development server middleware support.
    /// </summary>
    public static class VueCliMiddlewareExtensions
    {
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
    }
}
