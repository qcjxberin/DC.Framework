using System;

namespace Ding.Ip
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name) : base(name)
        {
        }
    }
}
