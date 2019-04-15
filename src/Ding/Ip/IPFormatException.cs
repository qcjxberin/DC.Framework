using System;

namespace Ding.Ip
{
    public class IPFormatException : Exception
    {
        public IPFormatException(string name) : base(name)
        {
        }
    }
}
