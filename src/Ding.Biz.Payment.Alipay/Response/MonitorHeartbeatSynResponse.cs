using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// MonitorHeartbeatSynResponse.
    /// </summary>
    public class MonitorHeartbeatSynResponse : AlipayResponse
    {
        /// <summary>
        /// 商户pid
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; }
    }
}
