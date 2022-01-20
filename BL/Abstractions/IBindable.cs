using System.Net;

namespace BL.Abstractions
{
    public interface IBindable
    {
        public void Bind(EndPoint endPoint);
    }
}
