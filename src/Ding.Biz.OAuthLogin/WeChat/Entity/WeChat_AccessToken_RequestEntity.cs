using Ding.Biz.OAuthLogin.WeChat.Configs;
using Ding.Extension;
using Ding.Helpers;

namespace Ding.Biz.OAuthLogin
{
    /// <summary>
    /// Step2：通过Authorization Code获取Access Token
    /// </summary>
    public class WeChat_AccessToken_RequestEntity
    {
        /// <summary>
        /// 微信登录配置
        /// </summary>
        protected static readonly WeChatConfig WeChatConfig;

        /// <summary>
        /// 初始化一个<see cref="WeChat_AccessToken_RequestEntity"/>类型的实例
        /// </summary>
        static WeChat_AccessToken_RequestEntity()
        {
            var provider = Ioc.Create<IWeChatConfigProvider>();
            provider.CheckNotNull(nameof(provider));
            WeChatConfig = provider.GetConfigAsync().Result;
        }

        /// <summary>
        /// 填authorization_code
        /// </summary>
        [Required]
        public string grant_type { get; set; } = "authorization_code";

        /// <summary>
        /// 应用唯一标识，在微信开放平台提交应用审核通过后获得
        /// </summary>
        [Required]
        public string appid { get; set; } = WeChatConfig.APPID;

        /// <summary>
        /// 应用密钥AppSecret，在微信开放平台提交应用审核通过后获得
        /// </summary>
        [Required]
        public string secret { get; set; } = WeChatConfig.APPKey;

        /// <summary>
        /// 填写第一步获取的code参数
        /// </summary>
        [Required]
        public string code { get; set; }
    }
}
