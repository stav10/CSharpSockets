using BL.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace BL.TcpClients
{
    public class TcpListenerServer : IConnectionServer<byte[]>
    {
        private readonly TcpListener _socket;

        public TcpListenerServer(TcpListener socket, IPEndPoint ipEndPoint)
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
