using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.GitHub.Configs
{
    /// <summary>
    /// WeChat配置提供器
    /// </summary>
    public interface IGitHubConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<GitHubConfig> GetConfigAsync();
    }
}
