using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.WeChat.Configs
{
    /// <summary>
    /// WeChat配置提供器
    /// </summary>
    public class WeChatConfigProvider : IWeChatConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly WeChatConfig _config;

        /// <summary>
        /// 初始化WeChat配置提供器
        /// </summary>
        /// <param name="config"></param>
        public WeChatConfigProvider(WeChatConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<WeChatConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
