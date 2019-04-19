using System;

namespace Ding.Payment.UnionPay
{
    /// <summary>
    /// UnionPay 异常。
    /// </summary>
    public class UnionPayException : Exception
    {
        public UnionPayException(string messages) : base(messages)
        {
        }
    }
}
