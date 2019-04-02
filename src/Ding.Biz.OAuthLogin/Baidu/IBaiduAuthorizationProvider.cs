using Ding.Biz.OAuthLogin.Core;

namespace Ding.Biz.OAuthLogin.Baidu
{
    /// <summary>
    /// 百度授权提供程序
    /// </summary>
    public interface IBaiduAuthorizationProvider : IAuthorizationUrlProvider<BaiduAuthorizationRequest>
    {
    }
}
