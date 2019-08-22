using System;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayEcoMycarParkingLotbarcodeCreateModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayEcoMycarParkingLotbarcodeCreateModel : AlipayObject
    {
        /// <summary>
        /// 停车场编号
        /// </summary>
        [JsonProperty("parking_id")]
        public string ParkingId { get; set; }
    }
}
