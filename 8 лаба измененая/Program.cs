using System.Text;
using System.Text.RegularExpressions;

abstract class Task
{
    protected string Text { get; set; }

    public Task(string text)
    {
        Text = text;
    }

    public abstract void ParseText();


    public override string ToString()
    {
        return GetType().Name + ": " + Environment.NewLine + GetResult();
    }

    protected abstract string GetResult();

}
class Task_1 : Task
{
    private Dictionary<char, double> _letterFrequencies;

    public Task_1(string text) : base(text) { }

    public override void ParseText()
    {
        _letterFrequencies = new Dictionary<char, double>();
        int totalLetters = 0;

        foreach (char c in Text.ToLower())
        {
            if (char.IsLetter(c))
            {
                if (_letterFrequencies.ContainsKey(c))
                {
                    _letterFrequencies[c]++;
                }
                else
                {
                    _letterFrequencies[c] = 1;
                }
                totalLetters++;
            }
        }


        foreach (char c in _letterFrequencies.Keys.ToList())
        {
            _letterFrequencies[c] /= totalLetters;
        }
    }

    protected override string GetResult()
    {
        StringBuilder result = new StringBuilder();
        foreach (var kvp in _letterFrequencies)
        {
            result.AppendLine($"{kvp.Key}: {kvp.Value:P2}");
        }
        return result.ToString();
    }
}

class Task_3 : Task
{
    private List<string> _lines;
    public Task_3(string text) : base(text) { }

    public override void ParseText()
    {
        _lines = new List<string>();
        StringBuilder currentLine = new StringBuilder();
        foreach (string word in Text.Split(' '))
        {
            if (currentLine.Length + word.Length + 1 <= 50)
            {
                currentLine.Append(word).Append(' ');
            }
            else
            {
                _lines.Add(currentLine.ToString().TrimEnd());
                currentLine.Clear();
                currentLine.Append(word).Append(' ');
            }
        }
        _lines.Add(currentLine.ToString().TrimEnd());
    }
    protected override string GetResult()
    {
        return string.Join(Environment.NewLine, _lines);
    }
}

class Task_6 : Task
{
    private Dictionary<int, int> syllablesCount;

    public Task_6(string text) : base(text) { }

    public override void ParseText()
    {
        syllablesCount = new Dictionary<int, int>();

        string[] slova = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string slovo in slova)
        {
            int slogi = CountSyllables(slovo);
            if (slogi > 0 && syllablesCount.ContainsKey(slogi))
            {
                syllablesCount[slogi]++;
            }
            else if (slogi > 0)
            {
                syllablesCount[slogi] = 1;
            }
        }
    }

    private int CountSyllables(string slovo)
    {
        int slogi = 0;
        char[] glasnye = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        bool bylaGlasnaya = false;

        foreach (char c in slovo.ToLower())
        {
            if (glasnye.Contains(c))
            {
                if (!bylaGlasnaya) slogi++;
                bylaGlasnaya = true;
            }
            else
            {
                bylaGlasnaya = false;
            }
        }

        return slogi;
    }

    protected override string GetResult()
    {
        return string.Join(Environment.NewLine, syllablesCount.Select(para => $"Слов с {para.Key} слогами: {para.Value}"));
    }
}


class Task_12 : Task
{
    private List<string> wordsAndPunctuation = new List<string>();
    private Dictionary<string, char> wordCodes = new Dictionary<string, char>();
    private Dictionary<char, string> decodedWords = new Dictionary<char, string>();

    public Task_12(string text) : base(text) { }

    public override void ParseText()
    {
        string[] wordsAndPunctuationArray = Regex.Split(Text, @"(\b\S+\b|[^\w\s])");
        char code = 'a';

        foreach (string item in wordsAndPunctuationArray)
        {
            if (Regex.IsMatch(item, @"\b\S+\b"))
            {
                wordsAndPunctuation.Add(item);
                wordCodes[item] = code;
                decodedWords[code] = item;
                code++;
            }
            else
            {
                wordsAndPunctuation.Add(item);
            }
        }
    }

    protected override string GetResult()
    {
        StringBuilder sb = new StringBuilder("Decoded Text:\n");
        foreach (string item in wordsAndPunctuation)
        {
            if (item.StartsWith("#"))
            {
                char code = item[1];
                string word = decodedWords[code];
                sb.Append(word).Append(" ");
            }
            else
            {
                sb.Append(item);
            }
        }
        return sb.ToString();
    }
}


class Task_13 : Task
{
    private string _result;
    public Task_13(string text) : base(text) { }

    public override void ParseText()
    {
        string[] slova = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int vsegoSlov = slova.Length;

        var slovarDoley = slova.GroupBy(slovo => char.ToLower(slovo[0]))
                               .ToDictionary(g => g.Key, g => (double)g.Count() / vsegoSlov * 100);

        StringBuilder sb = new StringBuilder(base.ToString());
        foreach (var para in slovarDoley)
        {
            sb.AppendLine($"Буква '{para.Key}': {para.Value:F2}%");
        }
        _result = sb.ToString();
    }
    public override string ToString()
    {
        return _result ?? base.ToString();
    }

    protected override string GetResult()
    {
        return _result;
    }
}

class Task_15 : Task
{
    private string _result;
    public Task_15(string text) : base(text) { }

    public override void ParseText()
    {
        string[] elementi = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int summa = 0;
        foreach (string element in elementi)
        {
            if (int.TryParse(element, out int chislo))
            {
                summa += chislo;
            }
        }

        _result = $"Сумма чисел в тексте: {summa}";
    }
    public override string ToString()
    {
        return _result ?? base.ToString();
    }

    protected override string GetResult()
    {
        return _result;
    }
}

class Program
{
    static void Main(string[] args)
    {

        string text = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";

        List<Task> tasks = new List<Task>
        {
            new Task_1(text),
            new Task_3(text),
            new Task_6(text),
            new Task_12(text),
            new Task_13(text),
            new Task_15(text)
        };

        foreach (Task task in tasks)
        {
            task.ParseText();
            Console.WriteLine(task);
            Console.WriteLine("-----");
        }

    }
}