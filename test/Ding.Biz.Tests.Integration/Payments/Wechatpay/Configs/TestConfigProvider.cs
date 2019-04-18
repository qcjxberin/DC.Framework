using System.Threading.Tasks;
using Ding.Biz.Payments.Wechatpay.Configs;
using Ding.Parameters;

namespace Ding.Biz.Tests.Integration.Payments.Wechatpay.Configs {
    /// <summary>
    /// 微信支付测试配置提供器
    /// </summary>
    public class TestConfigProvider : IWechatpayConfigProvider {
        /// <summary>
        /// 请填写正确的微信支付配置
        /// </summary>
        public Task<WechatpayConfig> GetConfigAsync( IParameterManager parameters = null ) {
            var config = new WechatpayConfig {
                AppId = "",
                MerchantId = "",
                PrivateKey = "",
                NotifyUrl = ""
            };
            return Task.FromResult( config );
        }
    }
}
