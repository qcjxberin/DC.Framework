using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenAppSilanApigrayoneQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAppSilanApigrayoneQueryModel : AlipayObject
    {
        /// <summary>
        /// param
        /// </summary>
        [JsonProperty("param_1")]
        public string Param1 { get; set; }
    }
}
