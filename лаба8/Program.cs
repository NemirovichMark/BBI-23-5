using System.Text;
using System.Text.RegularExpressions;
abstract class Task
{
    protected string Text;
    public Task(string text)
    {
        Text = text;
    }
    protected abstract void ParseText(string text);
    protected virtual int Count()
    {
        return -1;
    }
}
class Task_8 : Task
{
    private readonly int MaxLineLength;
    public Task_8(string text, int maxLineLength) : base(text)
    {
        Text = text;
        MaxLineLength = maxLineLength;
    }

    public string[] SplitTextIntoLines()
    {
        string[] words = Text.Split(' ');
        StringBuilder line = new StringBuilder(MaxLineLength);
        List<string> lines = new List<string>();

        foreach (string word in words)
        {

            if (line.Length + word.Length > MaxLineLength)
            {
                lines.Add(line.ToString());

                line.Clear();
            }

            line.Append(word).Append(' ');
        }

        if (line.Length > 0)
        {
            lines.Add(line.ToString());
        }

        AlignSpaces(lines);

        return lines.ToArray();
    }

    private void AlignSpaces(List<string> lines)
    {
        for (int i = 0; i < lines.Count; i++)
        {
            string line = lines[i];
            string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int MAXword = 0;
            foreach (string word in words)
            {
                MAXword = Math.Max(MAXword, word.Length);
            }

            int totalProbel = MaxLineLength - line.Length + words.Length - 1;
            int dopProbel = totalProbel % (words.Length - 1);
            int ProbelPerWord = totalProbel / (words.Length - 1);

            StringBuilder alignedLine = new StringBuilder(MaxLineLength);
            for (int j = 0; j < words.Length; j++)
            {
                alignedLine.Append(words[j]);
                if (j < words.Length - 1)
                {
                    alignedLine.Append(' ', ProbelPerWord + (dopProbel-- > 0 ? 1 : 0));
                }
            }

            lines[i] = alignedLine.ToString();
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        foreach (string line in SplitTextIntoLines())
        {
            result.AppendLine(line);
        }
        return result.ToString();
    }

    protected override int Count()
    {
        return 0;
    }

    protected override void ParseText(string text)
    {

    }
}class Task_9 : Task
{
    public Dictionary<string, char> ReplacementTable;
    public Task_9(string text) : base(text)
    {
        ReplacementTable = RepTable();
        ProcessText();
    }
    protected override void ParseText(string text)
    {
    }
    private Dictionary<string, char> RepTable()
    {
        var topSequences = GetTopSequences(Text, 5);
        Dictionary<string, char> table = new Dictionary<string, char>
        {
            { topSequences[0], '?' },
            { topSequences[1], '#' },
            { topSequences[2], '*' },
            { topSequences[3], '$' },
            { topSequences[4], '&' }
        };
        return table;
    }
    private List<string> GetTopSequences(string text, int n)
    {
        Dictionary<string, int> sequenceCounts = new Dictionary<string, int>();
        for (int i = 0; i < text.Length - 1; i++)
        {
            string sequence = text.Substring(i, 2);
            if (!sequence.All(char.IsLetter))
                continue;
            if (!sequenceCounts.ContainsKey(sequence))
            {
                sequenceCounts[sequence] = 0;
            }
            sequenceCounts[sequence]++;
        }
        var topSequences = sequenceCounts.OrderByDescending(pair => pair.Value)
                                          .Select(pair => pair.Key)
                                          .Take(n)
                                          .ToList();
        return topSequences;
    }
    private void ProcessText()
    {
        foreach (var pair in ReplacementTable)
        {
            Text = Text.Replace(pair.Key, pair.Value.ToString());
        }
    }
    public override string ToString()
    {
        string replacedText = $"Текст с замененными буквами на символ:\n{Text}\n";
        string table = "Таблица замен:\n";
        foreach (var pair in ReplacementTable)
        {
            table += $"{pair.Key}: {pair.Value}\n";
        }
        return $"{replacedText}\n{table}";
    }
}
class Task_10 : Task_9
{
    public Task_10(string text) : base(text) { }
    private string DecodeText()
    {
        StringBuilder decodedText = new StringBuilder();
        foreach (char character in Text)
        {
            if (ReplacementTable.ContainsValue(character))
            {
                var sequence = ReplacementTable.FirstOrDefault(x => x.Value == character).Key;
                decodedText.Append(sequence);
            }
            else
            {
                decodedText.Append(character);
            }
        }
        return decodedText.ToString();
    }
    public override string ToString()
    {
        Console.WriteLine("Task_10");
        string decodedText = $"Расшифрованный текст:\n{DecodeText()}\n";
        string table = "Таблица замен:\n";
        foreach (var pair in ReplacementTable)
        {
            table += $"{pair.Value}: {pair.Key}\n";
        }
        return $"{decodedText}\n{table}";
    }
}
class Task_12 : Task
{
    private Dictionary<string, char> ReplacementTable;
    public Task_12(string text) : base(text)
    {
        ReplacementTable = RepTable(text);
        ProcessText();
    }
    private Dictionary<string, char> RepTable(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> WordK = new Dictionary<string, int>();
        foreach (string word in words)
        {
            if (!WordK.ContainsKey(word))
            {
                WordK[word] = 0;
            }
            WordK[word]++;
        }
        var topWords = WordK.OrderByDescending(pair => pair.Value)
                                 .Select(pair => pair.Key)
                                 .Take(5)
                                 .ToList();
        Dictionary<string, char> table = new Dictionary<string, char>();
        for (int i = 0; i < topWords.Count; i++)
        {
            table[topWords[i]] = (char)('↑' + i);
        }
        return table;
    }
    private void ProcessText()
    {
        foreach (var pair in ReplacementTable)
        {
            string pattern = @"\b" + Regex.Escape(pair.Key) + @"\b";
            Text = Regex.Replace(Text, pattern, pair.Value.ToString());
        }
    }
    public override string ToString()
    {
        Console.WriteLine("Task_12");
        string replacedText = $"Текст с замененными словами на символы:\n{Text}\n";
        string table = "Таблица замен:\n";
        foreach (var pair in ReplacementTable)
        {
            table += $"{pair.Key}: {pair.Value}\n";
        }
        return $"{replacedText}\n{table}";
    }
    protected override void ParseText(string text)
    {
    }
}
class Task_13 : Task
{
    public Task_13(string text) : base(text)
    {
        Analyz();
    }
    private void Analyz()
    {
        Dictionary<char, int> WordK = new Dictionary<char, int>();
        string[] words = Text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            char firstChar = char.ToLower(word[0]);
            if (char.IsLetter(firstChar))
            {
                if (!WordK.ContainsKey(firstChar))
                {
                    WordK[firstChar] = 0;
                }
                WordK[firstChar]++;
            }
        }
        int totalWords = WordK.Values.Sum();
        Console.WriteLine("Task_13");
        Console.WriteLine("Доля в процентах слов, начинающихся на различные буквы:");
        foreach (var pair in WordK.OrderBy(pair => pair.Key))
        {
            double percentage = (double)pair.Value / totalWords * 100;
            Console.WriteLine($"{pair.Key}: {percentage:F2}%");
        }
    }
    protected override void ParseText(string text)
    {
    }
}
class Task_15 : Task
{
    public Task_15(string text) : base(text) { }

    public override string ToString()
    {
        double sum = Sum(Text);
        Console.WriteLine("Task 15");
        return $"Сумма чисел в тексте: {sum:F2}";
    }

    private double Sum(string text)
    {
        double sum = 0;
        string currentNumber = "";
        bool flag = false;

        foreach (char c in text)
        {
            if (char.IsDigit(c) || c == '.' || c == '-')
            {
                currentNumber += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    double number;
                    if (double.TryParse(currentNumber, out number))
                    {
                        if (flag)
                        {
                            number *= -1;
                            flag = false;
                        }
                        sum += number;
                    }
                    currentNumber = "";
                }

                if (c == '-' || c == '.' )
                {
                    flag = true;
                }
            }
        }

        if (!string.IsNullOrEmpty(currentNumber))
        {
            double number;
            if (double.TryParse(currentNumber, out number))
            {
                if (flag)
                {
                    number *= -1;
                }
                sum += number;
            }
     
        }

        return sum;
    }

    protected override void ParseText(string text) { }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("task8");
        string text = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603";

        Task_8 task8 = new Task_8(text, 50);
        Console.WriteLine(task8);
        Console.WriteLine();
        Console.WriteLine("task9");
        Task_9 compressor = new Task_9(text);
        Console.WriteLine(compressor);
        Task_10 decode = new Task_10(text);
        Console.WriteLine(decode);
        Task_12 task12 = new Task_12(text);
        Console.WriteLine(task12);
        Task_13 task13 = new Task_13(text);
        Console.WriteLine(task13);
        Task_15 task15 = new Task_15(text);
        Console.WriteLine(task15);
    }
}