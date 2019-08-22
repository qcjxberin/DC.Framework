using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicAccountQueryResponse.
    /// </summary>
    public class AlipayOpenPublicAccountQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 绑定账户列表
        /// </summary>
        [JsonProperty("public_bind_accounts")]
        public List<StdPublicBindAccount> PublicBindAccounts { get; set; }
    }
}
