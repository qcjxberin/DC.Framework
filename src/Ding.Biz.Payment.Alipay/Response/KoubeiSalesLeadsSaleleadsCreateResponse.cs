using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiSalesLeadsSaleleadsCreateResponse.
    /// </summary>
    public class KoubeiSalesLeadsSaleleadsCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 生成的销售LeadsId
        /// </summary>
        [JsonProperty("leads_id")]
        public string LeadsId { get; set; }
    }
}
