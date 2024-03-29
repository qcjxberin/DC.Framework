﻿using Ding.Biz.Payments.Core;

namespace Ding.Biz.Payments.Wechatpay.Parameters.Requests {
    /// <summary>
    /// 微信小程序支付参数
    /// </summary>
    public class WechatpayMiniProgramPayRequest : PayParamBase {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 附加数据，通知时原样返回
        /// </summary>
        public string Attach { get; set; }
    }
}