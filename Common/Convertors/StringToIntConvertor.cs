using Common.Abstractions;

namespace Common.Convertors
{
    public class StringToIntConvertor : IConvertor<string, int>
    {
        public bool TryConvert(string input, out int output)
        {
            return int.TryParse(input, out output);
        }
    }
}
