using System;

namespace Ding.Payment.QPay
{
    public class QPayException : Exception
    {
        public QPayException(string messages) : base(messages)
        {
        }
    }
}
