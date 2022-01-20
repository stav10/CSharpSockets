using BL.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace BL.TcpClients
{
    public class SocketClient : IConnectionClient<byte[]>
    {
        private readonly Socket _socket;

        public SocketClient(Socket socket)
        {
            _socket = socket;
        }

        public void Connect(EndPoint ipEndPoint)
        {
            _socket.Connect(ipEndPoint);
        }

        public int Receive(byte[] buffer)
        {
            return _socket.Receive(buffer);
        }

        public void Send(byte[] buffer)
        {
            _socket.Send(buffer);
        }
    }
}
