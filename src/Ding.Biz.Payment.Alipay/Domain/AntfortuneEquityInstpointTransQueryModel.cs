﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AntfortuneEquityInstpointTransQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntfortuneEquityInstpointTransQueryModel : AlipayObject
    {
        /// <summary>
        /// 查询流水的结束时间。与start_time的时间跨度不超过6个月
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        /// <summary>
        /// 分页的当前页数。取值范围[1-999]
        /// </summary>
        [JsonProperty("page_num")]
        public long PageNum { get; set; }

        /// <summary>
        /// 分页每页大小。取值范围[1,20]
        /// </summary>
        [JsonProperty("page_size")]
        public long PageSize { get; set; }

        /// <summary>
        /// 查询流水的开始时间。与end_time的时间跨度不超过6个月
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// 查询的积分流水类型。多个英文逗号分隔。不传或传空时，默认为全部流水。全部流水类型包括SEND_POINT：积分发放流水，TRADE_SUBTRACT：兑换使用积分流水，DIRECT_SUBTRACT：直接扣减流水。
        /// </summary>
        [JsonProperty("trans_type")]
        public List<string> TransType { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}