using Ding.Biz.OAuthLogin.Core;
using System.ComponentModel.DataAnnotations;

namespace Ding.Biz.OAuthLogin.Wechat
{
    /// <summary>
    /// 微信授权用户请求
    /// </summary>
    public class WechatAuthorizationUserRequest : AuthorizationUserParamBase
    {
        /// <summary>
        /// 用户OpenId
        /// </summary>
        [Required(ErrorMessage = "用户OpenId[OpenId]不能为空")]
        public string OpenId { get; set; }

        /// <summary>
        /// 国际地区语言版本。zh_CN:简体,zh_TW:繁体,en:英语
        /// </summary>
        public string Lang { get; set; } = "zh-CN";
    }
}
