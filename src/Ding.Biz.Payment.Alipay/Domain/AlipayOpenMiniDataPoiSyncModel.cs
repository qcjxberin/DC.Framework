using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenMiniDataPoiSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniDataPoiSyncModel : AlipayObject
    {
        /// <summary>
        /// poi回流数据
        /// </summary>
        [JsonProperty("poi_data")]
        public PoiSyncData PoiData { get; set; }
    }
}
