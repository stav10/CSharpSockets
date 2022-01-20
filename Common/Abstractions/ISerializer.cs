namespace Common.Abstractions
{
    public interface ISerializer<T, K>
    {
        public T Serialize(K value);
        public K Desrialize(T value);
    }
}
