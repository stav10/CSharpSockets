using BL.Factories;
using BL.Abstractions;
using System;
using System.Text;
using Common.Abstractions;
using Common.IO;

namespace UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new SocketClientFactory(args[0], int.Parse(args[1]));
            ISocketClient<byte[]> client = factory.Create();
            IOutput output = new ConsoleOutput();
            IInput<string> input = new ConsoleInput();
            while (true)
            {
                string message = input.Read();
                client.Send(Encoding.UTF8.GetBytes(message));
                byte[] buffer = client.Receive();
                string response = Encoding.UTF8.GetString(buffer);
                output.Print(response);
            }
        }
    }
}
