using System.Net.Sockets;
using Common.Abstractions;

namespace BL
{
    public class SocketClient
    {
        private readonly IOutput<string> _output;
        private readonly Socket _socket;

        public SocketClient(IOutput<string> output, Socket socket)
        {
            _output = output;
            _socket = socket;
        }

        public void Recive()
        {

        }
    }
}
