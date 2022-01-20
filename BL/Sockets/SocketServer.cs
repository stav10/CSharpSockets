using BL.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace BL.Sockets
{
    public class SocketServer : IConnectionServer<byte[]>
    {
        private readonly Socket _socket;

        public SocketServer(Socket socket, IPEndPoint ipEndPoint)
        {
            _socket = socket;
            _socket.Bind(ipEndPoint);
        }

        public IClient<byte[]> Accept()
        {
            var newSocket = new SocketClient(_socket.Accept());
            return new Client(newSocket);
        }

        public void Bind(EndPoint endPoint)
        {
            _socket.Bind(endPoint);
        }

        public void Listen()
        {
            _socket.Listen();
        }
    }
}
