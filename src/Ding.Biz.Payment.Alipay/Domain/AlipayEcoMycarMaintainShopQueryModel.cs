using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayEcoMycarMaintainShopQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarMaintainShopQueryModel : AlipayObject
    {
        /// <summary>
        /// 外部门店编号（与shop_id二选一，不能都为空）
        /// </summary>
        [JsonProperty("out_shop_id")]
        [XmlElement("out_shop_id")]
        public string OutShopId { get; set; }

        /// <summary>
        /// 车主平台门店编号（与out_shop_id二选一，不能都为空）
        /// </summary>
        [JsonProperty("shop_id")]
        [XmlElement("shop_id")]
        public long ShopId { get; set; }
    }
}
