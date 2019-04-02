using Ding.Biz.OAuthLogin.Core;
using System.ComponentModel.DataAnnotations;

namespace Ding.Biz.OAuthLogin.MeiliShuo.Configs
{
    /// <summary>
    /// 美丽说授权配置
    /// </summary>
    public class MeiliShuoAuthorizationConfig : AuthorizationConfigBase
    {
        /// <summary>
        /// 应用标识
        /// </summary>
        [Required(ErrorMessage = "应用标识[AppId]不能为空")]
        public string AppId { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        [Required(ErrorMessage = "应用密钥[AppKey]不能为空")]
        public string AppKey { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        [Required(ErrorMessage = "回调地址[CallbackUrl]不能为空")]
        public string CallbackUrl { get; set; }
    }
}
