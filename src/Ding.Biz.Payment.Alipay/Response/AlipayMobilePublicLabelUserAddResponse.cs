using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMobilePublicLabelUserAddResponse.
    /// </summary>
    public class AlipayMobilePublicLabelUserAddResponse : AlipayResponse
    {
        /// <summary>
        /// 结果码
        /// </summary>
        [JsonProperty("code")]
        [XmlElement("code")]
        public new string Code { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        [JsonProperty("msg")]
        [XmlElement("msg")]
        public new string Msg { get; set; }
    }
}
