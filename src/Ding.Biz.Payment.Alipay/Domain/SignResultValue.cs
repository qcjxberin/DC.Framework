using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// SignResultValue Data Structure.
    /// </summary>
    [Serializable]
    public class SignResultValue : AlipayObject
    {
        /// <summary>
        /// 已生效的销账/出账机构
        /// </summary>
        [JsonProperty("effect_biz_value")]
        [XmlElement("effect_biz_value")]
        public string EffectBizValue { get; set; }
    }
}