using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


abstract class Zadanie
{
    protected string Text { get; set; }

    public Zadanie(string text)
    {
        Text = text;
    }

    public abstract void Reshit();


    public override string ToString()
    {
        return GetType().Name + ": " + Environment.NewLine + GetResult();
    }

    protected abstract string GetResult();
}


class Zadanie1 : Zadanie
{
    private Dictionary<char, double> _letterFrequencies;

    public Zadanie1(string text) : base(text) { }

    public override void Reshit()
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


class Zadanie3 : Zadanie
{
    private List<string> _lines;

    public Zadanie3(string text) : base(text) { }

    public override void Reshit()
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

class Zadanie6 : Zadanie
{
    private Dictionary<int, int> _slogCounts;

    public Zadanie6(string text) : base(text) { }

    public override void Reshit()
    {
        _slogCounts = new Dictionary<int, int>();

        string[] slova = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string slovo in slova)
        {
            int slogi = KolichestvoSlogov(slovo);
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
    private int KolichestvoSlogov(string slovo)
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
        return string.Join(Environment.NewLine, _slogCounts.Select(para => $"Слов с {para.Key} слогами: {para.Value}"));
    }
}

class Zadanie12 : Zadanie
{
    private List<string> wordsAndPunctuation = new List<string>();
    private Dictionary<string, int> wordCodes = new Dictionary<string, int>();

    public Zadanie12(string text) : base(text) { }

    public override void Reshit()
    {
        string[] wordsAndPunctuationArray = Regex.Split(Text, @"(\b\S+\b|[^\w\s])");
        int code = 1;

        foreach (string item in wordsAndPunctuationArray)
        {
            if (Regex.IsMatch(item, @"\b\S+\b"))
            {
                wordsAndPunctuation.Add(item);
                wordCodes[item] = code;
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
                int code = int.Parse(item.Substring(1));
                string word = GetDecodedWord(code);
                sb.Append(word).Append(" ");
            }
            else
            {
                sb.Append(item);
            }
        }
        return sb.ToString();
    }

    private string GetDecodedWord(int code)
    {
        string word = wordCodes.FirstOrDefault(x => x.Value == code).Key;
        return word ?? "";
    }
}
class Zadanie13 : Zadanie
{
    public Zadanie13(string text) : base(text) { }

    public override void Reshit()
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

    private string _result;

    public override string ToString()
    {
        return _result ?? base.ToString();
    }

    protected override string GetResult()
    {
        return _result;
    }
}


 
class Zadanie15 : Zadanie
{
    public Zadanie15(string text) : base(text) { }

    public override void Reshit()
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

    private string _result;

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

        List<Zadanie> tasks = new List<Zadanie>
        {
            new Zadanie1(text),
            new Zadanie3(text),
            new Zadanie6(text),
            new Zadanie12(text),
            new Zadanie13(text),
            new Zadanie15(text)
        };

        foreach (Zadanie task in tasks)
        {
            task.Reshit();
            Console.WriteLine(task); 
            Console.WriteLine("-----");
        }
        
    }
}