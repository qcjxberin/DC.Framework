using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCardBenefitModifyResponse.
    /// </summary>
    public class AlipayMarketingCardBenefitModifyResponse : AlipayResponse
    {
        /// <summary>
        /// 权益修改结果；true成功：false失败
        /// </summary>
        [JsonProperty("result")]
        [XmlElement("result")]
        public bool Result { get; set; }
    }
}
