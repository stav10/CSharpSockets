using BL.Abstractions;
using System.Net;
using System.Net.Sockets;

namespace BL.TcpClients
{
    public class TcpClientUser : IConnectionClient<byte[]>
    {
        private readonly TcpClient _socket;
        private NetworkStream _stream;

        public TcpClientUser(TcpClient socket)
        {
            _socket = socket;
        }

        public void Connect(EndPoint ipEndPoint)
        {
            _stream = _socket.GetStream();
        }

        public int Receive(byte[] buffer)
        {
            return _stream.Read(buffer);
        }

        public void Send(byte[] buffer)
        {
            _stream.Write(buffer);
        }
    }
}
