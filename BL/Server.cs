using System.Threading.Tasks;
using BL.Abstractions;

namespace BL
{
    public class Server : IServer
    {
        private readonly IConnectionServer<byte[]> _server;

        public Server(IConnectionServer<byte[]> socket)
        {
            _server = socket;
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
