using System.Net;

namespace BL.Abstractions
{
    public interface ISocketServer
    {
        public void Bind(EndPoint endPoint);
        public void Listen();
        public ISocketClient<byte[]> Accept();
    }
}
