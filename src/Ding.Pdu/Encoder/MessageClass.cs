// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace HaoCoding.Pdu
{
    /// <summary>
    /// 消息类指示将存储消息的位置
    /// </summary>
    public enum MessageClass
    {
        /// <summary>
        /// Flash消息仅显示
        /// </summary>
        ImmediateDisplay,
        /// <summary>
        /// 默认商店
        /// </summary>
        MESpecific,
        /// <summary>
        /// SIM的消息
        /// </summary>
        SIMSpecific,
        /// <summary>
        /// TE具体
        /// </summary>
        TESpecific
    }
}
