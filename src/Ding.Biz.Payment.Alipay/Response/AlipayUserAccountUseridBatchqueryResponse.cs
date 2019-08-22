using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserAccountUseridBatchqueryResponse.
    /// </summary>
    public class AlipayUserAccountUseridBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        [JsonProperty("user_id_list")]
        public List<string> UserIdList { get; set; }
    }
}
