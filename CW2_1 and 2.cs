using System;
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

    
    public abstract object Execute();
}

class Task1 : Task
{
    [JsonConstructor]
    public Task1(string text) : base(text) { }

    public override object Execute()
    {
       
        char[] delimiters = new char[] { ' ', '.', ',', ';', ':', '!', '?', '-', '_', '(', ')', '[', ']', '{', '}', '\"', '\'', '\n', '\r', '\t' };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        
        if (words.Length == 0)
        {
            return 0.0;
        }

       
        int totalLength = words.Sum(word => word.Length);

        
        int wordCount = words.Length;

       
        return (double)totalLength / wordCount;
    }

    public override string ToString()
    {
        return $"Средняя длина слов: {Execute():F2}";
    }
}

class Task2 : Task
{
    private int amount = 1;
    public int Amount
    {
        get => amount;
        private set => amount = value;
    }

    [JsonConstructor]
    public Task2(string text, int amount = 0) : base(text)
    {
        this.amount = amount;
    }

    public override object Execute()
    {
       
        return 0.0;
    }

    public override string ToString()
    {
        return amount.ToString();
    }
}

class Task3 : Task
{
    private static string rusAlphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    private static string rusAlphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

    [JsonConstructor]
    public Task3(string text) : base(text) { }

    public override object Execute()
    {
        char ShiftChar(char c, int shift)
        {
            if (char.IsLower(c) && rusAlphabetLower.Contains(c))
            {
                int index = (rusAlphabetLower.IndexOf(c) + shift) % rusAlphabetLower.Length;
                return rusAlphabetLower[index];
            }
            else if (char.IsUpper(c) && rusAlphabetUpper.Contains(c))
            {
                int index = (rusAlphabetUpper.IndexOf(c) + shift) % rusAlphabetUpper.Length;
                return rusAlphabetUpper[index];
            }
            else
            {
                return c; 
            }
        }

        int shift = 5;
        var result = new string(text.Select(c => ShiftChar(c, shift)).ToArray());
        return result;
    }

    public override string ToString()
    {
        return $"Сдвинутый текст: {Execute()}";
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
            new Task1("Это пример предложения для вычисления средней длины слов."), 
            new Task2("Example", 25),    
            new Task3("Пример текста для сдвига букв")  
        };

      
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }

        string path = @"C:\Users\b804\Documents"; // исходную папку ищем в компьютере
        string folderName = "Solution"; // если нужно создать подпапку
        path = Path.Combine(path, folderName);

        string fileName1 = "cw_2_task_1.json"; // имена файлов
        string fileName2 = "cw_2_task_2.json";
        string fileName3 = "cw_2_task_3.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        fileName3 = Path.Combine(path, fileName3);


        JsonIO.Write((Task1)tasks[0], fileName1);
        JsonIO.Write((Task2)tasks[1], fileName2);
        JsonIO.Write((Task3)tasks[2], fileName3);

        Task1 deserializedTask1 = JsonIO.Read<Task1>(fileName1);
        Task2 deserializedTask2 = JsonIO.Read<Task2>(fileName2);
        Task3 deserializedTask3 = JsonIO.Read<Task3>(fileName3);

        Console.WriteLine(deserializedTask1);
        Console.WriteLine(deserializedTask2);
        Console.WriteLine(deserializedTask3);
    }
}