namespace BL.Abstractions
{
    public interface ISocketClient<T>
    {
        public void Send(T value);
        public T Receive();
    }
}
