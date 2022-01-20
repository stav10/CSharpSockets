using System;
using System.Collections.Generic;
using Common;
using Common.Abstractions;
using Common.Convertors;
using Common.IO;
using BL;
using BL.Abstractions;
using BL.Factories;
using ClientUI.Commands;

namespace ClientUI
{
    public class Bootstrapper
    {
        public IExecutable Create(string[] args)
        {
            var factory = new TcpClientUserFactory(args[0], int.Parse(args[1]));
            (IConnectionClient<byte[]> socket, var ip) = factory.Create();
            var client = new Client(socket, ip);
            IOutput output = new ConsoleOutput();
            IInput input = new ConsoleInput();
            IConvertor<string, int> convertor = new StringToIntConvertor();
            var serializer = new Serializer();
            var commandsActions = new Dictionary<CommandType, IExecutable>();
            commandsActions[CommandType.Echo] = new Echo(client, input, output, convertor, serializer);
            IExecutable start = new Start(client, input, output, convertor, serializer, commandsActions);
            return start;
        }
    }
}
