using System.Net;
using System.Net.Sockets;
using BL.Abstractions;
using BL.TcpClients;

namespace BL.Factories
{
    public class TcpServerFactory
    {
        public TcpServerFactory(int port)
        {
            Port = port;
        }

        public int Port { get; set; }

        public IConnectionServer<byte[]> Create()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            var tcpListner = new TcpListener(ipEndPoint);
            return new TcpServer(tcpListner);
        }
    }
}
