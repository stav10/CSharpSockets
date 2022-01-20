namespace BL.Abstractions
{
    public interface IConnectionServer<T>
    {
        public void Listen();
        public IClient<T> Accept();
    }
}
