using Ding.Biz.OAuthLogin.QQ.Configs;
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
        /// 微信配置
        /// </summary>
        public WeChatConfig WeChatOptions { get; set; } = new WeChatConfig();
    }
}
