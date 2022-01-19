namespace UI.Abstractions
{
    public interface IOutput
    {
        public void Print<T>(params T[] values);
    }
}
