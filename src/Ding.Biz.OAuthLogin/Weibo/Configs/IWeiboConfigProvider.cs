using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.Weibo.Configs
{
    /// <summary>
    /// QQ配置提供器
    /// </summary>
    public interface IWeiboConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<WeiboConfig> GetConfigAsync();
    }
}
