using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// ZhimaAuthInfoAuthqueryResponse.
    /// </summary>
    public class ZhimaAuthInfoAuthqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 是否已经授权,已授权:true,未授权:false
        /// </summary>
        [JsonProperty("authorized")]
        [XmlElement("authorized")]
        public bool Authorized { get; set; }
    }
}
