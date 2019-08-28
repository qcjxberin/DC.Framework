using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipaySecurityDataInfoMobilecityQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySecurityDataInfoMobilecityQueryModel : AlipayObject
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
