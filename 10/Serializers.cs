using System.Text.Json;
using System.Xml.Serialization;
using ProtoBuf;

public abstract class MySerializer
{
    public abstract void Write<T>(T obj, string path);
    public abstract T Read<T>(string path);
}

public class MyJsonSerializer : MySerializer
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    public override void Write<T>(T obj, string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj, options);
        }
    }
    public override T Read<T>(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
    }
}

public class MyXmlSerializer : MySerializer
{
    public override void Write<T>(T obj, string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            new XmlSerializer(typeof(T)).Serialize(fs, obj);
        }
    }
    public override T Read<T>(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(fs);
        }
    }
}


public class MyBinarySerializer : MySerializer
{
    public override void Write<T>(T obj, string path)
    {
        Serializer.PrepareSerializer<IPlatform>();
        Serializer.PrepareSerializer<IConsoleable>();
        Serializer.PrepareSerializer<IComputerable>();
        Serializer.PrepareSerializer<IMobile>();
        Serializer.PrepareSerializer<IGameCatalog>();    
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            Serializer.Serialize(fs, obj);
        }
    }
    public override T Read<T>(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            return Serializer.Deserialize<T>(fs);
        }
    }
}