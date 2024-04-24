using System;
using System.Globalization;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string text1 = "Please, when you stop do homework, call me";
        string text2 = "Okey, I will call you later, sorry";

        var capWords = CapWords(text1);
        var swapSentences = SwapLongShort(text2);

        Console.WriteLine(string.Join(" ", capWords));
        Console.WriteLine(swapSentences);

        string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\Solution";

        Directory.CreateDirectory(downloadPath);

        string filePath1 = Path.Combine(downloadPath, "task_1.json");
        string filePath2 = Path.Combine(downloadPath, "task_2.json");

        JsonIO.ProcessJson(filePath1, capWords);
        JsonIO.ProcessJson(filePath2, swapSentences);
    }

    static string[] CapWords(string text)
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                words[i] = new string(letters);
            }
        }
        return words;
    }

    static string SwapLongShort(string text)
    {
        string[] sentences  = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sentences.Length; i++)
        {
            string[] words = sentences[i].Trim().Split(new char[] { ' ', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2) continue;

            int shortIndex = 0, longIndex = 0;
            int shortLength = words[0].Length, longLength = words[0].Length;

            for (int j = 1; j < words.Length; j++)
            {
                int length = words[j].Length;
                if (length < shortLength)
                {
                    shortLength = length;
                    shortIndex = j;
                }
                if (length > longLength)
                {
                    longLength = length;
                    longIndex = j;
                }
            }

            string temp = words[shortIndex];
            words[shortIndex] = words[longIndex];
            words[longIndex] = temp;
            sentences[i] = string.Join(" ", words);
        }
        return string.Join(". ", sentences) + ".";
    }
}

class JsonIO
{
    public static void ProcessJson<T>(string filePath, T data)
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(data));
            Console.WriteLine($"Data написано в {filePath}");
        }
        else
        {
            string jsonData = File.ReadAllText(filePath);
            Console.WriteLine($"Data прочитана в {filePath}: {jsonData}");
        }
    }
}