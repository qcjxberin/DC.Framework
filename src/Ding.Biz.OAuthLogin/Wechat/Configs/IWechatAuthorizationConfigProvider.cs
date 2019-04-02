using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Wechat.Configs
{
    /// <summary>
    /// 微信授权配置提供程序
    /// </summary>
    public interface IWechatAuthorizationConfigProvider : IAuthorizationConfigProvider<WechatAuthorizationConfig>
    {
    }
}
