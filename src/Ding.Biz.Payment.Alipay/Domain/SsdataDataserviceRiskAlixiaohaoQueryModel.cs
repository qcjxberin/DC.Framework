using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// SsdataDataserviceRiskAlixiaohaoQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class SsdataDataserviceRiskAlixiaohaoQueryModel : AlipayObject
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [JsonProperty("mobile_no")]
        public string MobileNo { get; set; }
    }
}
