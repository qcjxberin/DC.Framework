// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace HaoCoding.Pdu
{
    /// <summary>
    /// 指定手机是否存储或丢弃消息指示
    /// </summary>
    public enum MessageIndicationOperation
    {
        /// <summary>
        /// 消息指示操作未使用 - 默认
        /// </summary>
        NotSet,
        /// <summary>
        /// 存储指示消息
        /// </summary>
        Store,
        /// <summary>
        /// 丢弃指示消息
        /// </summary>
        Discard
    }
}
