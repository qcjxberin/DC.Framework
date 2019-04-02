using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Github
{
    /// <summary>
    /// Github授权提供程序
    /// </summary>
    public interface IGithubAuthorizationProvider : IAuthorizationUrlProvider<GithubAuthorizationRequest>
        , IAccessTokenProvider
        , IGetUserInfoProvider<GithubAuthorizationUserInfoResult, GithubAuthorizationUserRequest>
    {
    }
}
