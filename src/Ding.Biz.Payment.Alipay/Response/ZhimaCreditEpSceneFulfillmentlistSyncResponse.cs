using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// ZhimaCreditEpSceneFulfillmentlistSyncResponse.
    /// </summary>
    public class ZhimaCreditEpSceneFulfillmentlistSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 履约同步结果列表
        /// </summary>
        [JsonProperty("fulfillment_result_list")]
        public List<FulfillmentResult> FulfillmentResultList { get; set; }
    }
}
