using System.IO;

namespace Ding.Ip
{
    public class InvalidDatabaseException : IOException
    {
        public InvalidDatabaseException(string message) : base(message)
        {
        }
    }
}
