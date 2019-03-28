using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;

namespace Ding.Utils.Config
{
    /// <summary>
    /// 配置文件管理器
    /// </summary>
    public static class ConfigFileHelper
    {
        private static IConfiguration _config;

        /// <summary>
        /// 得到对象属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>(string name = null) where T : class, new()
        {
            try
            {
                //节点名称
                var sectionName = string.IsNullOrWhiteSpace(name) ? typeof(T).Name : name;
                if (typeof(T).IsGenericType)
                {
                    var genericArgTypes = typeof(T).GetGenericArguments();
                    sectionName = genericArgTypes[0].Name;
                }
                //判断配置文件是否有节点
                if (_config.GetChildren().FirstOrDefault(i => i.Key == sectionName) == null)
                    return null;

                //节点对象反序列化
                var spList = new ServiceCollection().AddOptions()
                                               .Configure<T>(options => _config.GetSection(sectionName))
                                               .BuildServiceProvider();
                return spList.GetService<IOptions<T>>().Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 得到简单类型的属性
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static string Get(string sectionName)
        {
            return _config.GetSection(sectionName).Value;
        }

        /// <summary>
        /// 设置配置项
        /// </summary>
        /// <param name="file"></param>
        /// <param name="env"></param>
        public static void Set(string file = "appsettings.json", IHostEnvironment env = null)
        {
            if (env != null)
            {
                _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile(file, true, true)
                         .AddJsonFile($"{file.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0]}.{env.EnvironmentName}.json", true)
                         .Build();
            }
            else
            {
                _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile(file, true, true)
                         .Build();
            }
        }
    }
}
