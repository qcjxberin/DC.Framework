using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMicropayOrderConfirmpayurlGetResponse.
    /// </summary>
    public class AlipayMicropayOrderConfirmpayurlGetResponse : AlipayResponse
    {
        /// <summary>
        /// SinglePayDetail信息
        /// </summary>
        [JsonProperty("single_pay_detail")]
        [XmlElement("single_pay_detail")]
        public SinglePayDetail SinglePayDetail { get; set; }
    }
}
