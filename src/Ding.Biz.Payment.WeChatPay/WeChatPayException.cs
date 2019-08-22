using System;

namespace Ding.Payment.WeChatPay
{
    public class WeChatPayException : Exception
    {
        public WeChatPayException(string messages) : base(messages)
        {
        }
    }
}
