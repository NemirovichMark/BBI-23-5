﻿
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

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

class Task_1 : Task
{
    private List<char> answer;
    public List<char> Answer
    {
        get => answer;
    }

    public Task_1(string text) : base(text)
    {
        answer = new List<char>();
    }

    public override void Solution()
    {
        string[] words = text.Split(' ');
        string firstWord = words[0].ToLower();
        string secondWord = words[1].ToLower();

        foreach (char c in firstWord)
        {
            if (secondWord.Contains(c) && !answer.Contains(c))
            {
                answer.Add(c);
            }
        }
    }

    public override string ToString()
    {
        Solution();
        return string.Join(",", answer);
    }
}

class Task_2 : Task
{
    private double answer;
    public double Answer
    {
        get => answer;
    }

    public Task_2(string text) : base(text)
    {
        answer = 0;
    }

    public override void Solution()
    {
        string[] words = text.Split(' ');
        int totalSyllables = 0;

        foreach (string word in words)
        {
            int syllables = CountSyllables(word);
            totalSyllables += syllables;
        }

        answer = (double)totalSyllables / words.Length;
    }

    private int CountSyllables(string word)
    {
        int count = 0;
        bool lastCharWasVowel = false;

        foreach (char c in word.ToLower())
        {
            if ("aeiouyаеёиоуыюэя".Contains(c))
            {
                if (!lastCharWasVowel)
                {
                    count++;
                    lastCharWasVowel = true;
                }
            }
            else
            {
                lastCharWasVowel = false;
            }
        }

        if (word.EndsWith("e"))
        {
            count--;
        }

        if (count == 0)
        {
            count = 1;
        }

        return count;
    }

    public override string ToString()
    {
        Solution();
        return answer.ToString();
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
        string text = "Hello students";
        Task[] tasks = {
            new Task_1(text),
            new Task_2(text)
        };

        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string path = @"C:\Users\m2303057\Desktop\Solution";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string fileName1 = Path.Combine(path, "task_1.json");
        string fileName2 = Path.Combine(path, "task_2.json");

        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task_1>(tasks[0] as Task_1, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task_1>(fileName1);
            Console.WriteLine(t1.ToString());
        }

        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task_2>(tasks[1] as Task_2, fileName2);
        }
        else
        {
            var t2 = JsonIO.Read<Task_2>(fileName2);
            Console.WriteLine(t2.ToString());
        }
    }
}