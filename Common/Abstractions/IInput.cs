namespace Common.Abstractions
{
    public interface IInput<T>
    {
        public T Read();
    }
}
