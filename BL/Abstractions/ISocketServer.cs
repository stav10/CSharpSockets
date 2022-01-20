namespace BL.Abstractions
{
    public interface ISocketServer<T> : IConnectionServer<T>, IBindable
    {
    }
}
