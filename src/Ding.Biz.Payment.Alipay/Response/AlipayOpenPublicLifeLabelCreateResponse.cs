using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicLifeLabelCreateResponse.
    /// </summary>
    public class AlipayOpenPublicLifeLabelCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 标签id
        /// </summary>
        [JsonProperty("label_id")]
        public string LabelId { get; set; }
    }
}
