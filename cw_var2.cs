using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    public abstract override string ToString();
}

class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { }

    public override string ToString()
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string maxSentence = sentences.OrderByDescending(s => s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length).FirstOrDefault();
        return maxSentence?.Trim() ?? string.Empty;
    }
}

class Task2 : Task
{
    public int WordsCount { get; }

    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        WordsCount = Count();
    }

    private int Count()
    {
        string[] words = text.Split(new char[] { ' ', '.', '!', '?', ',', ';', ':', '-', '_', '(', ')', '[', ']', '{', '}', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
        HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            uniqueWords.Add(word);
        }

        return uniqueWords.Count;

    }

    public override string ToString()
    {
        return WordsCount.ToString();
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
        string text1 = "Здравствуйте! Меня зовут Лиза. Я очень сильно люблю информатику и программирование.";
        string text2 = "Я Лиза. Лиза это я. Мама решила назвать меня Лиза и я этому рада.";

        Task[] tasks = {
            new Task1(text1),
            new Task2(text2)
        };

        Console.WriteLine(tasks[0].ToString());
        Console.WriteLine(tasks[1].ToString());

        string path = @"C:\Users\m2400038\Downloads";
        string folderName = "Control work";
        path = Path.Combine(path, folderName);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);

        if (!File.Exists(fileName1))
        {
            JsonIO.Write(tasks[0] as Task1, fileName1);
        }

        if (!File.Exists(fileName2))
        {
            JsonIO.Write(tasks[1] as Task2, fileName2);
        }
        else
        {
            var t1 = JsonIO.Read<Task1>(fileName1);
            var t2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
        }
    }
}