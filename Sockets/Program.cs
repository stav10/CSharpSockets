using Common.Abstractions;

namespace ClientUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            IExecutable start = bootstrapper.Create(args);
            start.Execute();
        }
    }
}
