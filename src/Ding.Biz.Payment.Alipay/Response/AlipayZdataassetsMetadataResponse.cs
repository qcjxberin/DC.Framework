using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayZdataassetsMetadataResponse.
    /// </summary>
    public class AlipayZdataassetsMetadataResponse : AlipayResponse
    {
        /// <summary>
        /// 用户标签集合
        /// </summary>
        [JsonProperty("result")]
        public List<CustomerEntity> Result { get; set; }
    }
}
