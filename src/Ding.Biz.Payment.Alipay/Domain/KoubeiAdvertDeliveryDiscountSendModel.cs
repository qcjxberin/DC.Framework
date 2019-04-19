using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiAdvertDeliveryDiscountSendModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiAdvertDeliveryDiscountSendModel : AlipayObject
    {
        /// <summary>
        /// 外投ID，通过adv_id的前缀，区分业务标识，  I或者无前缀：adv_id表示券ID，  A：adv_id为广告平台的广告ID，  C：为营销活动ID，    外投ID可以通过“口碑广告投放优惠输出接口”获取
        /// </summary>
        [JsonProperty("adv_id")]
        [XmlElement("adv_id")]
        public string AdvId { get; set; }

        /// <summary>
        /// 渠道编号，适用于外投发券，channel_code/channel_id，必须保证至少有一个不为空
        /// </summary>
        [JsonProperty("channel_code")]
        [XmlElement("channel_code")]
        public string ChannelCode { get; set; }

        /// <summary>
        /// 适用于在推广者主站上注册的渠道编号，channel_code/channel_id，必须保证至少有一个不为空
        /// </summary>
        [JsonProperty("channel_id")]
        [XmlElement("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// 外部流水号，用于区别每次请求的流水号
        /// </summary>
        [JsonProperty("out_biz_no")]
        [XmlElement("out_biz_no")]
        public string OutBizNo { get; set; }

        /// <summary>
        /// 券推荐ID，从”口碑广告投放优惠输出接口“返回参数中获取，需要在领券的时候传回来，用来进行后续效果优化
        /// </summary>
        [JsonProperty("recommend_id")]
        [XmlElement("recommend_id")]
        public string RecommendId { get; set; }

        /// <summary>
        /// 领取优惠的门店id
        /// </summary>
        [JsonProperty("shop_id")]
        [XmlElement("shop_id")]
        public string ShopId { get; set; }

        /// <summary>
        /// 推广参与打标(无实际业务作用，后期可供ISV分析不同渠道的推广效能)
        /// </summary>
        [JsonProperty("tag")]
        [XmlElement("tag")]
        public string Tag { get; set; }
    }
}
