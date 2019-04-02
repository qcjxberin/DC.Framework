// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Ding.Pdu
{
    /// <summary>
    /// 指示代表的消息类型
    /// </summary>
    public enum IndicationType
    {
        /// <summary>
        /// 语音邮件留言等待
        /// </summary>
        Voicemail,
        /// <summary>
        /// 传真留言等待
        /// </summary>
        FaxMessage,
        /// <summary>
        /// 电子邮件等待
        /// </summary>
        EmailMessage,
        /// <summary>
        /// 其他留言等待
        /// </summary>
        OtherMessage
    }
}
