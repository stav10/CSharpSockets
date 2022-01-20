using System;
using System.IO;
using System.Net.Sockets;
using Common;
using Common.Abstractions;
using Common.Convertors;
using Common.IO;
using BL;
using BL.Abstractions;
using BL.Factories;

namespace ClientUI
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
                var commands = Enum.GetValues(typeof(CommandType));
                while (true)
                {
                    output.Print("Enter your command:");
                    for (int i = 0; i < commands.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}: {commands.GetValue(i)}");
                    }
                    input.TryRead(convertor, out int commandIndex);
                    Console.WriteLine($"selected: {commandIndex}");
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
