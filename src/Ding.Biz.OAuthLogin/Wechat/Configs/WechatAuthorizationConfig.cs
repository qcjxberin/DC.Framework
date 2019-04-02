using Ding.Biz.OAuthLogin.Core;
using System.ComponentModel.DataAnnotations;

namespace Ding.Biz.OAuthLogin.Wechat.Configs
{
    /// <summary>
    /// 微信授权配置
    /// </summary>
    public class WechatAuthorizationConfig : AuthorizationConfigBase
    {
        /// <summary>
        /// 刷新令牌地址
        /// </summary>
        [Required(ErrorMessage = "刷新令牌地址[RefreshTokenUrl]不能为空")]
        public string RefreshTokenUrl { get; set; }

        /// <summary>
        /// 初始化一个<see cref="WechatAuthorizationConfig"/>类型的实例
        /// </summary>
        public WechatAuthorizationConfig()
        {
            AuthorizationUrl = "https://open.weixin.qq.com/connect/qrconnect";
            AccessTokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token";
            RefreshTokenUrl = "https://api.weixin.qq.com/sns/oauth2/refresh_token";
        }
    }
}
