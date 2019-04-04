using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.MicroSoft.Configs
{
    /// <summary>
    /// MicroSoft配置提供器
    /// </summary>
    public interface IMicroSoftConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<MicroSoftConfig> GetConfigAsync();
    }
}
