using System.Net.Sockets;
using Common.Abstractions;
using BL.Abstractions;

namespace BL
{
    public class SocketClient
    {
        private readonly IOutput _output;
        private readonly IInput<string> _input;
        private IConvertor<string, byte[]> _convertor;
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
            var buffer = new byte [1024];
            _socket.Receive(buffer);
            _output.Print(buffer);
        }

        public void Send()
        {
            string message = _input.Read();
            bool isSucceeded = _convertor.TryConvert(message, out byte[] buffer);
            if (isSucceeded)
            {
                _socket.Send(buffer);
            }
        }
    }
}
