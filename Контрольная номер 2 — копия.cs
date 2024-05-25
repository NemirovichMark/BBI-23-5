using System;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "No text here yet";
   
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
    public virtual void reshenie() { }
}

class Task1 : Task
{
   
    private string answer;
    public string Answer
    {
        get => answer;
    }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        answer = "";
    }

    public override void reshenie()
    {
        var distinctChars = text.Where(c => text.Count(x => x == c) == 1);
        answer = string.Join(", ", distinctChars);
    }

    public override string ToString()
    {
        reshenie();
        return answer;
    }
}
class Task2 : Task
{
    private string answer;
    public string Answer
    {
        get => answer;
    }

    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        answer = "";
    }

    public override void reshenie()
    {
        string[] sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
        StringBuilder reversedText = new StringBuilder();

        foreach (string sentence in sentences)
        {
            string[] words = sentence.Split(' ');
            Array.Reverse(words);

            foreach (string word in words)
            {
                reversedText.Append(word).Append(" ");
            }
            reversedText.Length--; 
            reversedText.Append(sentence.Substring(sentence.Length - 1, 1)).Append(" "); 
        }

        answer = reversedText.ToString().Trim();
    }

    public override string ToString()
    {
        reshenie();
        return answer;
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
    }
}

class Program
{
    static void Main()
    {

        Task[] tasks = {
            new Task1("Сижу я решаю это контрольную, а так хочеться на море, в Испанию, напимер"),   
            new Task2("Я все сдам успешно, я в себя верю, хоть мне и страшно!")
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);


        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string mainDir = Path.Combine(desktopPath, "Задание");
        string answerDir = Path.Combine(mainDir, "Ответ");
        string loadedDir = Path.Combine(answerDir, "Загружены");


      

        string jsonFilePath1 = Path.Combine(loadedDir, "cw_task_1.json");
        string jsonFilePath2 = Path.Combine(loadedDir, "cw_task_2.json");


       

        Console.WriteLine(JsonSerializer.Serialize(tasks[0] as Task1));
        Console.WriteLine(JsonSerializer.Serialize(tasks[1] as Task2));
    }
}







