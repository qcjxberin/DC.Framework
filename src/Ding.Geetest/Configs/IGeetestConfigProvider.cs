using System.Threading.Tasks;

namespace Ding.Geetest.Configs
{
    /// <summary>
    /// 极验配置提供器
    /// </summary>
    public interface IGeetestConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        GeetestConfig GetConfig();

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<GeetestConfig> GetConfigAsync();
    }
}
