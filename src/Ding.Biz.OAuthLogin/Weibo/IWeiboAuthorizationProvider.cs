using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Weibo
{
    /// <summary>
    /// 微博授权提供程序
    /// </summary>
    public interface IWeiboAuthorizationProvider : IAuthorizationUrlProvider<WeiboAuthorizationRequest>
        , IAccessTokenProvider
        , IGetUserInfoProvider<WeiboAuthorizationUserInfoResult, WeiboAuthorizationUserRequest>
    {
    }
}
