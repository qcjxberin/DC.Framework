using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.Weibo.Configs
{
    /// <summary>
    /// QQ配置提供器
    /// </summary>
    public class WeiboConfigProvider : IWeiboConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly WeiboConfig _config;

        /// <summary>
        /// 初始化QQ配置提供器
        /// </summary>
        /// <param name="config"></param>
        public WeiboConfigProvider(WeiboConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<WeiboConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
