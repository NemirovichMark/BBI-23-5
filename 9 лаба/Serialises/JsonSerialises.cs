using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class serialisation
{
    public static void serilase_file(students[] students, string path_file)
    {
        List<students> list = new List<students>();

        if (File.Exists(path_file)) list.AddRange(deserilase_file(path_file));

        list.AddRange(students);

        using (StreamWriter file = File.CreateText(path_file))
        {
            JsonSerializer serializer = new JsonSerializer(); //создали экземпляр класса
            serializer.Serialize(file, list);
        }
    }
    public static List<students> deserilase_file(string path_file)
    {
        List<students> students = new List<students>();
        using (StreamReader file = File.OpenText(path_file))
        {
            JArray a = JArray.Parse(file.ReadToEnd()); //json-массив
            foreach (var i in a)
            {
                students.Add(item: i.ToObject<maths>());
            }
        }
        return students;
    }
}
public class json_serialisation : serialisation
{
    public static void serilase_to_json(students[] students, string path_file)
    {
        serilase_file(students, path_file);
    }
    public static List<students> deserilase_to_json(string path_file)
    {
        return deserilase_file(path_file);
    }
}
