using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiItemExtitemQueryResponse.
    /// </summary>
    public class KoubeiItemExtitemQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        [JsonProperty("extitem")]
        [XmlElement("extitem")]
        public ExtItem Extitem { get; set; }
    }
}
