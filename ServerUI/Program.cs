using BL;
using BL.Factories;
using BL.Abstractions;


namespace ServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new SocketServerFactory(int.Parse(args[0]));
            IConnectionServer<byte[]> socket = factory.Create();
            IServer server = new Server(socket);
            server.Start();
        }
    }
}
