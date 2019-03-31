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
    }
}
