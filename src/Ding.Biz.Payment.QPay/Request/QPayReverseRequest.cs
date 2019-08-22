using System.Collections.Generic;
using Ding.Payment.QPay.Response;
using Ding.Payment.QPay.Utility;

namespace Ding.Payment.QPay.Request
{
    /// <summary>
    /// 撤销订单
    /// </summary>
    public class QPayReverseRequest : IQPayCertRequest<QPayReverseResponse>
    {
        /// <summary>
        /// 子商户应用ID
        /// </summary>
        public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// </summary>
        public string SubMchId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string OpUserId { get; set; }

        /// <summary>
        /// 操作员密码的MD5
        /// </summary>
        public string OpUserPasswd { get; set; }

        #region IQPayCertificateRequest Members

        public string GetRequestUrl()
        {
            return "https://api.qpay.qq.com/cgi-bin/pay/qpay_reverse.cgi";
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new QPayDictionary
            {
                { "sub_appid", SubAppId },
                { "sub_mch_id", SubMchId },
                { "out_trade_no", OutTradeNo },
                { "op_user_id", OpUserId },
                { "op_user_passwd", OpUserPasswd }
            };
            return parameters;
        }

        public void PrimaryHandler(QPayOptions options, QPayDictionary sortedTxtParams)
        {
            sortedTxtParams.Add(QPayConsts.NONCE_STR, QPayUtility.GenerateNonceStr());
            sortedTxtParams.Add(QPayConsts.APPID, options.AppId);
            sortedTxtParams.Add(QPayConsts.MCH_ID, options.MchId);

            sortedTxtParams.Add(QPayConsts.SIGN, QPaySignature.SignWithKey(sortedTxtParams, options.Key));
        }

        public bool GetNeedCheckSign()
        {
            return true;
        }

        #endregion
    }
}
