using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Youzan
{
    /// <summary>
    /// 有赞授权提供程序
    /// </summary>
    public interface IYouzanAuthorizationProvider : IAuthorizationUrlProvider<YouzanAuthorizationRequest>
    {
    }
}
