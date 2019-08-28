using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayDataDataserviceAntdataassetsClearnodeCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataDataserviceAntdataassetsClearnodeCreateModel : AlipayObject
    {
        /// <summary>
        /// ODPS表的guid
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }
    }
}
