using System.Net.Sockets;
using Ding.Net.Sockets;

namespace Ding.Net.SGIP
{
    /// <summary>SGIP服务器</summary>
    public class SGIPServer : NetServer
    {
        #region 构造
        /// <summary>实例化</summary>
        public SGIPServer()
        {
            ProtocolType = NetType.Tcp;
            Port = 8801;
        }
        #endregion
    }
}