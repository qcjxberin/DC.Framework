using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorVoucherBatchqueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorVoucherBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 查询到的订单信息列表
        /// </summary>
        [JsonProperty("tickets")]
        public List<TicketDetailInfo> Tickets { get; set; }
    }
}
