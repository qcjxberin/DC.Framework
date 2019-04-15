using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.QQ.Configs
{
    /// <summary>
    /// QQ配置提供器
    /// </summary>
    public class QQConfigProvider : IQQConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly QQConfig _config;

        /// <summary>
        /// 初始化QQ配置提供器
        /// </summary>
        /// <param name="config"></param>
        public QQConfigProvider(QQConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<QQConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
