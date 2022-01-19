namespace UI.Abstractions
{
    public interface IInput<T>
    {
        public T Read();
    }
}
