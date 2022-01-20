using BL;
using BL.Abstractions;
using BL.Factories;
using Common;
using Common.Abstractions;
using Common.IO;
using System.Text;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new SocketClientFactory(args[0], int.Parse(args[1]));
            (IConnectionClient<byte[]> socket, var ip) = factory.Create();
            var client = new Client(socket, ip);
            IOutput output = new ConsoleOutput();
            IInput<string> input = new ConsoleInput();
            var serializer = new Serializer<Person>();
            while (true)
            {
                int age = int.Parse(input.Read());
                string name = input.Read();
                var person = new Person(name, age);
                client.Send(serializer.Desrialize(person));
                byte[] buffer = client.Receive();
                Person response = serializer.Serialize(buffer);
                output.Print(response);
            }
        }
    }
}
