using System.Net;

namespace BL.Abstractions
{
    public interface IClient<T>
    {
        public void Send(T buffer);
        public T Receive();
    }
}
