using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AntfortuneContentCommunityLabelQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntfortuneContentCommunityLabelQueryModel : AlipayObject
    {
        /// <summary>
        /// 标签场景
        /// </summary>
        [JsonProperty("label_scene")]
        public string LabelScene { get; set; }
    }
}
