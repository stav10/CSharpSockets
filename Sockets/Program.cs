using BL;
using BL.Abstractions;
using BL.Factories;
using Common;
using Common.Abstractions;
using Common.IO;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new TcpClientUserFactory(args[0], int.Parse(args[1]));
            (IConnectionClient<byte[]> socket, var ip) = factory.Create();
            var client = new Client(socket, ip);
            IOutput output = new ConsoleOutput();
            IInput<string> input = new ConsoleInput();
            var serializer = new Serializer();
            while (true)
            {
                output.Print("Please enter the person's name");
                string name = input.Read();
                output.Print("Please enter the person's age");
                string message = input.Read();
                client.Send(serializer.Desrialize(message));
                byte[] buffer = client.Receive();
                object response = serializer.Serialize(buffer);
                output.Print(response);
            }
        }
    }
}
