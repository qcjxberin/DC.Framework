﻿using Newtonsoft.Json;

namespace Ding.Tools.Models
{
    /// <summary>
    /// ISP信息
    /// </summary>
    public class IspInfo
    {
        /// <summary>
        /// 运营商
        /// </summary>
        [JsonProperty("wl")]
        public string ISPName { get; set; }
    }
}