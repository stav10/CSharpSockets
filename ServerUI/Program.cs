using BL;
using BL.Abstractions;
using BL.Factories;


namespace ServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new TcpServerFactory(int.Parse(args[0]));
            var socket = factory.Create();
            IServer server = new Server(socket);
            server.Start();
        }
    }
}
