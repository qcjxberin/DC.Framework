using System.Collections.Generic;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniTemplateUsageQueryResponse.
    /// </summary>
    public class AlipayOpenMiniTemplateUsageQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 小程序appId列表
        /// </summary>
        [JsonProperty("app_ids")]
        public List<string> AppIds { get; set; }

        /// <summary>
        /// 模板使用信息
        /// </summary>
        [JsonProperty("template_usage_info_list")]
        public List<TemplateUsageInfo> TemplateUsageInfoList { get; set; }
    }
}
