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

    public string[] SplitText()
    {
        List<string> lines = new List<string>();
        StringBuilder currentLine = new StringBuilder();

        foreach (char simvol in Text)
        {
            currentLine.Append(simvol);

            if (currentLine.Length == MaxLineLength)
            {
                lines.Add(currentLine.ToString());
                currentLine.Clear();
            }
        }

        if (currentLine.Length > 0)
        {
            lines.Add(currentLine.ToString().PadRight(MaxLineLength));
        }

        return lines.ToArray();
    }

    public override string ToString()
    {
        return string.Join(" ", SplitText());
    }

    protected override int Count()
    {
        return 0;
    }

    protected override void ParseText(string text)
    {
    }
}
class Task_9 : Task
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
            table[topWords[i]] = (char)('#' + i);
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
        int sum = Sum(Text);
        Console.WriteLine("Task 15");
        return $"Сумма чисел в тексте: {sum}";
    }

    private int Sum(string text)
    {
        int sum = 0;
        string NowNumber = "";

        foreach (char c in text)
        {
            if (char.IsDigit(c))
            {
                NowNumber += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(NowNumber))
                {
                    sum += int.Parse(NowNumber);
                    NowNumber = "";
                }
            }
        }

        if (!string.IsNullOrEmpty(NowNumber))
        {
            sum += int.Parse(NowNumber);
        }

        return sum;
    }
    protected override void ParseText(string text)
    {
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("task8");
        string text = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";


        Task_8 divider = new Task_8(text, 50);
        string[] lines = divider.SplitText();
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
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