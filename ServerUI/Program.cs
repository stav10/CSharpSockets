using BL.Factories;
using BL.Abstractions;


namespace ServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new SocketServerFactory(int.Parse(args[0]));
            ISocketServer server = factory.Create();
            server.Start();
        }
    }
}
