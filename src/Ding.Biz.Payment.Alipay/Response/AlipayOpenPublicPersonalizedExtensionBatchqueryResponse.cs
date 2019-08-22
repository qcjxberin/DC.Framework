using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicPersonalizedExtensionBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicPersonalizedExtensionBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 扩展区套数
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }

        /// <summary>
        /// 扩展区信息
        /// </summary>
        [JsonProperty("extensions")]
        public List<QueryExtension> Extensions { get; set; }
    }
}
