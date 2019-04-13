// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Ding.DDNS
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
#if __CORE__
    using Microsoft.Extensions.DependencyInjection;
#endif

    /// <summary>
    /// DDNS动态解析类
    /// 支持Oary、Dynu、NoIp
    /// </summary>
    public class DDNSClient
    {
        private readonly string baseAddress;
        private readonly string apiUri;
        private readonly string hostName;
        private readonly string userName;
        private readonly string password;

        // [DefaultValue("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0")]
        public string Agent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hostName">用户域名</param>
        /// <param name="userName">用户帐号</param>
        /// <param name="password">密码</param>
        /// <param name="baseAddress">服务器域名</param>
        /// <param name="apiUri">api接口地址</param>
        public DDNSClient(string hostName, string userName, string password, string baseAddress = "http://ddns.oray.com", string apiUri = "/ph/update")
        {
            this.baseAddress = baseAddress;
            this.apiUri = apiUri;
            this.userName = userName;
            this.password = password;
            this.hostName = hostName;
        }

        /// <summary>
        /// Get HttpClient
        /// </summary>
        /// <returns></returns>
        private HttpClient GetHttpClient()
        {
#if __CORE__
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient();
            var services = serviceCollection.BuildServiceProvider();
            var clientFactory = services.GetService<IHttpClientFactory>();

            return clientFactory.CreateClient();
#else
            return new HttpClient();
#endif
        }

        /// <summary>
        /// 获取公网IpV4地址
        /// 使用http://ddns.oray.com/checkip提供的服务
        /// </summary>
        /// <returns></returns>
        public virtual string GetInterNetIp()
        {
            var ipV4Str = "127.0.0.1";
            try
            {
                string url = "http://ddns.oray.com";
                HttpClient client = GetHttpClient();
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync("/checkip");
                if (response.Result.IsSuccessStatusCode)
                {
                    var html = response.Result.Content.ReadAsStringAsync().Result;
                    // <html><head><title>Current IP Check</title></head><body>Current IP Address: 221.234.238.64</body></html>
                    if (html.Length == 0)
                    {
                        return ipV4Str;
                    }

                    var patten = @"\d+.\d+.\d+.\d+";
                    var ret = Regex.Match(html, patten, RegexOptions.IgnoreCase);
                    return ret.Value;
                }

                return ipV4Str;
            }
            catch (Exception)
            {
                return ipV4Str;
            }
        }

        /// <summary>
        /// 解析域名IpV4地址
        /// 失败时会返回0.0.0.0
        /// </summary>
        public string GetHostNameIp()
        {
            var ipV4Str = "0.0.0.0";
            try
            {
                IPHostEntry host = Dns.GetHostEntry(hostName);
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        return ip.ToString();
                    }
                }

                return ipV4Str;
            }
            catch (Exception)
            {
                return ipV4Str;
            }
        }

        /// <summary>
        /// 检测域名与当前公网IP是否一致
        /// </summary>
        /// <returns>true:IpAddress发生变化，需要更新</returns>
        public bool IsIpAddressChanged()
        {
            var interNetIp = GetInterNetIp();
            var hostIp = GetHostNameIp();

            return !(interNetIp == hostIp);
        }

        /// <summary>
        /// 更新DDns
        /// </summary>
        /// <returns>更新结果</returns>
        public string UpdateDDns()
        {
            string ret;
            try
            {
                var client = GetHttpClient();
                client.BaseAddress = new Uri(baseAddress);
                byte[] bytes = Encoding.Default.GetBytes($"{userName}:{password}");
                var base64 = Convert.ToBase64String(bytes);
                var authValue = $"Basic {base64}";
                client.DefaultRequestHeaders.Add("Authorization", authValue);
                client.DefaultRequestHeaders.Add("User-Agent", Agent);
                var response = client.GetAsync($"{apiUri}?hostname={hostName}");
                if (response.Result.IsSuccessStatusCode)
                {
                    // ret = response.Result.ToString();
                    ret = response.Result.Content.ReadAsStringAsync().Result; // good 221.234.238.64
                }
                else
                {
                    ret = "service unavailable";
                }

                return ret;
            }
            catch (Exception ex)
            {
                ret = ex.Message;
                return ret;
            }
        }
    }
}
