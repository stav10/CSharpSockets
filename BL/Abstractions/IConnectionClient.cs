using System.Net;

namespace BL.Abstractions
{
    public interface IConnectionClient<T>
    {
        public void Send(T buffer);
        public int Receive(T buffer);
        public void Connect(EndPoint ipEndPoint);
    }
}
