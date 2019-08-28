﻿using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// RepayDetailVO Data Structure.
    /// </summary>
    [Serializable]
    public class RepayDetailVO : AlipayObject
    {
        /// <summary>
        /// 归还利息
        /// </summary>
        [JsonProperty("paid_int_amt")]
        public string PaidIntAmt { get; set; }

        /// <summary>
        /// 归还逾期利息
        /// </summary>
        [JsonProperty("paid_ovd_int_amt")]
        public string PaidOvdIntAmt { get; set; }

        /// <summary>
        /// 归还逾期利息罚息
        /// </summary>
        [JsonProperty("paid_ovd_int_penalty_amt")]
        public string PaidOvdIntPenaltyAmt { get; set; }

        /// <summary>
        /// 归还逾期本金
        /// </summary>
        [JsonProperty("paid_ovd_prin_amt")]
        public string PaidOvdPrinAmt { get; set; }

        /// <summary>
        /// 归还逾期本金罚息
        /// </summary>
        [JsonProperty("paid_ovd_prin_penalty_amt")]
        public string PaidOvdPrinPenaltyAmt { get; set; }

        /// <summary>
        /// 归还本金
        /// </summary>
        [JsonProperty("paid_prin_amt")]
        public string PaidPrinAmt { get; set; }

        /// <summary>
        /// 还款总金额
        /// </summary>
        [JsonProperty("repay_amt_total")]
        public string RepayAmtTotal { get; set; }

        /// <summary>
        /// 还款时间
        /// </summary>
        [JsonProperty("repay_date")]
        public string RepayDate { get; set; }
    }
}