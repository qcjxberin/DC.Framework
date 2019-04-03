using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.Configs
{
    /// <summary>
    /// QQ配置提供器
    /// </summary>
    public interface IQQConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<QQConfig> GetConfigAsync();
    }
}
