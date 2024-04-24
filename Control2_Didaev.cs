using System;
using System.IO;
using System.Text.Json;

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
}

class Task1 : Task
{
    public Task1(string text) : base(text) { }
    public string[] GetLongWords()
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int count = 0;
        foreach (string word in words)
        {
            if (word.Length > 5)
            {
                count++;
            }
        }
        string[] longWords = new string[count];
        int index = 0;
        foreach (string word in words)
        {
            if (word.Length > 5)
            {
                longWords[index++] = word;
            }
        }
        return longWords;
    }
}

class Task2 : Task
{
    public Task2(string text) : base(text) { }
    public double GetCharacterRatio()
    {
        int distinctLettersCount = 0;
        int distinctDigitsAndPunctuationCount = 0;
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                distinctLettersCount++;
            }
            else if (char.IsDigit(c) || char.IsPunctuation(c))
            {
                distinctDigitsAndPunctuationCount++;
            }
        }
        return (double)distinctLettersCount / distinctDigitsAndPunctuationCount;
    }
}

class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, obj);
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
        string text = "Hello students ;)";

        // Task 1
        Task1 task1 = new Task1(text);
        string[] task1Result = task1.GetLongWords();
        Console.WriteLine("Task 1 Result:");
        foreach (string word in task1Result)
        {
            Console.WriteLine(word);
        }

        // Task 2
        Task2 task2 = new Task2(text);
        double task2Result = task2.GetCharacterRatio();
        Console.WriteLine("\nTask 2 Result:");
        Console.WriteLine($"Character Ratio: {task2Result}");

        // Task 3
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Solution");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string task1FilePath = Path.Combine(folderPath, "task_1.json");
        string task2FilePath = Path.Combine(folderPath, "task_2.json");

        if (!File.Exists(task1FilePath))
        {
            JsonIO.Write(task1Result, task1FilePath);
        }

        if (!File.Exists(task2FilePath))
        {
            JsonIO.Write(task2Result, task2FilePath);
        }

        // Task 4
        if (File.Exists(task1FilePath))
        {
            string[] existingTask1Result = JsonIO.Read<string[]>(task1FilePath);
            Console.WriteLine("\nExisting Task 1 Result:");
            foreach (string word in existingTask1Result)
            {
                Console.WriteLine(word);
            }
        }

        if (File.Exists(task2FilePath))
        {
            double existingTask2Result = JsonIO.Read<double>(task2FilePath);
            Console.WriteLine("\nExisting Task 2 Result:");
            Console.WriteLine($"Character Ratio: {existingTask2Result}");
        }
    }
}