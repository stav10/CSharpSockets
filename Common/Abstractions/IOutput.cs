namespace Common.Abstractions
{
    public interface IOutput<T>
    {
        public void Print(params T [] values);
    }
}
