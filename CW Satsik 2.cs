using System.Collections.Generic;
using System;
using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.RegularExpressions;

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
    private List<string> answer;
    public List<string> Answer
    {
        get => answer;
    }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        answer = new List<string>();

    }
    private string Solution()
    {
        StringBuilder answer = new StringBuilder();

        // Регулярное выражение для разделения текста по пробелам и знакам препинания
        string[] words = Regex.Split(Text, @"\s+");

        foreach (var word in words)
        {
            bool validWord = true;
            foreach (char c in word)
            {
                if (char.IsPunctuation(c) || char.IsDigit(c))
                {
                    validWord = false;
                    break;
                }
            }
            if (validWord)
            {
                answer.Append(word);
                answer.Append(" ");
            }
        }
        return answer.ToString().Trim();
    }

    public override string ToString()
    {
        return Solution();
    }
    }
class Task2 : Task
{
    private char mostCommonLetter;
    private double mostCommonLetterFrequency;

    public Task2(string text) : base(text)
    {
        mostCommonLetter = ' ';
        mostCommonLetterFrequency = 0;
    }

    public override void Solution()
    {
        int totalLetters = 0;
        int[] letterFrequency = new int[33]; // Массив для хранения частоты каждой буквы в алфавите

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char lowercaseChar = char.ToLower(c);
                int index = lowercaseChar - 'а'; // Получаем индекс буквы в массиве по таблице ASCII
                letterFrequency[index]++;
                totalLetters++;
            }
        }

        // Находим самую часто встречающуюся букву и её частоту в процентах
        double maxFrequencyPercentage = 0;
        for (int i = 0; i < 33; i++)
        {
            double frequencyPercentage = (double)letterFrequency[i] / totalLetters * 100;
            if (frequencyPercentage > maxFrequencyPercentage)
            {
                maxFrequencyPercentage = frequencyPercentage;
                mostCommonLetter = (char)('а' + i); // Преобразуем индекс обратно в символ
                mostCommonLetterFrequency = frequencyPercentage;
            }
        }
    }

    public override string ToString()
    {
        Solution();
        return $"Самая часто встречающаяся буква: {mostCommonLetter}, Частота встречаемости: {mostCommonLetterFrequency}";
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
class Program
    {
        static void Main()
        {
            string text = "Маршрут стартует от Северного речного вокзала и завершается на Южном, теплоход идет по Волге, Оке и Москве-реке. Также через Москву пройдет 30-дневный круиз по Волге, Дону и Каме с посещением 27 городов.";
            Task[] tasks = {
            new Task1(text),
            new Task2(text)
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);
        string path = @"C:\Users\m2305862\Documents";
        string folderName = "Control work";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "cw2_1.json";
        string fileName2 = "cw2_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task1>(fileName1); // Здесь исправлено на Task1
            Console.WriteLine(t1);
        }

        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
        }
        else
        {
            var t2 = JsonIO.Read<Task2>(fileName2); // Здесь также исправлено на Task2
            Console.WriteLine(t2);
        }

    }
}