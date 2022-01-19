using BL.Abstractions;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BL
{
    public class SocketServer: ISocketServer
    {
        private readonly Socket _server;

        public SocketServer(Socket socket, IPEndPoint ipEndPoint)
        {
            _server = socket;
            _server.Bind(ipEndPoint);
        }

        public void Start()
        {
            _server.Listen();
            while (true)
            {
                ISocketClient<byte[]> client = new SocketClient(_server.Accept());
                var t = new Task(() => HandleClient(client));
                t.Start();
            }
        }

        private void HandleClient(ISocketClient<byte[]> client)
        {
            while (true)
            {
                var buffer = client.Receive();
                client.Send(buffer);
            }
        }
    }
}
