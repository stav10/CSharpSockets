using Common.Abstractions;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Common
{
    public class Serializer<T> : ISerializer<T, byte[]>
    {
        public byte[] Desrialize(T instance)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, instance);
                return ms.ToArray();
            }
        }

        public T Serialize(byte[] buffer)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(buffer, 0, buffer.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return (T)obj;
            }
        }
    }
}
