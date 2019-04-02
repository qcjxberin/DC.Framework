using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Github.Configs
{
    /// <summary>
    /// Github授权配置提供程序
    /// </summary>
    public interface IGithubAuthorizationConfigProvider : IAuthorizationConfigProvider<GithubAuthorizationConfig>
    {
    }
}
