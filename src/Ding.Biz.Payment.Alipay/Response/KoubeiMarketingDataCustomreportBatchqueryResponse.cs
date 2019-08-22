using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingDataCustomreportBatchqueryResponse.
    /// </summary>
    public class KoubeiMarketingDataCustomreportBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 分页输出自定义开放数据规则列表
        /// </summary>
        [JsonProperty("report_condition_list")]
        public List<CustomReportCondition> ReportConditionList { get; set; }
    }
}
