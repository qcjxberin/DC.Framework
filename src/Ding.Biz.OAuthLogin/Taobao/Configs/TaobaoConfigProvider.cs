using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.Taobao.Configs
{
    /// <summary>
    /// QQ配置提供器
    /// </summary>
    public class TaobaoConfigProvider : ITaobaoConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TaobaoConfig _config;

        /// <summary>
        /// 初始化QQ配置提供器
        /// </summary>
        /// <param name="config"></param>
        public TaobaoConfigProvider(TaobaoConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<TaobaoConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
