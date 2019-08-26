using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.GitHub.Configs
{
    /// <summary>
    /// GitHub配置提供器
    /// </summary>
    public class GitHubConfigProvider : IGitHubConfigProvider
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly GitHubConfig _config;

        /// <summary>
        /// 初始化GitHub配置提供器
        /// </summary>
        /// <param name="config"></param>
        public GitHubConfigProvider(GitHubConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public Task<GitHubConfig> GetConfigAsync()
        {
            return Task.FromResult(_config);
        }
    }
}
