using BL.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace BL
{
    public class SocketServerFactory
    {
        public SocketServerFactory(int port)
        {
            Port = port;
        }

        public int Port { get; set; }

        public ISocketClient<byte[]> Create()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            return new SocketClient(socket, ipEndPoint);
        }
    }
}
