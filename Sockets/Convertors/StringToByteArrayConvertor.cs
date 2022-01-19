using BL.Abstractions;
using System.Text;

namespace BL.Convertors
{
    public class StringToByteArrayConvertor : IConvertor<string, byte[]>
    {
        public bool TryConvert(string input, out byte[] output)
        {
            try
            {
                output = Encoding.UTF8.GetBytes(input);
                return true;
            }
            catch
            {
                output = null;
                return false;
            }
        }
    }
}
