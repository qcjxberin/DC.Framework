using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Ding.VueCliMiddle
{
    internal static class LoggerFinder
    {
        public static ILogger GetOrCreateLogger(
            IApplicationBuilder appBuilder,
            string logCategoryName)
        {
            // 如果DI系统给我们一个记录器，请使用它。 否则，请设置默认值。
            var loggerFactory = appBuilder.ApplicationServices.GetService<ILoggerFactory>();
            var logger = loggerFactory != null
                ? loggerFactory.CreateLogger(logCategoryName)
                : new ConsoleLogger(logCategoryName, null, false);
            return logger;
        }
    }

    internal static class TaskTimeoutExtensions
    {
        public static async Task WithTimeout(this Task task, TimeSpan timeoutDelay, string message)
        {
            if (task == await Task.WhenAny(task, Task.Delay(timeoutDelay)))
            {
                task.Wait(); // 允许任何错误传播
            }
            else
            {
                throw new TimeoutException(message);
            }
        }

        public static async Task<T> WithTimeout<T>(this Task<T> task, TimeSpan timeoutDelay, string message)
        {
            if (task == await Task.WhenAny(task, Task.Delay(timeoutDelay)))
            {
                return task.Result;
            }
            else
            {
                throw new TimeoutException(message);
            }
        }
    }

    internal static class TcpPortFinder
    {
        public static int FindAvailablePort()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            try
            {
                return ((IPEndPoint)listener.LocalEndpoint).Port;
            }
            finally
            {
                listener.Stop();
            }
        }
    }

    /// <summary>
    /// 包含一个<see cref="StreamReader"/>来公开一个事件API，发出通知
    /// 当流发出部分行时, 完成的行, 或最终关闭。
    /// </summary>
    internal class EventedStreamReader
    {
        public delegate void OnReceivedChunkHandler(ArraySegment<char> chunk);
        public delegate void OnReceivedLineHandler(string line);
        public delegate void OnStreamClosedHandler();

        public event OnReceivedChunkHandler OnReceivedChunk;
        public event OnReceivedLineHandler OnReceivedLine;
        public event OnStreamClosedHandler OnStreamClosed;

        private readonly StreamReader _streamReader;
        private readonly StringBuilder _linesBuffer;

        public EventedStreamReader(StreamReader streamReader)
        {
            _streamReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
            _linesBuffer = new StringBuilder();
            Task.Factory.StartNew(Run);
        }

        public Task<Match> WaitForMatch(Regex regex)
        {
            var tcs = new TaskCompletionSource<Match>();
            var completionLock = new object();

            OnReceivedLineHandler onReceivedLineHandler = null;
            OnStreamClosedHandler onStreamClosedHandler = null;

            void ResolveIfStillPending(Action applyResolution)
            {
                lock (completionLock)
                {
                    if (!tcs.Task.IsCompleted)
                    {
                        OnReceivedLine -= onReceivedLineHandler;
                        OnStreamClosed -= onStreamClosedHandler;
                        applyResolution();
                    }
                }
            }

            onReceivedLineHandler = line =>
            {
                var match = regex.Match(line);
                if (match.Success)
                {
                    ResolveIfStillPending(() => tcs.SetResult(match));
                }
            };

            onStreamClosedHandler = () =>
            {
                ResolveIfStillPending(() => tcs.SetException(new EndOfStreamException()));
            };

            OnReceivedLine += onReceivedLineHandler;
            OnStreamClosed += onStreamClosedHandler;

            return tcs.Task;
        }

        private async Task Run()
        {
            var buf = new char[8 * 1024];
            while (true)
            {
                var chunkLength = await _streamReader.ReadAsync(buf, 0, buf.Length);
                if (chunkLength == 0)
                {
                    OnClosed();
                    break;
                }

                OnChunk(new ArraySegment<char>(buf, 0, chunkLength));
                int lineBreakPos;
                int startPos = 0;

                // 获取所有换行符
                while ((lineBreakPos = Array.IndexOf(buf, '\n', startPos, chunkLength - startPos)) >= 0 && startPos < chunkLength)
                {
                    var length = (lineBreakPos + 1) - startPos;
                    _linesBuffer.Append(buf, startPos, length);
                    OnCompleteLine(_linesBuffer.ToString());
                    _linesBuffer.Clear();
                    startPos = lineBreakPos + 1;
                }

                // 得到休息
                if (lineBreakPos < 0 && startPos < chunkLength)
                {
                    _linesBuffer.Append(buf, startPos, chunkLength - startPos);
                }
            }
        }

        private void OnChunk(ArraySegment<char> chunk)
        {
            var dlg = OnReceivedChunk;
            dlg?.Invoke(chunk);
        }

        private void OnCompleteLine(string line)
        {
            var dlg = OnReceivedLine;
            dlg?.Invoke(line);
        }

        private void OnClosed()
        {
            var dlg = OnStreamClosed;
            dlg?.Invoke();
        }
    }

    /// <summary>
    /// 从<see cref="EventedStreamReader"/>中捕获完成的行通知,
    /// 将数据合并为一个<see cref="string"/>.
    /// </summary>
    internal class EventedStreamStringReader : IDisposable
    {
        private readonly EventedStreamReader _eventedStreamReader;
        private bool _isDisposed;
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public EventedStreamStringReader(EventedStreamReader eventedStreamReader)
        {
            _eventedStreamReader = eventedStreamReader
                ?? throw new ArgumentNullException(nameof(eventedStreamReader));
            _eventedStreamReader.OnReceivedLine += OnReceivedLine;
        }

        public string ReadAsString() => _stringBuilder.ToString();

        private void OnReceivedLine(string line) => _stringBuilder.AppendLine(line);

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _eventedStreamReader.OnReceivedLine -= OnReceivedLine;
                _isDisposed = true;
            }
        }
    }
}
