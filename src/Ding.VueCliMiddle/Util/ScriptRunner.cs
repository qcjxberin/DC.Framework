using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Ding.VueCliMiddle
{
    /// <summary>
    /// 执行在<c>package.json</c>文件中定义<c>script</c>的条目,
    /// 捕获写入stdio的任何输出。
    /// </summary>
    internal class ScriptRunner
    {
        public EventedStreamReader StdOut { get; }
        public EventedStreamReader StdErr { get; }

        public ScriptRunnerType Runner { get; }

        private string GetExeName() => Runner == ScriptRunnerType.Npm ? "npm" : "yarn";
        private string GetArgPrefix() => Runner == ScriptRunnerType.Npm ? "run " : "";
        private string GetArgSuffix() => Runner == ScriptRunnerType.Npm ? "-- " : "";

        private static Regex AnsiColorRegex = new Regex("\x001b\\[[0-9;]*m", RegexOptions.None, TimeSpan.FromSeconds(1));

        public ScriptRunner(string workingDirectory, string scriptName, string arguments, IDictionary<string, string> envVars, ScriptRunnerType runner)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                throw new ArgumentException("Cannot be null or empty.", nameof(workingDirectory));
            }

            if (string.IsNullOrEmpty(scriptName))
            {
                throw new ArgumentException("Cannot be null or empty.", nameof(scriptName));
            }

            Runner = runner;

            var npmExe = GetExeName();
            var completeArguments = $"{GetArgPrefix()}{scriptName} {GetArgSuffix()}{arguments ?? string.Empty}";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // 在 Windows 上, NPM 可执行文件是一个. cmd 文件, 因此无法执行
                // 直接 (除了与 Usseshelrex否 = true, 但这是没有好处的, 因为
                // 它可以防止捕获 stdio)。因此, 我们需要通过 "cmd/c" 调用它。
                npmExe = "cmd";
                completeArguments = $"/c npm {completeArguments}";
            }

            var processStartInfo = new ProcessStartInfo(npmExe)
            {
                Arguments = completeArguments,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = workingDirectory
            };

            if (envVars != null)
            {
                foreach (var keyValuePair in envVars)
                {
                    processStartInfo.Environment[keyValuePair.Key] = keyValuePair.Value;
                }
            }

            var process = LaunchNodeProcess(processStartInfo);
            StdOut = new EventedStreamReader(process.StandardOutput);
            StdErr = new EventedStreamReader(process.StandardError);
        }

        public void AttachToLogger(ILogger logger)
        {
            // 当NPM任务发出完整的行时，将它们传递给真正的记录器
            StdOut.OnReceivedLine += line =>
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    // NPM任务通常会发出ANSI颜色，但转发没有意义
                    // 那些记录器（因为记录器不一定是任何类型的终端）
                    logger.LogInformation(StripAnsiColors(line) + "\r\n");
                }
            };

            StdErr.OnReceivedLine += line =>
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    logger.LogError(StripAnsiColors(line + "\r\n"));
                }
            };

            // 但是当它发出不完整的行时，假设这是进度信息，因此无论记录器配置如何，只需将其传递给StdOut。
            StdErr.OnReceivedChunk += chunk =>
            {
                var containsNewline = Array.IndexOf(chunk.Array, '\n', chunk.Offset, chunk.Count) >= 0;

                if (!containsNewline)
                {
                    Console.Write(chunk.Array, chunk.Offset, chunk.Count);
                }
            };
        }

        private static string StripAnsiColors(string line)
            => AnsiColorRegex.Replace(line, string.Empty);

        private static Process LaunchNodeProcess(ProcessStartInfo startInfo)
        {
            try
            {
                var process = Process.Start(startInfo);

                // 有关原因，请参阅OutOfProcessNodeInstance.cs中的等效注释
                process.EnableRaisingEvents = true;

                return process;
            }
            catch (Exception ex)
            {
                var message = $"Failed to start '{startInfo.FileName}'. To resolve this:.\n\n"
                            + $"[1] Ensure that '{startInfo.FileName}' is installed and can be found in one of the PATH directories.\n"
                            + $"    Current PATH enviroment variable is: { Environment.GetEnvironmentVariable("PATH") }\n"
                            + "    Make sure the executable is in one of those directories, or update your PATH.\n\n"
                            + "[2] See the InnerException for further details of the cause.";
                throw new InvalidOperationException(message, ex);
            }
        }
    }
}
