﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using Ding.Logs;
using Ding.Logs.Extensions;
using Microsoft.Extensions.Configuration;

namespace DCLGB
{
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序入口点
        /// </summary>
        /// <param name="args">入口点参数</param>
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                ex.Log(Log.GetLog().Caption("应用程序启动失败"));
            }
        }

        /// <summary>
        /// 创建Web主机生成器
        /// </summary>
        /// <param name="args">入口点参数</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseUrls(SiteSetting.Current.Url)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Configure the app here.

                })
                .UseStartup<Startup>();
        }
    }
}
