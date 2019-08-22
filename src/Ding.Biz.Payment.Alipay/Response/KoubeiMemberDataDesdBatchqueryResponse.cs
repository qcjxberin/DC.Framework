using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMemberDataDesdBatchqueryResponse.
    /// </summary>
    public class KoubeiMemberDataDesdBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 21
        /// </summary>
        [JsonProperty("de")]
        public GavintestNewonline De { get; set; }
    }
}
