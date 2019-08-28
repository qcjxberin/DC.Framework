﻿using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayCommerceTransportAdPlanGetModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceTransportAdPlanGetModel : AlipayObject
    {
        /// <summary>
        /// 广告系统的用户ID
        /// </summary>
        [JsonProperty("ad_user_id")]
        public long AdUserId { get; set; }

        /// <summary>
        /// 通过API新建计划，获得的计划ID
        /// </summary>
        [JsonProperty("plan_id")]
        public long PlanId { get; set; }
    }
}