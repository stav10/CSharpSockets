namespace BL.Abstractions
{
    public interface IConvertor
    {
        public K TryConvert<T, K>(T input, K output, out bool success);
    }
}
