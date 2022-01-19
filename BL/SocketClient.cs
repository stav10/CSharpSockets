using System;
using System.Net.Sockets;
using Common.Abstractions;
using BL.Abstractions;

namespace BL
{
    public class SocketClient
    {
        private readonly IOutput _output;
        private readonly IInput<string> _input;
        private readonly IConvertor<string, byte[]> _convertor;
        private readonly Socket _socket;

        public SocketClient(
                        IInput<string> input,
                        IOutput output,
                        Socket socket,
                        IConvertor<string, byte[]> convertor)
        {
            _input = input;
            _output = output;
            _convertor = convertor;
            _socket = socket;
        }

        public void Recive()
        {
            int length = ReciveLength();
            var buffer = new byte[length];
            _socket.Receive(buffer, 4, length, SocketFlags.None);
            _output.Print(buffer);
        }

        public void Send()
        {
            string message = _input.Read();
            bool isSucceeded = _convertor.TryConvert(message, out byte[] buffer);
            if (isSucceeded)
            {
                _socket.Send(BitConverter.GetBytes(buffer.Length));
                _socket.Send(buffer);
            }
        }

        private int ReciveLength()
        {
            var lengthChunk = new byte[4];
            _socket.Receive(lengthChunk);
            return BitConverter.ToInt32(lengthChunk);
        }
    }
}
