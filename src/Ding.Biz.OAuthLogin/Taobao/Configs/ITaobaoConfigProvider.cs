using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.Taobao.Configs
{
    /// <summary>
    /// Taobao配置提供器
    /// </summary>
    public interface ITaobaoConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<TaobaoConfig> GetConfigAsync();
    }
}
