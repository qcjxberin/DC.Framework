using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayMarketingCardBenefitQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayMarketingCardBenefitQueryModel : AlipayObject
    {
        /// <summary>
        /// 权益ID
        /// </summary>
        [JsonProperty("benefit_id")]
        [XmlElement("benefit_id")]
        public string BenefitId { get; set; }

        /// <summary>
        /// 会员卡模板ID
        /// </summary>
        [JsonProperty("template_id")]
        [XmlElement("template_id")]
        public string TemplateId { get; set; }
    }
}