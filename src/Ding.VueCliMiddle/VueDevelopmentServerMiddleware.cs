using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ding.VueCliMiddle
{
    internal static class VueCliMiddleware
    {
        private const string LogCategoryName = "VueCliMiddleware";
        internal const string DefaultRegex = "running at";

        private static TimeSpan RegexMatchTimeout = TimeSpan.FromMinutes(5); // 这是仅开发时间的功能, 因此很长时间的超时是可以的

        public static void Attach(
            ISpaBuilder spaBuilder,
            string scriptName, int port = 0, ScriptRunnerType runner = ScriptRunnerType.Npm, string regex = DefaultRegex)
        {
            var sourcePath = spaBuilder.Options.SourcePath;
            if (string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(sourcePath));
            }

            if (string.IsNullOrEmpty(scriptName))
            {
                throw new ArgumentException("Cannot be null or empty", nameof(scriptName));
            }

            // 启动vue-cli并连接到中间件管道
            var appBuilder = spaBuilder.ApplicationBuilder;
            var logger = LoggerFinder.GetOrCreateLogger(appBuilder, LogCategoryName);
            var portTask = StartVueCliServerAsync(sourcePath, scriptName, logger, port, runner, regex);

            // 我们代理的所有内容都硬编码为目标http://localhost，因为：
            // - 请求总是来自本地机器（我们不接受远程
            //   直接转到vue-cli服务器的请求)
            // - 鉴于此，没有理由使用https，即使我们也不行
            //   想要，因为通常vue-cli服务器没有证书
            var targetUriTask = portTask.ContinueWith(
                task =>
                new UriBuilder("http", "localhost", task.Result).Uri);

            SpaProxyingExtensions.UseProxyToSpaDevelopmentServer(spaBuilder, () =>
            {
                // 在每个请求中，我们创建一个具有自己超时的单独启动任务。 就这样，即使
                // 第一个请求超时，后续请求仍然有效。
                var timeout = spaBuilder.Options.StartupTimeout;
                return targetUriTask.WithTimeout(timeout,
                    $"The vue-cli server did not start listening for requests " +
                    $"within the timeout period of {timeout.Seconds} seconds. " +
                    $"Check the log output for error information.");
            });
        }

        private static async Task<int> StartVueCliServerAsync(
            string sourcePath, string npmScriptName, ILogger logger, int portNumber, ScriptRunnerType runner, string regex)
        {
            if (portNumber < 80)
                portNumber = TcpPortFinder.FindAvailablePort();
            logger.LogInformation($"Starting server on port {portNumber}...");

            var envVars = new Dictionary<string, string>
            {
                { "PORT", portNumber.ToString() },
                { "DEV_SERVER_PORT", portNumber.ToString() }, // vue cli 3使用--port {number}，包含在下面
                { "BROWSER", "none" }, // 我们不希望vue-cli打开指向内部开发服务器端口的额外浏览器窗口
            };
            var npmScriptRunner = new ScriptRunner(sourcePath, npmScriptName, $"--port {portNumber:0}", envVars, runner: runner);
            npmScriptRunner.AttachToLogger(logger);

            using (var stdErrReader = new EventedStreamStringReader(npmScriptRunner.StdErr))
            {
                try
                {
                    // 虽然Vue dev服务器最终可能告诉我们它正在监听的URL，
                    // 在完成编译之前不会这样做，即使那时候也是如此
                    // 没有编译器警告。 因此，不要等待，尽快考虑好
                    // 当它开始侦听请求时
                    await npmScriptRunner.StdOut.WaitForMatch(new Regex(!string.IsNullOrWhiteSpace(regex) ? regex : DefaultRegex, RegexOptions.None, RegexMatchTimeout));
                }
                catch (EndOfStreamException ex)
                {
                    throw new InvalidOperationException(
                        $"The NPM script '{npmScriptName}' exited without indicating that the " +
                        $"server was listening for requests. The error output was: " +
                        $"{stdErrReader.ReadAsString()}", ex);
                }
            }

            return portNumber;
        }
    }
}
