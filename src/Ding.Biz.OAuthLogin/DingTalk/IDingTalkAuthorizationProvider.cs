using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.DingTalk
{
    /// <summary>
    /// 钉钉授权提供程序
    /// </summary>
    public interface IDingTalkAuthorizationProvider : IAuthorizationUrlProvider<DingTalkAuthorizationRequest>
    {
    }
}
