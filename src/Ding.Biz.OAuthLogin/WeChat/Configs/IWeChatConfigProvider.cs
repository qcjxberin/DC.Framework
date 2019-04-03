using System.Threading.Tasks;

namespace Ding.Biz.OAuthLogin.WeChat.Configs
{
    /// <summary>
    /// WeChat配置提供器
    /// </summary>
    public interface IWeChatConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        Task<WeChatConfig> GetConfigAsync();
    }
}
