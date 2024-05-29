using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Serializers
{
    public abstract class MySerializer
    {
        public abstract void Write<T>(T obj, string path);
        public abstract T Read<T>(string path);
    }

    public class MyJsonSerializer : MySerializer
    {
        public override void Write<T>(T obj, string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(path, jsonString);
        }

        public override T Read<T>(string path)
        {
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }

    public class MyXmlSerializer : MySerializer
    {
        public override void Write<T>(T obj, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public override T Read<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(path))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
