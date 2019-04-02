using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Microsoft
{
    /// <summary>
    /// Microsoft 授权提供程序
    /// </summary>
    public interface IMicrosoftAuthorizationProvider : IAuthorizationUrlProvider<MicrosoftAuthorizationRequest>
    {
    }
}
