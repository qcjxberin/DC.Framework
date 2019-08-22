using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicUserDataBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicUserDataBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用户分析数据
        /// </summary>
        [JsonProperty("data_list")]
        public List<UserAnalysisData> DataList { get; set; }
    }
}
