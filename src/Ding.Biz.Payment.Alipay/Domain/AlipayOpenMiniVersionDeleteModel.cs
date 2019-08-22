using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenMiniVersionDeleteModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniVersionDeleteModel : AlipayObject
    {
        /// <summary>
        /// 小程序版本号
        /// </summary>
        [JsonProperty("app_version")]
        public string AppVersion { get; set; }
    }
}
