using Ding.Biz.OAuthLogin.Core;
using System.ComponentModel.DataAnnotations;

namespace Ding.Biz.OAuthLogin.QQ
{
    /// <summary>
    /// QQ授权用户请求
    /// </summary>
    public class QQAuthorizationUserRequest : AuthorizationUserParamBase
    {
        /// <summary>
        /// 用户OpenId
        /// </summary>
        [Required(ErrorMessage = "用户OpenId[OpenId]不能为空")]
        public string OpenId { get; set; }
    }
}
