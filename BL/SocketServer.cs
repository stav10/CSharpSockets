using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using BL.Abstractions;

namespace BL
{
    public class SocketServer
    {
        private readonly ISocketServer _server;

        public SocketServer(ISocketServer socket, IPEndPoint ipEndPoint)
        {
            _server = socket;
            _server.Bind(ipEndPoint);
        }

        public void Start()
        {
            _server.Listen();
            while (true)
            {
                ISocketClient<byte[]> client = _server.Accept();
                var t = new Task(() => HandleClient(client));
                t.Start();
            }
        }

        private void HandleClient(ISocketClient<byte[]> client)
        {
            var buffer = client.Receive();
            client.Send(buffer);
        }
    }
}
