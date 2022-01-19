using BL.Factories;
using BL.Abstractions;
using System;
using System.Text;
using UI.Abstractions;
using UI.IO;

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
                string response = BitConverter.ToString(buffer);
                output.Print(response);
            }
        }
    }
}
