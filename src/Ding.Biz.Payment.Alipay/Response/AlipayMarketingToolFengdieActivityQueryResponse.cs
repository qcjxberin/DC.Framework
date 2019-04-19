using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingToolFengdieActivityQueryResponse.
    /// </summary>
    public class AlipayMarketingToolFengdieActivityQueryResponse : AlipayResponse
    {
        /// <summary>
        /// H5应用详情
        /// </summary>
        [JsonProperty("activity")]
        [XmlElement("activity")]
        public FengdieActivity Activity { get; set; }
    }
}
