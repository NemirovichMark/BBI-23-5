using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "";
    public string Text
    {
        get => text;
        protected set => text = value;
    }

    public virtual void Solution() { }
    public Task(string text)
    {
        this.text = text;
    }
}

class Task1 : Task
{
    private List<string> wordsList;

    public Task1(string text) : base(text)
    {
        wordsList = new List<string>();
    }

    public override void Solution()
    {
        string[] words = text.Split(new char[] { ' ', ',', '-', '!', '.', ':', ';', '(', ')', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                wordsList.Add(char.ToUpper(word[0]) + word.Substring(1));
            }
        }
    }

    public override string ToString()
    {
        Solution();
        return string.Join(" ", wordsList);
    }
}

class Task2 : Task
{
    private List<string> answer;

    public List<string> Answer
    {
        get => answer;
    }

    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        answer = new List<string>();
    }

    public override void Solution()
    {
        string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var sentence in sentences)
        {
            string[] words = sentence.Split(new char[] { ' ', ',', '-', '!', '.', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < words.Length; i++)
            {
                string word = words[i];

                if (word.Length > 1 && char.IsUpper(word[0]) && !char.IsUpper(word[1]))
                {
                    answer.Add(word);
                }
            }
        }
    }

    public override string ToString()
    {
        Solution();

        if (answer == null || answer.Count == 0)
        {
            return "";
        }

        return string.Join(",", answer.ToArray());
    }
}


class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializer.Serialize<T>(fs, obj);
        }
    }

    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
    }
}
class Program
{
    static void Main()
    {
        string text = "В конце прошлого года кондитеры предполагали, что отрасль находится на пике кризиса. Однако первый квартал этого года показал — всё только начинается. Цены на сырье из какао-бобов продолжают расти. Поставщики придерживают сырье в надежде дождаться очередного пика. А участники рынка пересматривают свои продуктовые линейки, меняют рецепты и вспоминают разные уловки. Как выжить в кризис, с которым отрасль не сталкивалась последние полвека, и сохранить качественный товар, рассказал основатель кондитерской фабрики «Томер» Андрей Латышев.";
        Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };

        Console.WriteLine("1 task");
        Console.WriteLine(tasks[0]);
        Console.WriteLine("\n2 task");
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2302369\source\repos";
        string folderName = "Answer";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = Path.Combine(path, "cw2_1.json");
        string fileName2 = Path.Combine(path, "cw2_2.json");

        Console.WriteLine("\n3 task");
        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task1>(fileName1);
            Console.WriteLine(t1);
        }

        Console.WriteLine("\n4 task");
        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
        }
        else
        {
            var t2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(t2);
        }

    }
}