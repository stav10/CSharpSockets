using System;
using System.Net.Sockets;
using Common.Abstractions;

namespace BL
{
    public class SocketClient
    {
        private readonly IOutput<string> _output;
        private readonly IInput<string> _input;
        private readonly Socket _socket;

        public SocketClient(IInput<string> input, IOutput<string> output, Socket socket)
        {
            _input = input;
            _output = output;
            _socket = socket;
        }

        public void Recive()
        {

        }

        public void Send()
        {
            string message = _input.Read();
            _output.Print(message);
        }
    }
}
