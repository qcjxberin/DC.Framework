using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEbppInvoiceTitleListGetResponse.
    /// </summary>
    public class AlipayEbppInvoiceTitleListGetResponse : AlipayResponse
    {
        /// <summary>
        /// 抬头列表
        /// </summary>
        [JsonProperty("title_list")]
        public List<InvoiceTitleModel> TitleList { get; set; }
    }
}
