using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Gitee.Configs
{
    /// <summary>
    /// Gitee 授权配置提供程序
    /// </summary>
    public interface IGiteeAuthorizationConfigProvider : IAuthorizationConfigProvider<GiteeAuthorizationConfig>
    {
    }
}
