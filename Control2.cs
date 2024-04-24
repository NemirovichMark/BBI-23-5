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
    public Task1(string tex) { text = tex; }
    public override string ToString()
    {
        string[] s = text.Split(' ');
        
        int count = 0;
        for (int i = 0; i < s.Length;i++)
        {
            bool f = true;
            foreach (char c in s[i])
            {
                if (char.IsDigit(c) ) { f = false; break; }
                else if (char.IsPunctuation(c) ) { f = false; break; }
            }
            if (f) { count++; }
        }
        string[] res = new string[count];
        count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            bool f = true;
            foreach (char c in s[i])
            {
                if (char.IsDigit(c)) { f = false; break; }
                else if (char.IsPunctuation(c)) { f = false; break; }
            }
            if (f) { res[count] = s[i];  count++; }
        }
        string result = "";
        for (int i = 0; i < res.Length; i++)
        {
            result += res[i] + " ";
        }
        return result;
    }
}
class Task2 : Task
{
    [JsonConstructor]
    public Task2(string tex) { text = tex; }
    public override string ToString()
    {
        string[] s = text.Split(' ');

        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            bool f = true;
            int k = 0;
            foreach (char c in s[i])
            {
                if (char.IsDigit(c)) { }
                else if (char.IsPunctuation(c)) { }
                else { k++; }
            }
            if (k > 5) { count++; }
        }
        string[] res = new string[count];
        count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            bool f = true;
            int k = 0;
            foreach (char c in s[i])
            {
                if (char.IsDigit(c)) { }
                else if (char.IsPunctuation(c)) { }
                else { k++; }
            }
            if (k > 5) { res[count] = s[i]; count++; }
        }
        string result = "";
        for (int i = 0; i < res.Length; i++)
        {
            result += res[i] + " ";
        }
        return result;
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
            string text = "Мы играли в то самое, что могло бы быть не тем, кто на самом деле делал то, но не это, а когда мы были они, то это было не то пирамида";
            Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };
            Console.WriteLine(tasks[0]);
            Console.WriteLine(tasks[1]);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderName = "Control Work";
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string fileName1 = "cw_task_1.json";
            string fileName2 = "cw_task_2.json";

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