﻿using System.Collections.Generic;
using Ding.Payment.UnionPay.Response;

namespace Ding.Payment.UnionPay.Request
{
    /// <summary>
    /// 网关支付(V2.2) 交易状态查询接口
    /// </summary>
    public class UnionPayGatewayPayQueryRequest : IUnionPayRequest<UnionPayGatewayPayQueryResponse>
    {
        /// <summary>
        /// 产品类型
        /// </summary>
        public string BizType { get; set; }

        /// <summary>
        /// 订单发送时间
        /// </summary>
        public string TxnTime { get; set; }

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TxnType { get; set; }

        /// <summary>
        /// 交易子类
        /// </summary>
        public string TxnSubType { get; set; }

        /// <summary>
        /// 商户订单号	
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 保留域	
        /// </summary>
        public string Reserved { get; set; }

        #region IUnionPayRequest

        private string version = string.Empty;

        public string GetApiVersion()
        {
            return version;
        }

        public void SetApiVersion(string version)
        {
            this.version = version;
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new UnionPayDictionary
            {
                { "bizType", BizType },
                { "txnTime", TxnTime },
                { "txnType", TxnType },
                { "txnSubType", TxnSubType },
                { "orderId", OrderId },
                { "reserved", Reserved }
            };
            return parameters;
        }

        public string GetRequestUrl(bool isTest)
        {
            return isTest ? "https://gateway.test.95516.com/gateway/api/queryTrans.do" : "https://gateway.95516.com/gateway/api/queryTrans.do";
        }

        public bool HasEncryptCertId()
        {
            return false;
        }

        #endregion
    }
}
