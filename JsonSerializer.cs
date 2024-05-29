namespace ConsoleApplication1
{
    using System.IO;
    using Newtonsoft.Json;

    public interface IJsonSerializable
    {
        void SerializeToFile<T>(T obj, string filePath);
        T DeserializeFromFile<T>(string filePath);
    }

    public class JsonSerializer : IJsonSerializable
    {
        public void SerializeToFile<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public T DeserializeFromFile<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

}
