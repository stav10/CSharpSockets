using System.Text;
using System.Net.Sockets;
using Common.Abstractions;

namespace BL
{
    public class SocketClient
    {
        private readonly IOutput _output;
        private readonly IInput<string> _input;
        private readonly Socket _socket;

        public SocketClient(IInput<string> input, IOutput output, Socket socket)
        {
            _input = input;
            _output = output;
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
            _socket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
