using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using Common.Abstractions;
using BL.Abstractions;

namespace ClientUI.Commands
{
    public class Start : IExecutable
    {
        private readonly IClient<byte[]> _client;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IConvertor<string, int> _convertor;
        private readonly ISerializer<object, byte[]> _serializer;
        private readonly IDictionary<CommandType, IExecutable> _commands;

        public Start(
                IClient<byte[]> client,
                IInput input,
                IOutput output,
                IConvertor<string, int> convertor,
                ISerializer<object, byte[]> serializer,
                IDictionary<CommandType, IExecutable> commands)
        {
            _client = client;
            _input = input;
            _output = output;
            _convertor = convertor;
            _serializer = serializer;
            _commands = commands;
        }

        public void Execute()
        {
            try
            {

                while (true)
                {
                    _output.Print("Enter your command:");
                    var keys = new CommandType[_commands.Keys.Count];
                    _commands.Keys.CopyTo(keys, 0);
                    for (int i = 0; i < _commands.Keys.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {keys[i]}");
                    }
                    _input.TryRead(_convertor, out int commandIndex);
                    _commands[(CommandType)(commandIndex - 1)].Execute();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
