using System.Collections.Generic;
using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicSinglearticleDataBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicSinglearticleDataBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 单篇文章分析数据列表
        /// </summary>
        [JsonProperty("data_list")]
        [XmlArray("data_list")]
        [XmlArrayItem("single_article_analysis_data")]
        public List<SingleArticleAnalysisData> DataList { get; set; }
    }
}
