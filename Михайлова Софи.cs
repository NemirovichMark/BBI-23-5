using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        char mostFrequentChar = FindMostFrequentChar(text);
        double frequency = CalculateFrequency(text, mostFrequentChar);

        Console.WriteLine($"Самая часто встречающаяся буква: {mostFrequentChar}");
        Console.WriteLine($"Частота вхождения: {frequency}");
    }

    public static char FindMostFrequentChar(string text)
    {
        text = text.ToLower();

        Dictionary<char, int> charFrequency = new Dictionary<char, int>();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                if (charFrequency.ContainsKey(c))
                {
                    charFrequency[c]++;
                }
                else
                {
                    charFrequency[c] = 1;
                }
            }
        }

        char mostFrequentChar = charFrequency.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

        return mostFrequentChar;
    }

    public static double CalculateFrequency(string text, char targetChar)
    {
        text = text.ToLower();
        targetChar = char.ToLower(targetChar);

        int charCount = text.Count(c => c == targetChar);

        double frequency = (double)charCount / text.Length;

        return frequency;
    }
}








using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string inputText = Console.ReadLine();
        string[] words = Regex.Split(inputText, @"(\W+)");// Постаралась разбить текст на слова, используя регулярное выражение для поиска слов
        Console.WriteLine("Результат:");
        for (int i = 0; i < words.Length; i++)
        {
            if (Regex.IsMatch(words[i], @"\w+"))
            {
                char[] characters = words[i].ToCharArray();
                Array.Reverse(characters);
                string reversedWord = new string(characters);
                Console.Write(reversedWord);
            }
            else
            {
                Console.Write(words[i]);
            }
        }

        Console.ReadLine();
    }
}








using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\m2301436\Desktop\m2301436@edu.misis.ru\Control work";
        string filePath1 = Path.Combine(directoryPath, "cw2_1.json");
        string filePath2 = Path.Combine(directoryPath, "cw2_2.json");

        try
        {
            // Проверяю, существует ли уже папка "Control work"
            if (!Directory.Exists(directoryPath))
            {
                // Создала папку "Control work", если она не существует
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Папка 'Control work' успешно создана.");
            }
            else
            {
                Console.WriteLine("Папка 'Control work' уже существует.");
            }

            // Проверяю, существует ли уже файлы cw2_1.json и cw2_2.json
            if (!File.Exists(filePath1))
            {
                // Создала файл cw2_1.json, если он не существует
                File.Create(filePath1).Close();
                Console.WriteLine("Файл 'cw2_1.json' успешно создан.");
            }
            else
            {
                Console.WriteLine("Файл 'cw2_1.json' уже существует.");
            }

            if (!File.Exists(filePath2))
            {
                // Создала файл cw2_2.json, если он не существует
                File.Create(filePath2).Close();
                Console.WriteLine("Файл 'cw2_2.json' успешно создан.");
            }
            else
            {
                Console.WriteLine("Файл 'cw2_2.json' уже существует.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}












using System;
using System.IO;
using System.Text.Json;

class Program
{
    class TaskData
    {
        public string Task { get; set; }
        public string Deadline { get; set; }
    }
    static void SaveToJson(TaskData data, string filename) // Функция для сохранения данных в файл JSON

    {
        string jsonData = JsonSerializer.Serialize(data);
        File.WriteAllText(filename, jsonData);
    }
    static TaskData ReadFromJson(string filename)// Функция для чтения данных из файла JSON
    {
        string jsonData = File.ReadAllText(filename);
        TaskData data = JsonSerializer.Deserialize<TaskData>(jsonData);
        return data;
    }

    static void Main(string[] args)
    {
        string filename = "data.json";

        if (File.Exists(filename))// Если файл существует, читаю данные из него и вывожу на консоль
        {
            TaskData data = ReadFromJson(filename);
            Console.WriteLine("Данные из файла JSON:");
            Console.WriteLine($"Задание: {data.Task}");
            Console.WriteLine($"Дедлайн: {data.Deadline}");
        }
        else
        {
            TaskData newTask = new TaskData // Если файла нет, создадим новые данные, сохраняем их в файл JSON
            {
                Task = "Sdelat chto nibude",
                Deadline = "31.12.2024"
            };
            SaveToJson(newTask, filename);
            Console.WriteLine("Данные сохранены в файл JSON.");
        }
    }
}















