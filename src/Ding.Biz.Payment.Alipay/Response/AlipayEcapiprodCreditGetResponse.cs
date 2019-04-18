using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEcapiprodCreditGetResponse.
    /// </summary>
    public class AlipayEcapiprodCreditGetResponse : AlipayResponse
    {
        /// <summary>
        /// 授信结果
        /// </summary>
        [JsonProperty("credit_result")]
        [XmlElement("credit_result")]
        public CreditResult CreditResult { get; set; }

        /// <summary>
        /// 为了保持幂等性，返回唯一请求号
        /// </summary>
        [JsonProperty("request_id")]
        [XmlElement("request_id")]
        public string RequestId { get; set; }
    }
}
