using Ding.Biz.OAuthLogin;
using Ding.Xml;
using System.ComponentModel;

namespace DCLGB
{
    /// <summary>
    /// 站点参数设置
    /// </summary>
    [DisplayName("站点参数设置")]
    [XmlConfigFile("Config/Site.config", 15000)]
    public class SiteSetting : XmlConfig<SiteSetting>
    {
        /// <summary>网站域名</summary>
        [Description("网站域名")]
        public string Url { get; set; } = "http://localhost:9191";

        /// <summary>
        /// 登录参数设置
        /// </summary>
        [Description("登录参数设置")]
        public Login Login { get; set; } = new Login();

        /// <summary>
        /// Jwt配置
        /// </summary>
        [Description("Jwt配置")]
        public Audience Audience { get; set; } = new Audience();
    }

    /// <summary>
    /// Jwt配置
    /// </summary>
    [DisplayName("Jwt配置")]
    public class Audience
    {
        /// <summary>
        /// 密钥
        /// </summary>
        [Description("密钥")]
        public string Secret { get; set; } = "sdfsdfsrty45634kkhllghtdgdfss345t678fs";

        /// <summary>
        /// 发行者
        /// </summary>
        [Description("发行者")]
        public string Issuer { get; set; } = "DCLGB";

        /// <summary>
        /// 订阅人
        /// </summary>
        [Description("订阅人")]
        public string Audiences { get; set; } = "wr";
    }

    /// <summary>
    /// 登录参数设置
    /// </summary>
    [DisplayName("登录参数设置")]
    public class Login
    {
        public QQ QQ { get; set; } = new QQ();

        public WeChat WeChat { get; set; } = new WeChat();

        public GitHub GitHub { get; set; } = new GitHub();
    }

    /// <summary>
    /// QQ登录参数设置
    /// </summary>
    [DisplayName("QQ登录参数设置")]
    public class QQ : ConfigBase
    {
    }

    /// <summary>
    /// 微信登录参数设置
    /// </summary>
    [DisplayName("微信登录参数设置")]
    public class WeChat : ConfigBase
    {
    }

    /// <summary>
    /// GitHub登录参数设置
    /// </summary>
    [DisplayName("GitHub登录参数设置")]
    public class GitHub: ConfigBase
    {
        public string ApplicationName { get; set; } = "";
    }
}
