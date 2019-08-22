using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserContractGetResponse.
    /// </summary>
    public class AlipayUserContractGetResponse : AlipayResponse
    {
        /// <summary>
        /// 支付宝用户订购信息
        /// </summary>
        [JsonProperty("alipay_contract")]
        public AlipayContract AlipayContract { get; set; }
    }
}
