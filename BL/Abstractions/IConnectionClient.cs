using System.Net;

namespace BL.Abstractions
{
    public interface IConnectionClient<T>
    {
        public void Connect(EndPoint ipEndPoint);
        public void Send(T buffer);
        public int Receive(T buffer);
    }
}
