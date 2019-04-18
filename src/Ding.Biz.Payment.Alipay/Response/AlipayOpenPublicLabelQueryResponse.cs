using System.Collections.Generic;
using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicLabelQueryResponse.
    /// </summary>
    public class AlipayOpenPublicLabelQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 该服务窗拥有的标签列表
        /// </summary>
        [JsonProperty("label_list")]
        [XmlArray("label_list")]
        [XmlArrayItem("public_label")]
        public List<PublicLabel> LabelList { get; set; }
    }
}
