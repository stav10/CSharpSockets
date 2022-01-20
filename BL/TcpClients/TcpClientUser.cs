using System.Net;
using System.Net.Sockets;
using BL.Abstractions;

namespace BL.TcpClients
{
    public class TcpClientUser : IConnectionClient<byte[]>
    {
        private readonly TcpClient _socket;

        public TcpClientUser(TcpClient socket)
        {
            _socket = socket;
        }

        public void Connect(IPEndPoint ipEndPoint)
        {
            _socket.Connect(ipEndPoint);
        }

        public int Receive(byte[] buffer)
        {
            return _socket.GetStream().Read(buffer, 0, buffer.Length);
        }

        public void Send(byte[] buffer)
        {
            _socket.GetStream().Write(buffer, 0, buffer.Length);
        }
    }
}
