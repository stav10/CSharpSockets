using System.Net;
using System.Net.Sockets;
using BL.Abstractions;
using BL.TcpClients;

namespace BL.Factories
{
    public class TcpClientUserFactory
    {
        public TcpClientUserFactory(string ip, int port)
        {
            IP = ip;
            Port = port;
        }

        public string IP { get; set; }
        public int Port { get; set; }

        public (IConnectionClient<byte[]>, IPEndPoint) Create()
        {
            var tcpClient = new TcpClient();
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
            return (new TcpClientUser(tcpClient), ipEndPoint);
        }
    }
}
