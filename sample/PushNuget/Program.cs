// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace PushNuget
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;

    internal class Program
    {
        private static readonly List<FileInfo> List = new List<FileInfo>(); // 待处理的文件

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
                "cmd".Run($"/k dotnet nuget push ../{item.Name} -k {Setting.Current.Key} -s {Setting.Current.Source}", 5000, WriteLog);

                List.Add(item);
            }

            Console.WriteLine($@"已上传文件数：{_count},总文件数：{_filescount}");

            if (_count == _filescount)
            {
                Console.WriteLine("5秒后即将关闭");
                Thread.Sleep(5_000);

                if (List.Count > 0)
                {
                    foreach (var row in List.ToArray())
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
            if (msg.Contains("error:") || msg.Contains("已推送包"))
            {
                _count++;
            }

            Console.WriteLine(msg);
        }
    }
}
