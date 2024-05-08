using System;
using System.Collections.Generic;
using System.Linq;

abstract class Task
{
    protected string Text { get; }
    protected Task(string text)
    {
        Text = text;
    }

    public abstract void ParseText();

    protected virtual int Count()
    {
        return -1;
    }

    protected double CalculatePer(int number, int total)
    {
        return (double)number / total * 100;
    }
}

class Task_1 : Task
{
    private Dictionary<char, double> frequency;

    public Task_1(string text) : base(text) { }

    public override string ToString()
    {
        string result = "Task 1:\n";
        foreach (var entry in frequency)
        {
            result += $"Letter '{entry.Key}': {entry.Value}%\n";
        }
        return result;
    }

    public override void ParseText()
    {
        frequency = new Dictionary<char, double>();

        string lowercase = Text.ToLower();
        int totalLetters = lowercase.Count(char.IsLetter);

        foreach (char c in lowercase)
        {
            if (char.IsLetter(c))
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }
        }

        foreach (var entry in frequency.ToList())
        {
            char key = entry.Key;
            frequency[key] = CalculatePer((int)entry.Value, totalLetters);
        }
    }
}

class Task_3 : Task
{
    private List<string> lines;

    public Task_3(string text) : base(text) { }

    public override string ToString()
    {
        string result = "Task 3:\n";
        foreach (string line in lines)
        {
            result += line + "\n";
        }
        return result;
    }

    public override void ParseText()
    {
        lines = new List<string>();
        string[] words = Text.Split(' ');

        string line = "";
        foreach (string word in words)
        {
            if ((line + word).Length > 50)
            {
                lines.Add(line.Trim());
                line = "";
            }
            line += word + " ";
        }
        if (!string.IsNullOrEmpty(line))
        {
            lines.Add(line.Trim());
        }
    }
}

class Task_6 : Task
{
    private List<SyllableCount> syllableCounts;

    public Task_6(string text) : base(text) { }

    public override string ToString()
    {
        string result = "Task 6:\n";
        foreach (var count in syllableCounts)
        {
            result += $"{count.Syllable}-syllable words: {count.Count}\n";
        }
        return result;
    }

    public override void ParseText()
    {
        syllableCounts = new List<SyllableCount>();

        string[] words = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            int syllables = CountSyllables(word);
            var existingCount = syllableCounts.FindIndex(c => c.Syllable == syllables);
            if (existingCount != -1)
            {
                syllableCounts[existingCount] = new SyllableCount { Syllable = syllables, Count = syllableCounts[existingCount].Count + 1 };
            }
            else
            {
                syllableCounts.Add(new SyllableCount { Syllable = syllables, Count = 1 });
            }
        }
    }



    private int CountSyllables(string word)
    {
        return word.Count(c => "аеёиоуыэюяaeiouy".Contains(char.ToLower(c)));
    }

    private struct SyllableCount
    {
        public int Syllable { get; set; }
        public int Count { get; set; }
    }
}

class Task_12 : Task
{
    private Dictionary<string, char> WordCodes;
    private List<string> TextArray;

    public Task_12(string text) : base(text) { }

    public override string ToString()
    {
        string result = "Task 12: Text with word codes:\n";
        foreach (string token in TextArray)
        {
            if (char.TryParse(token, out char code))
            {
                result += code;
            }
            else
            {
                result += token + " ";
            }
        }
        return result;
    }

    public override void ParseText()
    {
        WordCodes = new Dictionary<string, char>();
        TextArray = new List<string>();

        string[] words = Text.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var wordFrequencies = words.GroupBy(word => word)
                                    .Select(group => new { Word = group.Key, Count = group.Count() })
                                    .OrderByDescending(item => item.Count)
                                    .Take(5)
                                    .ToList();

        char code = 'a';

        foreach (var item in wordFrequencies)
        {
            if (!WordCodes.ContainsKey(item.Word))
            {
                WordCodes[item.Word] = code++;
            }
        }

        foreach (string word in words)
        {
            if (WordCodes.ContainsKey(word))
            {
                TextArray.Add(WordCodes[word].ToString());
            }
            else
            {
                TextArray.Add(word);
            }
        }
    }
}
class Task_13 : Task
{
    private Dictionary<char, double> firsеletterFrequency;

    public Task_13(string text) : base(text) { }

    public override string ToString()
    {
        string result = "Task 13:\n";
        foreach (var entry in firsеletterFrequency)
        {
            result += $"Words starting with '{entry.Key}': {entry.Value}%\n";
        }
        return result;
    }

    public override void ParseText()
    {
        firsеletterFrequency = new Dictionary<char, double>();

        string[] words = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int totalWords = words.Length;

        foreach (string word in words)
        {
            char firsеletter = word[0];
            if (firsеletterFrequency.ContainsKey(firsеletter))
            {
                firsеletterFrequency[firsеletter]++;
            }
            else
            {
                firsеletterFrequency[firsеletter] = 1;
            }
        }

        foreach (var entry in firsеletterFrequency.Keys.ToList())
        {
            char entery = entry;
            firsеletterFrequency[entery] = CalculatePer((int)firsеletterFrequency[entery], totalWords);
        }
    }
}

class Task_15 : Task
{
    private double Sum;

    public Task_15(string text) : base(text) { }

    public override string ToString()
    {
        return $"Task 15: Sum of numbers in text: {Sum}";
    }

    public override void ParseText()
    {
        string[] tokens = Text.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                Sum += number;
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        string text = @"Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова ""fjǫrðr"". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – ""фьорды"", в Шотландии – ""фьордс"", в Исландии – ""фьордар"". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.";

        Task_1 task1 = new Task_1(text);
        task1.ParseText();
        Console.WriteLine(task1);

        Task_3 task2 = new Task_3(text);
        task2.ParseText();
        Console.WriteLine(task2);

        Task_6 task3 = new Task_6(text);
        task3.ParseText();
        Console.WriteLine(task3);

        Task_12 task4 = new Task_12(text);
        task4.ParseText();
        Console.WriteLine(task4);

        Task_13 task5 = new Task_13(text);
        task5.ParseText();
        Console.WriteLine(task5);

        Task_15 task6 = new Task_15(text);
        task6.ParseText();
        Console.WriteLine(task6);
    }
}