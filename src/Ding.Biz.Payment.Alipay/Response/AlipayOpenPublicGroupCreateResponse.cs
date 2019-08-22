using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicGroupCreateResponse.
    /// </summary>
    public class AlipayOpenPublicGroupCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 分组id
        /// </summary>
        [JsonProperty("group_id")]
        public string GroupId { get; set; }
    }
}
