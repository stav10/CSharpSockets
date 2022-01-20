using Common.Abstractions;
using BL.Abstractions;

namespace ClientUI.Commands
{
    public class Echo : IExecutable
    {
        private readonly IClient<byte[]> _client;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly IConvertor<string, int> _convertor;
        private readonly ISerializer<object, byte[]> _serializer;

        public Echo(
                IClient<byte[]> client, 
                IInput input, 
                IOutput output, 
                IConvertor<string, int> convertor, 
                ISerializer<object, byte[]> serializer)
        {
            _client = client;
            _input = input;
            _output = output;
            _convertor = convertor;
            _serializer = serializer;
        }

        public void Execute()
        {
            _output.Print("Please enter the person's name");
            string name = _input.ReadString();
            _output.Print("Please enter the person's age");
            bool isConverted = _input.TryRead(_convertor, out int age);
            if (isConverted)
            {
                var person = new Person(name, age);
                _client.Send(_serializer.Desrialize(person));
                byte[] buffer = _client.Receive();
                object response = _serializer.Serialize(buffer);
                _output.Print(response);
            }
        }
    }
}
