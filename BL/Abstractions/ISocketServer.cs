namespace BL.Abstractions
{
    public interface ISocketServer
    {
        public void Bind();
        public void Listen();
        public ISocketClient<byte[]> Accept();
    }
}
