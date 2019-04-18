using System;

namespace Ding.Payment.WeChatPay
{
    /// <summary>
    /// WeChatPay 异常。
    /// </summary>
    public class WeChatPayException : Exception
    {
        public WeChatPayException(string messages) : base(messages)
        {
        }
    }
}
