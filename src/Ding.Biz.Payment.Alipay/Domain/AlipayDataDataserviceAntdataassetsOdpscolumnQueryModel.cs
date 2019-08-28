using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayDataDataserviceAntdataassetsOdpscolumnQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayDataDataserviceAntdataassetsOdpscolumnQueryModel : AlipayObject
    {
        /// <summary>
        /// ODPS表的guid
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }
    }
}
