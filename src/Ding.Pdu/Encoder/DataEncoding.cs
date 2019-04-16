// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Ding.Pdu
{
    /// <summary>
    /// SMS消息编码
    /// </summary>
    public enum DataEncoding
    {
        /// <summary>
        /// GSM中默认使用7位编码
        /// </summary>
        Default7bit,
        /// <summary>
        /// 8位编码
        /// </summary>
        Data8bit,
        /// <summary>
        /// UCS2 16位编码
        /// </summary>
        UCS2_16bit
    }
}
