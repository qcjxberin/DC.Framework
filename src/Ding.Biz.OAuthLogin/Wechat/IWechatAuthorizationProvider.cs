using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Wechat
{
    /// <summary>
    /// 微信授权提供程序
    /// </summary>
    public interface IWechatAuthorizationProvider : IAuthorizationUrlProvider<WechatAuthorizationRequest>
        , IAccessTokenProvider
        , IRefreshTokenProvider
        , IGetUserInfoProvider<WechatAuthorizationUserInfoResult, WechatAuthorizationUserRequest>
    {
    }
}
