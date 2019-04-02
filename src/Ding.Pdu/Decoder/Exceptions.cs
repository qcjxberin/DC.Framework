// Copyright (c) 深圳云企微商网络科技有限公司. All Rights Reserved.
// 丁川 QQ：2505111990 微信：i230760 qq群:774046050 邮箱:2505111990@qq.com
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace HaoCoding.Pdu
{
    class UnknownSMSTypeException : Exception
    {
        public UnknownSMSTypeException(byte pduType) : base(string.Format("未知短信类型。 PDU类型二进制: {0}.", Convert.ToString(pduType, 2)))
        { }
    }
}
