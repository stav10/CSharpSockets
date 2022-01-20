using System;
using System.Net;
using System.Configuration;
using BL.Abstractions;

namespace BL
{
    public class Client : IClient<byte[]>
    {
        private readonly IConnectionClient<byte[]> _socket;
        private readonly int _lengthBytesCount;

        public Client(IConnectionClient<byte[]> client)
        {
            _socket = client;
            _lengthBytesCount = int.Parse(ConfigurationManager.AppSettings["lengthBytesCount"]);
        }

        public Client(IConnectionClient<byte[]> client, IPEndPoint ipEndPoint)
        {
            _socket = client;
            _socket.Connect(ipEndPoint);
        }

        public byte[] Receive()
        {
            int length = ReciveLength();
            byte[] buffer = new byte[length];
            _socket.Receive(buffer);
            return buffer;
        }

        public void Send(byte[] buffer)
        {
            _socket.Send(BitConverter.GetBytes(buffer.Length));
            _socket.Send(buffer);
        }

        private int ReciveLength()
        {
            var lengthChunk = new byte[_lengthBytesCount];
            _socket.Receive(lengthChunk);
            return BitConverter.ToInt32(lengthChunk);
        }
    }
}
