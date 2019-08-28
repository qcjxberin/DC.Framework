using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiMarketingCampaignMemberAuthApplyModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiMarketingCampaignMemberAuthApplyModel : AlipayObject
    {
        /// <summary>
        /// token
        /// </summary>
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }
    }
}
