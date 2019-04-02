using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Weibo.Configs
{
    /// <summary>
    /// 微博授权配置提供程序
    /// </summary>
    public interface IWeiboAuthorizationConfigProvider : IAuthorizationConfigProvider<WeiboAuthorizationConfig>
    {
    }
}
