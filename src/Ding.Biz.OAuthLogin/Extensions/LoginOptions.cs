using Ding.Biz.OAuthLogin.QQ.Configs;

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
    }
}
