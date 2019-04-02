using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Jd
{
    /// <summary>
    /// 京东授权提供程序
    /// </summary>
    public interface IJdAuthorizationProvider : IAuthorizationUrlProvider<JdAuthorizationRequest>
    {
    }
}
