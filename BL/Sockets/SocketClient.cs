using System.Net;
using System.Net.Sockets;
using BL.Abstractions;

namespace BL.Sockets
{
    public class SocketClient : IConnectionClient<byte[]>
    {
        private readonly Socket _socket;

        public SocketClient(Socket socket)
        {
            _socket = socket;
        }

        public void Connect(IPEndPoint ipEndPoint)
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
