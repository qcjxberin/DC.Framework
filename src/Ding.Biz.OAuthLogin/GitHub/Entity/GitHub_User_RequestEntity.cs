using Ding.Biz.OAuthLogin.GitHub.Configs;
using Ding.Extension;
using Ding.Helpers;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// user
    /// </summary>
    public class GitHub_User_RequestEntity
    {
        /// <summary>
        /// GitHub登录配置
        /// </summary>
        protected static readonly GitHubConfig GitHubConfig;

        /// <summary>
        /// 初始化一个<see cref="GitHub_User_RequestEntity"/>类型的实例
        /// </summary>
        static GitHub_User_RequestEntity()
        {
            var provider = Ioc.Create<IGitHubConfigProvider>();
            provider.CheckNotNull(nameof(provider));
            GitHubConfig = provider.GetConfigAsync().Result;
        }

        /// <summary>
        /// access_token
        /// </summary>
        [Required]
        public string access_token { get; set; }

        /// <summary>
        /// github 申请的应用名称
        /// </summary>
        [Required]
        public string ApplicationName { get; set; } = GitHubConfig.ApplicationName;
    }
}
