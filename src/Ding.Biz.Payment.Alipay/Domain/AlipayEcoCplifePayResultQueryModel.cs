using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayEcoCplifePayResultQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoCplifePayResultQueryModel : AlipayObject
    {
        /// <summary>
        /// 查询令牌，部分模式下用户缴物业费成功后由支付宝通过异步通知给到开发者系统，和trade_no二者传其一即可。
        /// </summary>
        [JsonProperty("query_token")]
        [XmlElement("query_token")]
        public string QueryToken { get; set; }

        /// <summary>
        /// 用户完成物业缴费后由支付宝异步通知的支付宝交易号，和查询token参数二者传其一即可。
        /// </summary>
        [JsonProperty("trade_no")]
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }
    }
}