namespace Common.Abstractions
{
    public interface IConvertor<T, K>
    {
        public bool TryConvert(T input, out K output);
    }
}
