using System.Collections.Generic;
using System.Xml.Serialization;
using Ding.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Ding.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEcoCplifeRooominfoQueryResponse.
    /// </summary>
    public class AlipayEcoCplifeRooominfoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 符合条件的小区房屋信息列表.
        /// </summary>
        [JsonProperty("room_info")]
        [XmlArray("room_info")]
        [XmlArrayItem("cplife_room_detail")]
        public List<CplifeRoomDetail> RoomInfo { get; set; }
    }
}
