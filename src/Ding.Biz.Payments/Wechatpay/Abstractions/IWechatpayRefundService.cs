﻿using System.Threading.Tasks;
using Ding.Biz.Payments.Core;
using Ding.Biz.Payments.Wechatpay.Parameters.Requests;

namespace Ding.Biz.Payments.Wechatpay.Abstractions {
    /// <summary>
    /// 微信退款
    /// </summary>
    public interface IWechatpayRefundService {
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="request">退款参数</param>
        Task<RefundResult> RefundAsync( WechatRefundRequest request );
    }
}
