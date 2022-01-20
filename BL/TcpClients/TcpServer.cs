using BL.Abstractions;
using System.Net.Sockets;

namespace BL.TcpClients
{
    public class TcpServer : IConnectionServer<byte[]>
    {
        private readonly TcpListener _socket;

        public TcpServer(TcpListener socket)
        {
            _socket = socket;
        }

        public IClient<byte[]> Accept()
        {
            var newSocket = new TcpClientUser(_socket.AcceptTcpClient());
            return new Client(newSocket);
        }

        public void Listen()
        {
            _socket.Start();
        }
    }
}
