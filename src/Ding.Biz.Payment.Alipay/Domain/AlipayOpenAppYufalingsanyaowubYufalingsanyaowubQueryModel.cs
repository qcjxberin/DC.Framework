using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenAppYufalingsanyaowubYufalingsanyaowubQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenAppYufalingsanyaowubYufalingsanyaowubQueryModel : AlipayObject
    {
        /// <summary>
        /// yufaa
        /// </summary>
        [JsonProperty("yufaa")]
        public string Yufaa { get; set; }
    }
}
