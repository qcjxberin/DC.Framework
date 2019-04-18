using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCraftsmanDataProviderCreateResponse.
    /// </summary>
    public class KoubeiCraftsmanDataProviderCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 手艺人id
        /// </summary>
        [JsonProperty("craftsman_id")]
        [XmlElement("craftsman_id")]
        public string CraftsmanId { get; set; }
    }
}
