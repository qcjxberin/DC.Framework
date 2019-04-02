using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Facebook
{
    /// <summary>
    /// Facebook 授权提供程序
    /// </summary>
    public interface IFacebookAuthorizationProvider : IAuthorizationUrlProvider<FacebookAuthorizationRequest>
    {
    }
}
