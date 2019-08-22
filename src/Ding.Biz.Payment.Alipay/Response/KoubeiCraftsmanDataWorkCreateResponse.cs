using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCraftsmanDataWorkCreateResponse.
    /// </summary>
    public class KoubeiCraftsmanDataWorkCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 作品id
        /// </summary>
        [JsonProperty("works")]
        public List<CraftsmanWorkOutIdOpenModel> Works { get; set; }
    }
}
