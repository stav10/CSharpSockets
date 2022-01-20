using System.Net;

namespace BL.Abstractions
{
    public interface IConnectionServer<T>
    {
        public void Bind(EndPoint endPoint);
        public void Listen();
        public IClient<T> Accept();
    }
}
