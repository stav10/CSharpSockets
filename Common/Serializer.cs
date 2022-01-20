using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Reflection;
using Common.Abstractions;

namespace Common
{
    public class Serializer<T> : ISerializer<T, byte[]>
    {
        public byte[] Desrialize(T instance)
        {
            IEnumerable<FieldInfo> fields = GetInstanceFields(instance.GetType());
            foreach (var item in fields)
            {
                Console.WriteLine(fields);
            }
            var dict = fields.ToDictionary(field => field.Name, field => field.GetValue(instance));
            var bytes = JsonSerializer.SerializeToUtf8Bytes(dict);
            return bytes;
        }

        public T Serialize(byte[] value)
        {
            var json = JsonSerializer.Deserialize<IDictionary<string, JsonElement>>(value);
            Console.WriteLine(json.Values.Count);
            foreach (var item in json.Values)
            {
                Console.WriteLine(item);
            }
            var fields = GetInstanceFields(typeof(T));
            var test = new List<object>();
            for (int i = 0; i < json.Values.Count; i++)
            {
                var a = ToObject<dynamic> (json.Values.ToArray()[i]);
                test.Add(a);
            }
            foreach (var item in test)
            {
                Console.WriteLine(item.GetType());
            }
            ConstructorInfo ci = typeof(T).GetConstructors()[0];
            return (T)(ci?.Invoke(test.ToArray()));
        }

        private IEnumerable<FieldInfo> GetInstanceFields(Type type)
        {
            BindingFlags bindFlags = BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
            IEnumerable<FieldInfo> fields = type.GetRuntimeFields();
            return fields;
        }

        private K ToObject<K>(JsonElement element)
        {
            var json = element.GetRawText();
            return JsonSerializer.Deserialize<K>(json);
        }
    }
}
