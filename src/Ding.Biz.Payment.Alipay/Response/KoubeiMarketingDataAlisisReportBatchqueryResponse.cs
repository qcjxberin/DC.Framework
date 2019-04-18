using System.Collections.Generic;
using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingDataAlisisReportBatchqueryResponse.
    /// </summary>
    public class KoubeiMarketingDataAlisisReportBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 报表列表信息
        /// </summary>
        [JsonProperty("report_list")]
        [XmlArray("report_list")]
        [XmlArrayItem("alisis_report")]
        public List<AlisisReport> ReportList { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [JsonProperty("total_count")]
        [XmlElement("total_count")]
        public string TotalCount { get; set; }
    }
}
