// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace PushNuget
{
    using Ding.Log;
    using Ding.Threading;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Program
    {
        private static FileInfo[] Infos; //要上传的文件

        private static int _count = 0;  // 处理过的文件数量

        private static int _filescount; // 所有文件数量

        private static int jishi = 10;

        private static bool isjishi = false;

        /// <summary>
        /// 全局定时器
        /// </summary>
        public static TimerX GlobalTimer { get; private set; }

        private static void Main(string[] args)
        {
            XTrace.UseConsole();
            GlobalTimer = new TimerX(GlobalScheduledTasks, null, 1000, 1000);

            Console.Title = args.Length > 0 ? args[0] : @"上传到Nuget";

            var fileInfos = "../".AsDirectory().GetAllFiles("*.nupkg");  // 获取所有的nupkg文件
            Infos = fileInfos as FileInfo[] ?? fileInfos.ToArray();
            if (!Infos.Any())
            {
                Console.WriteLine(@"没有发现要上传的NuGet文件");
                isjishi = true;
                Close(false);
                return;
            }

            _filescount = Infos.Count();

            foreach (var item in Infos)
            {
                if (item.Name.Contains(".symbols.nupkg"))
                {
                    item.Delete();
                    _filescount--;
                    continue;
                }
            }

            Push();

            Console.ReadKey();
        }

        protected static void Push()
        {
            "cmd".Run($"/k dotnet nuget push ../{Infos[_count].Name} -k {Setting.Current.Key} -s {Setting.Current.Source}", 6000, WriteLog);
        }

        protected static void WriteLog(string msg)
        {
            if (msg.IndexOf("error: ") > -1 || msg.IndexOf("已推送包") > -1)
            {
                Interlocked.Increment(ref _count);

                XTrace.WriteLine(msg);
                if (_count != _filescount)
                {
                    Push();
                }
                else
                {
                    Console.WriteLine($@"已上传文件数：{_count},总文件数：{_filescount}");

                    if (_count == _filescount)
                    {
                        isjishi = true;
                        Close(true);
                    }
                    else
                    {
                        Console.WriteLine($@"上传的文件数和实际文件数不一致，请检查后重新执行工具。");
                    }
                }
                return;
            }
            XTrace.WriteLine(msg);
        }

        protected static void Close(bool existFile)
        {
            Console.WriteLine("10秒后即将关闭");
            Thread.Sleep(10_000);

            if (existFile)
            {
                foreach (var row in Infos)
                {
                    Console.WriteLine($@"删除 {row.Name}");
                    row.Delete();
                }
            }
            var process = Process.GetProcessesByName("PushNuget");
            foreach (var p in process)
            {
                if (!p.CloseMainWindow())
                {
                    p.Kill();
                }
            }
        }

        private static void GlobalScheduledTasks(object state)
        {
            if (isjishi)
            {
                XTrace.WriteLine(jishi.ToString());
                jishi--;
            }
        }
    }
}
