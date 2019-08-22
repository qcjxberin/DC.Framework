using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicMenuDataBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicMenuDataBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 菜单分析数据列表
        /// </summary>
        [JsonProperty("data_list")]
        public List<MenuAnalysisData> DataList { get; set; }
    }
}
