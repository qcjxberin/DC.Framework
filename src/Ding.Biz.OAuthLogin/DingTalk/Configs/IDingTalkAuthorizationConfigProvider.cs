using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.DingTalk.Configs
{
    /// <summary>
    /// 钉钉授权配置提供程序
    /// </summary>
    public interface IDingTalkAuthorizationConfigProvider : IAuthorizationConfigProvider<DingTalkAuthorizationConfig>
    {
    }
}
