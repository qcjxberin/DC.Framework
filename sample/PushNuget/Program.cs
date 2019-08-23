// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace PushNuget
{
    using Ding.Log;
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
        private static readonly List<FileInfo> AllList = new List<FileInfo>(); // 待处理的文件

        private static readonly List<FileInfo> PushList = new List<FileInfo>(); // 已上传的文件

        private static int _count;  // 处理过的文件数量

        private static int _filescount; // 所有文件数量

        private static void Main(string[] args)
        {
            Console.Title = args.Length > 0 ? args[0] : @"上传到Nuget";

            var fileInfos = "../".AsDirectory().GetAllFiles("*.nupkg");  // 获取所有的nupkg文件
            var infos = fileInfos as FileInfo[] ?? fileInfos.ToArray();
            if (!infos.Any())
            {
                Console.WriteLine(@"没有发现要上传的NuGet文件");
            }

            _filescount = infos.Count();

            foreach (var item in infos.ToArray())
            {
                if (item.Name.Contains(".symbols.nupkg"))
                {
                    item.Delete();
                    _filescount--;
                    continue;
                }
                "cmd".Run($"/k dotnet nuget push ../{item.Name} -k {Setting.Current.Key} -s {Setting.Current.Source}", 3000, WriteLog);

                AllList.Add(item);
            }

            Console.WriteLine($@"已上传文件数：{_count},总文件数：{_filescount}");

            if (_count == _filescount)
            {
                Console.WriteLine("5秒后即将关闭");
                Thread.Sleep(5_000);

                if (AllList.Count > 0)
                {
                    foreach (var row in AllList.ToArray())
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
            else
            {
                Console.WriteLine($@"上传的文件数和实际文件数不一致，请检查后重新执行工具。");
            }
        }

        protected static void WriteLog(string msg)
        {
            XTrace.UseConsole();
            if (msg.IndexOf("正在将 ") > -1)
            {
                string result = msg.Substring(msg.IndexOf("正在将") + 3, msg.IndexOf("推送到") - 10);
                PushList.Add(("../" + result.Trim()).AsFile());
                _count++;
            }
            XTrace.WriteLine(msg);
        }
    }
}
