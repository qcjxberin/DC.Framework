using System;

namespace Ding.Utils.Ip
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name) : base(name)
        {
        }
    }
}
