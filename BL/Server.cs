using BL.Abstractions;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BL
{
    public class Server  : IServer
    {
        private readonly IConnectionServer<byte[]> _server;

        public Server(IConnectionServer<byte[]> socket)
        {
            _server = socket;
        }

        public Server(IConnectionServer<byte[]> socket, IPEndPoint ipEndPoint)
        {
            _server = socket;
            _server.Bind(ipEndPoint);
        }

        public void Start()
        {
            _server.Listen();
            while (true)
            {
                IClient<byte[]> client = _server.Accept();
                var t = new Task(() => HandleClient(client));
                t.Start();
            }
        }

        private void HandleClient(IClient<byte[]> client)
        {
            while (true)
            {
                var buffer = client.Receive();
                client.Send(buffer);
            }
        }
    }
}
