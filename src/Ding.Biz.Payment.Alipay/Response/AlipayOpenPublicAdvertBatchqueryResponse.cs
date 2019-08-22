using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicAdvertBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicAdvertBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 广告位list ,目前只有一个广告位
        /// </summary>
        [JsonProperty("advert_list")]
        public List<Advert> AdvertList { get; set; }
    }
}
