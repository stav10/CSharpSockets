using System.IO;
using System.Net.Sockets;
using Common;
using Common.Abstractions;
using Common.Convertors;
using Common.IO;
using BL;
using BL.Abstractions;
using BL.Factories;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var factory = new TcpClientUserFactory(args[0], int.Parse(args[1]));
                (IConnectionClient<byte[]> socket, var ip) = factory.Create();
                var client = new Client(socket, ip);
                IOutput output = new ConsoleOutput();
                IInput input = new ConsoleInput();
                IConvertor<string, int> convertor = new StringToIntConvertor();
                var serializer = new Serializer();
                while (true)
                {
                    output.Print("Please enter the person's name");
                    string name = input.ReadString();
                    output.Print("Please enter the person's age");
                    bool isConverted = input.TryRead(convertor, out int age);
                    if (isConverted)
                    {
                        var person = new Person(name, age);
                        client.Send(serializer.Desrialize(person));
                        byte[] buffer = client.Receive();
                        object response = serializer.Serialize(buffer);
                        output.Print(response);
                    }
                }
            }
            catch (SocketException e)
            {
                System.Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
