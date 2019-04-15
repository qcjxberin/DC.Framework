using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.MicroSoft.Configs
{
    /// <summary>
    /// MicroSoft配置提供器
    /// </summary>
    public class MicroSoftConfigProvider : IMicroSoftConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly MicroSoftConfig _config;

        /// <summary>
        /// 初始化MicroSoft配置提供器
        /// </summary>
        /// <param name="config"></param>
        public MicroSoftConfigProvider(MicroSoftConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<MicroSoftConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
