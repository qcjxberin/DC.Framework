using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCardBenefitDeleteResponse.
    /// </summary>
    public class AlipayMarketingCardBenefitDeleteResponse : AlipayResponse
    {
        /// <summary>
        /// 权益删除结果；true成功，false失败
        /// </summary>
        [JsonProperty("result")]
        [XmlElement("result")]
        public bool Result { get; set; }
    }
}
