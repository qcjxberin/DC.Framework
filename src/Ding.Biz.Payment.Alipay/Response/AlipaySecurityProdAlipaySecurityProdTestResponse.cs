using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityProdAlipaySecurityProdTestResponse.
    /// </summary>
    public class AlipaySecurityProdAlipaySecurityProdTestResponse : AlipayResponse
    {
        /// <summary>
        /// ddd
        /// </summary>
        [JsonProperty("admin")]
        [XmlElement("admin")]
        public string Admin { get; set; }
    }
}
