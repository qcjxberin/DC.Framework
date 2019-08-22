using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorDepositQueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorDepositQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 待圈存明细
        /// </summary>
        [JsonProperty("recharge_bills")]
        public List<RechargeBill> RechargeBills { get; set; }
    }
}
