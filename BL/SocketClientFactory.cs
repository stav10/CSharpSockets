using System.Net;
using System.Net.Sockets;
using BL.Abstractions;

namespace BL
{
    public class SocketClientFactory
    {
        public ISocketClient<byte[]> Create()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            return new SocketClient(socket, ipEndPoint);
        }
    }
}
