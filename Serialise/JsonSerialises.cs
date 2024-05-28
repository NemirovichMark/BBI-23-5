using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class serialisation
{
    public static void serilase_file<T>(IEnumerable<T>objects, string path_file)
    {
        string json = JsonConvert.SerializeObject(objects);
        File.WriteAllText(path_file, json);
    }
    public static List<T> deserilase_file<T>(string path_file)
    {
        List<T> values = new List<T>();
        string json = File.ReadAllText(path_file);
        JArray a = JArray.Parse(json);
        foreach (var i in a)
        {
            T item = i.ToObject<T>();
            values.Add(item);
        }
        return values;
    }
}
public class json_serialisation : serialisation
{
    public static void serilase_to_json<T>(IEnumerable<T> objects, string path_file)
    {
        serilase_file(objects, path_file);
    }
    public static List<T> deserilase_to_json<T>(string path_file)
    {
        return deserilase_file<T>(path_file);
    }
}
