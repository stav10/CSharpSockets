using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Common.Abstractions;

namespace Common
{
    class Serializer : ISerializer<object, byte[]>
    {
        public byte[] Desrialize(object value)
        {
            throw new NotImplementedException();
        }

        public object Serialize(byte[] value)
        {
            throw new NotImplementedException();
        }
    }
}
