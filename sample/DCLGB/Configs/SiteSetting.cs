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
    }

    /// <summary>
    /// 登录参数设置
    /// </summary>
    [DisplayName("登录参数设置")]
    public class Login
    {
        public QQ QQ { get; set; } = new QQ();
    }

    /// <summary>
    /// QQ登录参数设置
    /// </summary>
    [DisplayName("QQ登录参数设置")]
    public class QQ : ConfigBase
    {
    }
}
