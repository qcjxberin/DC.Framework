﻿using Ding.Sms.LuoSiMao;
using System.Threading.Tasks;

namespace Ding.Sms.FengHuo
{
    /// <summary>
    /// 短信配置提供器
    /// </summary>
    public interface ISmsConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        Task<SmsConfig> GetConfigAsync();
    }
}
