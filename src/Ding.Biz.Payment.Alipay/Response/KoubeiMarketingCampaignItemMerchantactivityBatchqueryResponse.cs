using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingCampaignItemMerchantactivityBatchqueryResponse.
    /// </summary>
    public class KoubeiMarketingCampaignItemMerchantactivityBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 活动信息
        /// </summary>
        [JsonProperty("activities")]
        public List<MerchantOnlineActivityOpenModel> Activities { get; set; }
    }
}
