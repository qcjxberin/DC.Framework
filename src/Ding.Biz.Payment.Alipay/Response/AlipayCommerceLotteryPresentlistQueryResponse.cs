using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceLotteryPresentlistQueryResponse.
    /// </summary>
    public class AlipayCommerceLotteryPresentlistQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 列表内容
        /// </summary>
        [JsonProperty("results")]
        public List<LotteryPresent> Results { get; set; }

        /// <summary>
        /// 返回的列表的大小
        /// </summary>
        [JsonProperty("total_result")]
        public long TotalResult { get; set; }
    }
}
