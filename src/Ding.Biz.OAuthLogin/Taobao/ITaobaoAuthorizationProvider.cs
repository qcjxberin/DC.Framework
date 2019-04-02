using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Taobao
{
    /// <summary>
    /// 淘宝授权提供程序
    /// </summary>
    public interface ITaobaoAuthorizationProvider : IAuthorizationUrlProvider<TaobaoAuthorizationRequest>
    {
    }
}
