namespace Common.Abstractions
{
    public interface IInput
    {
        public string ReadString();
        public bool TryRead<T>(IConvertor<string, T> convertor, out T value);
    }
}
