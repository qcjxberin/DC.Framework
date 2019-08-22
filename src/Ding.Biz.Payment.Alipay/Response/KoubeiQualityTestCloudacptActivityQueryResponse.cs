using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiQualityTestCloudacptActivityQueryResponse.
    /// </summary>
    public class KoubeiQualityTestCloudacptActivityQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 活动列表
        /// </summary>
        [JsonProperty("activity_list")]
        public List<OpenActivity> ActivityList { get; set; }
    }
}
