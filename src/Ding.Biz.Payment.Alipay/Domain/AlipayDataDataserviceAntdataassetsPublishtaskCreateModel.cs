using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayDataDataserviceAntdataassetsPublishtaskCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataDataserviceAntdataassetsPublishtaskCreateModel : AlipayObject
    {
        /// <summary>
        /// ODPS表的guid
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }
    }
}
