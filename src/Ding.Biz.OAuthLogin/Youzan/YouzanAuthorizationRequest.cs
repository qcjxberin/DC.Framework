using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Youzan
{
    /// <summary>
    /// 有赞授权请求
    /// </summary>
    public class YouzanAuthorizationRequest : AuthorizationParamBase
    {
        /// <summary>
        /// 申请的权限范围
        /// </summary>
        public string Scope { get; set; }
    }
}
