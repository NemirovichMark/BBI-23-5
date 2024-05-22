using System.Text.Json;
using System.Text.Json.Serialization;
abstract class Task
{
    protected string text = "No text";
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    [JsonConstructor]
    public Task()
    {
    }
}
class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) { this.text = text; }
    public override string ToString()
    {
        string[] s = text.Split(' ');
        List<string> word = new List<string>();
        List<string> result = new List<string>();
        for (int i = 0; i < s[0].Length; i++)
        {
            if (!word.Contains(char.ToLower(s[0][i]).ToString()))
            {
                word.Add(char.ToLower(s[0][i]).ToString());
            }
        }
        for (int i = 0; i < s[1].Length; i++)
        {
            if (!result.Contains(char.ToLower(s[1][i]).ToString()) && word.Contains(char.ToLower(s[1][i]).ToString()))
            {
                result.Add(char.ToLower(s[1][i]).ToString());
            }
        }
        return string.Join(",", result);
    }
}
class Task2 : Task
{
    [JsonConstructor]
    public Task2(string text) { this.text = text; }
    public override string ToString()
    {
        string[] s = text.Split(' ');
        float k = 0;
        List<string> g = new List<string> { "у", "е", "ё", "ы", "а", "о", "э", "я", "и", "ю" };
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < s[i].Length; j++)
            {
                if (g.Contains(char.ToLower(s[i][j]).ToString())) { k += 1; }
            }
        }
        return (k / s.Length).ToString();
    }
}
class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
}

    class Control2
    {
        static void Main()
        {
            string text = "Давайте будем вместе петь, тогда поговорим";
            Task[] tasks = { new Task1("автОмобиль мотор"), new Task2(text)};
            Console.WriteLine(tasks[0]);
            Console.WriteLine(tasks[1]);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string folderName = "Solution";
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName1 = "task_1.json";
            string fileName2 = "task_2.json";

            fileName1 = Path.Combine(path, fileName1);
            fileName2 = Path.Combine(path, fileName2);

            if (!File.Exists(fileName2))
            {
                JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
                JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
            }
            else
            {
                var t1 = JsonIO.Read<Task1>(fileName1);
                var t2 = JsonIO.Read<Task2>(fileName2);
                Console.WriteLine(t1);
                Console.WriteLine(t2);
            }
        }
    }