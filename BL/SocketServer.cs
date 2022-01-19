using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BL
{
    public class SocketServer
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
                Socket client = _server.Accept();
                Task t = new Task(() => HandleClinet(client));
                t.Start();
            }
        }

        private void HandleClinet(Socket client)
        {

        }
    }
}
