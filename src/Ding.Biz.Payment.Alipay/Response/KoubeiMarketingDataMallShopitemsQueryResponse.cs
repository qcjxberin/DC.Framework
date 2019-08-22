using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingDataMallShopitemsQueryResponse.
    /// </summary>
    public class KoubeiMarketingDataMallShopitemsQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 店铺信息
        /// </summary>
        [JsonProperty("shop_list")]
        public List<TBMiniShopBo> ShopList { get; set; }
    }
}
