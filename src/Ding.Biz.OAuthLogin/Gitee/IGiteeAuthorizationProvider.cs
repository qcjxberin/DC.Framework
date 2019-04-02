using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Gitee
{
    /// <summary>
    /// Gitee 授权提供程序
    /// </summary>
    public interface IGiteeAuthorizationProvider : IAuthorizationUrlProvider<GiteeAuthorizationRequest>
        , IAccessTokenProvider
        , IGetUserInfoProvider<GiteeAuthorizationUserInfoResult, GiteeAuthorizationUserRequest>
    {
    }
}
