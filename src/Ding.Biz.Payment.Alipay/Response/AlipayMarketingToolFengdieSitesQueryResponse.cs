using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingToolFengdieSitesQueryResponse.
    /// </summary>
    public class AlipayMarketingToolFengdieSitesQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 站点查询返回值
        /// </summary>
        [JsonProperty("data")]
        [XmlElement("data")]
        public FengdieSitesQueryRespModel Data { get; set; }
    }
}
