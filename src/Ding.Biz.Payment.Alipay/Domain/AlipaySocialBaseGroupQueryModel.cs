using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipaySocialBaseGroupQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySocialBaseGroupQueryModel : AlipayObject
    {
        /// <summary>
        /// 群的id
        /// </summary>
        [JsonProperty("group_id")]
        public string GroupId { get; set; }
    }
}
