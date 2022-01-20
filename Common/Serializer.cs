using Common.Abstractions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public class Serializer : ISerializer<object, byte[]>
    {
        public byte[] Desrialize(object instance)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream();
            bf.Serialize(ms, instance);
            return ms.ToArray();
        }

        public object Serialize(byte[] buffer)
        {
            using var memStream = new MemoryStream();
            var binForm = new BinaryFormatter();
            memStream.Write(buffer, 0, buffer.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = binForm.Deserialize(memStream);
            return obj;
        }
    }
}
