﻿using System;
using System.Collections.Generic;
using System.Linq;

abstract class Task
{
    public Task(string text) { }
    protected abstract void ParseText(string text);
    protected virtual int Count()
    {
        return -1;
    }
    private double CountPersent(int number, int total)
    {
        return (double)number / (double)total * 100;
    }
}

class Task_2 : Task
{
    private string encoded;
    private string decoded;

    public Task_2(string text) : base(text)
    {
        ParseText(text);
    }

    public override string ToString()
    {
        return $"encoded: {encoded} \ndecoded : {decoded}";
    }

    protected override void ParseText(string text)
    {
        string[] words = text.Split(' ');
        encoded = Encoded(words);
        decoded = Decoded(encoded);
    }

    private string Encoded(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            char[] array = words[i].ToCharArray();
            Array.Reverse(array);
            words[i] = new string(array);
        }
        return string.Join(" ", words);
    }

    private string Decoded(string text)
    {
        return Encoded(text.Split(' '));
    }
}

class Task_4 : Task
{
    private int complexity;

    public Task_4(string text) : base(text)
    {
        ParseText(text);
    }

    public override string ToString()
    {
        return $"complexity = {complexity}";
    }

    protected override void ParseText(string text)
    {
        complexity = GetComplexity(text);
    }

    private int GetComplexity(string text)
    {
        int wordCount = 0;
        int punctuationCount = 0;
        string[] words = text.Split(" ");
        wordCount = words.Length;
        foreach (char c in text)
        {
            if (char.IsPunctuation(c))
            {
                punctuationCount++;
            }
        }
        return wordCount + punctuationCount;
    }
}

class Task_6 : Task
{
    private Dictionary<int, int> _slogCounts;

    public Task_6(string text) : base(text)
    {
        ParseText(text);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, _slogCounts.Select(pair => $"Слов с {pair.Key} слогами: {pair.Value}"));
    }

    protected override void ParseText(string text)
    {
        _slogCounts = new Dictionary<int, int>();
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            int slogi = CountSlogov(word);
            if (slogi > 0)
            {
                if (_slogCounts.ContainsKey(slogi))
                {
                    _slogCounts[slogi]++;
                }
                else
                {
                    _slogCounts[slogi] = 1;
                }
            }
        }
    }

    private int CountSlogov(string word)
    {
        int slogi = 0;
        char[] glasnye = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        bool isGlasnaya = false;
        foreach (char c in word.ToLower())
        {
            if (glasnye.Contains(c))
            {
                if (!isGlasnaya) slogi++;
                isGlasnaya = true;
            }
            else
            {
                isGlasnaya = false;
            }
        }
        return slogi;
    }
}

class Task_8 : Task
{
    private string result;
    public Task_8(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return result;
    }
    protected override void ParseText(string text)
    {
        string[] words = text.Split(' ');
        int maxLength = 50;
        string currentLine = "";
        result = "";

        foreach (string word in words)
        {
            if ((currentLine + word).Length < maxLength)
            {
                currentLine += word + " ";
            }
            else
            {
                result += Width(currentLine, maxLength) + "\n";
                currentLine = word + " ";
            }
        }

        if (!string.IsNullOrWhiteSpace(currentLine))
        {
            result += currentLine.Trim().PadRight(maxLength);
        }
    }

    private string Width(string line, int maxWidth)
    {
        if (!line.Contains(" "))
            return line.PadRight(maxWidth);

        int addSpaces = maxWidth - line.Length;
        string[] words = line.Split(' ');
        int gaps = words.Length - 1;

        if (gaps == 0) return line.PadRight(maxWidth);

        int spacesToAdd = addSpaces / gaps;
        int extra = addSpaces % gaps;

        string justified = "";
        for (int i = 0; i < words.Length - 1; i++)
        {
            justified += words[i] + " ";
            for (int j = 0; j < spacesToAdd; j++)
                justified += " ";

            if (extra > 0)
            {
                justified += " ";
                extra--;
            }
        }
        justified += words[words.Length - 1];

        return justified;
    }
}

class Task_9
{
    private Dictionary<string, char> bigramCodes;
    private string encodedText;

    public Task_9(string text)
    {
        ParseText(text);
    }

    private void ParseText(string text)
    {
        bigramCodes = new Dictionary<string, char>();
        encodedText = EncodeText(text);
    }

    private string EncodeText(string inputText)
    {
        var bigramFrequencies = new Dictionary<string, int>();
        for (int i = 0; i < inputText.Length - 1; i++)
        {
            string bigram = inputText.Substring(i, 2).ToLower();
            if (!char.IsLetter(bigram[0]) || !char.IsLetter(bigram[1])) continue;

            if (bigramFrequencies.ContainsKey(bigram))
                bigramFrequencies[bigram]++;
            else
                bigramFrequencies[bigram] = 1;
        }

        var sortedBigrams = bigramFrequencies.OrderByDescending(b => b.Value).ToList();

        int startCode = 0x1000;
        foreach (var bigram in sortedBigrams)
        {
            if (!bigramCodes.ContainsKey(bigram.Key))
            {
                char code = (char)startCode++;
                bigramCodes.Add(bigram.Key, code);
            }
        }

        string encoded = inputText;
        foreach (var code in bigramCodes)
        {
            encoded = encoded.Replace(code.Key, code.Value.ToString());
        }
        return encoded;
    }

    public string GetEncodedText()
    {
        return encodedText;
    }

    public Dictionary<string, char> GetBigramCodes()
    {
        return bigramCodes;
    }
}

class Task_10
{
    private Dictionary<char, string> codeTable;
    private string decodedText;

    public Task_10(string encodedText, Dictionary<char, string> codeTable)
    {
        this.codeTable = codeTable ?? throw new ArgumentNullException(nameof(codeTable));
        ParseText(encodedText);
    }

    private void ParseText(string encodedText)
    {
        decodedText = DecodeText(encodedText);
    }

    private string DecodeText(string encodedText)
    {
        string decoded = encodedText;
        foreach (var codePair in codeTable)
        {
            decoded = decoded.Replace(codePair.Key.ToString(), codePair.Value);
        }
        return decoded;
    }

    public override string ToString()
    {
        return $"Decoded text: {decodedText}";
    }
}

class Program
{
    public static void Main()
    {
        Task_2 task2 = new Task_2("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой");
        Task_4 task4 = new Task_4(
            "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой " +
            "страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме.");
        Task_6 task6 = new Task_6("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом.\" +\n            \" Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. \" +\n            \"Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, \" +\n            \"его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. \" +\n            \"Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        Task_8 task8 = new Task_8(
            "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом." +
            " Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. " +
            "Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, " +
            "его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. " +
            "Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        Console.WriteLine(task2);
        Console.WriteLine(task4);
        Console.WriteLine(task6);
        Console.WriteLine(task8);

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string text = "Клоун веселый бежал по дорожке. Вдруг у него запутались ножки";
        Task_9 task9 = new Task_9(text);
        Dictionary<string, char> bigramCodes = task9.GetBigramCodes(); //

        Task_10 task10 =
            new Task_10(task9.GetEncodedText(), InvertDictionary(bigramCodes));

        Console.WriteLine("Task_9 output:");
        Console.WriteLine($"Encoded Text: {task9.GetEncodedText()}");

        Console.WriteLine("Task_10 output:");
        Console.WriteLine(task10);

        Console.WriteLine("Code Table:");
        foreach (var codePair in bigramCodes)
        {
            Console.WriteLine($"'{codePair.Key}': '{codePair.Value}'");
        }
    }

    static Dictionary<char, string> InvertDictionary(Dictionary<string, char> dictionary)
    {
        return dictionary.ToDictionary(pair => pair.Value, pair => pair.Key);
    }
}
