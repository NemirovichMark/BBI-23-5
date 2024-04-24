using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

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
    public abstract object Solve();
}
class Task1 : Task
{
    public Task1(string text) : base(text) { }
    public override object Solve()
    {
        int[] counts = new int[4]; // буквы, цифры, пунктуационные знаки, пробелы

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                counts[0]++;
            }
            else if (char.IsDigit(c))
            {
                counts[1]++;
            }
            else if (char.IsPunctuation(c))
            {
                counts[2]++;
            }
            else if (char.IsWhiteSpace(c))
            {
                counts[3]++;
            }
        }
        return counts;
    }
}
  
class Task2 : Task
{
    public Task2(string text) : base(text) { }
    public override object Solve()     
    {
        string[] sentences = text.Split('.').Select(s => s.Trim()).ToArray();

        for (int i = 0; i < sentences.Length; i++)
        {
            string[] words = sentences[i].Split(' ');

            int longestWordIndex = 0;
            int longestWordLength = 0;

            int shortestWordIndex = 0;
            int shortestWordLength = 30;

            for (int j = 0; j < words.Length; j++)
            {
                int wordLength = words[j].Length;
                if (wordLength > longestWordLength)//находим самое длинное
                {
                    longestWordIndex = j;
                    longestWordLength = wordLength;
                }
                if (wordLength < shortestWordLength)//находим самое короткое
                {
                    shortestWordIndex = j;
                    shortestWordLength = wordLength;
                }
            }
            //меняем местами
            string temp = words[longestWordIndex];
            words[longestWordIndex] = words[shortestWordIndex];
            words[shortestWordIndex] = temp;

            sentences[i] = string.Join(" ", words) + ".";
        }
        return string.Join(" ", sentences);
    }
}



class Program
{
    static void Main()
    {
        string text = "Объектно ориентированное программирование — методология на основе описания моделей и их взаимодействия. Мне нравится программировать, но 100% возникнут трудности. С ними я пытаюсь справиться. Сегодня я очень старалась.";

        Task task1 = new Task1(text);
        int[] result1 = (int[])task1.Solve();

        Task task2 = new Task2(text);
        string result2 = (string)task2.Solve();

        Console.WriteLine($"Задача 1: {string.Join(", ", result1)}");
        Console.WriteLine($"Задача 2: {result2}");

        Task[] tasks = { new Task1(""), new Task2("") };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);
        string path = @"C:\Users\m2310785\Documents"; 
        string folderName = "Test"; 
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))    
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json"; 
        string fileName2 = "task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
    }
}
    