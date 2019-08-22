using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// MiniAppBaseInfoQueryInfo Data Structure.
    /// </summary>
    [Serializable]
    public class MiniAppBaseInfoQueryInfo : AlipayObject
    {
        /// <summary>
        /// 小程序id
        /// </summary>
        [JsonProperty("mini_app_id")]
        public string MiniAppId { get; set; }
    }
}
