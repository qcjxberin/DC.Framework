using Ding.Biz.OAuthLogin.GitHub.Configs;
using Ding.Biz.OAuthLogin.MicroSoft.Configs;
using Ding.Biz.OAuthLogin.QQ.Configs;
using Ding.Biz.OAuthLogin.Taobao.Configs;
using Ding.Biz.OAuthLogin.WeChat.Configs;

namespace Ding.Biz.OAuthLogin.Extensions
{
    /// <summary>
    /// 登录配置
    /// </summary>
    public class LoginOptions
    {
        /// <summary>
        /// QQ配置
        /// </summary>
        public QQConfig QqOptions { get; set; } = new QQConfig();

        /// <summary>
        /// WeChat配置
        /// </summary>
        public WeChatConfig WeChatOptions { get; set; } = new WeChatConfig();

        /// <summary>
        /// GitHub配置
        /// </summary>
        public GitHubConfig GitHubOptions { get; set; } = new GitHubConfig();

        /// <summary>
        /// MicroSoft配置
        /// </summary>
        public MicroSoftConfig MicroSoftConfig { get; set; } = new MicroSoftConfig();

        /// <summary>
        /// TaoBao配置
        /// </summary>
        public TaobaoConfig TaobaoConfig { get; set; } = new TaobaoConfig();
    }
}
