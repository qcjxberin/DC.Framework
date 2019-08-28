using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiCateringPosDishSyncModel Data Structure.
    /// </summary>
    [Serializable]
    public class KoubeiCateringPosDishSyncModel : AlipayObject
    {
        /// <summary>
        /// 自建盒子菜品的模型
        /// </summary>
        [JsonProperty("pos_dish_model")]
        public PosDishModel PosDishModel { get; set; }
    }
}
