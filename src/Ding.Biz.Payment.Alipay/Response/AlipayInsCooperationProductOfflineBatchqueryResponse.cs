using System.Collections.Generic;
using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsCooperationProductOfflineBatchqueryResponse.
    /// </summary>
    public class AlipayInsCooperationProductOfflineBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 返回给机构的线下产品信息列表
        /// </summary>
        [JsonProperty("product_list")]
        [XmlArray("product_list")]
        [XmlArrayItem("ins_offilne_product")]
        public List<InsOffilneProduct> ProductList { get; set; }
    }
}
