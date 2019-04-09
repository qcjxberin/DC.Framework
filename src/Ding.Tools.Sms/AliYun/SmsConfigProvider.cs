using System.Threading.Tasks;

namespace Ding.Sms.AliYun
{
    /// <summary>
    /// 阿里云配置提供器
    /// </summary>
    public class SmsConfigProvider : ISmsConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly SmsConfig _config;

        /// <summary>
        /// 初始化阿里云配置提供器
        /// </summary>
        /// <param name="config"></param>
        public SmsConfigProvider(SmsConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<SmsConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
