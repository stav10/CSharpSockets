using BL.Abstractions;
using System;
using System.Net;

namespace BL
{
    public class Client : IClient<byte[]>
    {
        private readonly IConnectionClient<byte[]> _socket;

        public Client(IConnectionClient<byte[]> client)
        {
            _socket = client;
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
            var lengthChunk = new byte[4];
            _socket.Receive(lengthChunk);
            return BitConverter.ToInt32(lengthChunk);
        }
    }
}
