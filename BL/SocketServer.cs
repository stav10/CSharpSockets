using System;
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
                Task t = new Task(() => HandleClient(client));
                t.Start();
            }
        }

        private void HandleClient(Socket client)
        {
            var lengthChunk = new byte[4];
            client.Receive(lengthChunk);
            int length = BitConverter.ToInt32(lengthChunk);
            var buffer = new byte[length];
            client.Receive(buffer, 4, length, SocketFlags.None);
            client.Send(lengthChunk);
            client.Send(buffer);
        }
    }
}
