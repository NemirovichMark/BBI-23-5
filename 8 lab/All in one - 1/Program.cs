using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

abstract class Task
{
    protected Task(string text) { }
    public abstract void ParseText(string text);
    protected virtual int Count()
    {
        return -1;
    }
    private double CountPercent(int number, int total)
    {
        return (double)number / (double)total * 100;
    }
}

class Task_9 : Task
{
    private List<KeyValuePair<string, string>> codeTable = new List<KeyValuePair<string, string>>();
    private string compressedText;

    public Task_9(string text) : base(text) { }

    public override void ParseText(string text)
    {
        var frequentPairs = FindFrequentPairs(text);
        compressedText = CompressText(text, frequentPairs);
    }

    public override string ToString()
    {
        string result = "Compressed Text:\n";
        result += compressedText + "\n\n";
        result += "Code Table:\n";
        foreach (var pair in codeTable)
        {
            result += $"{pair.Key} : {pair.Value}\n";
        }
        return result;
    }

    public List<KeyValuePair<string, string>> GetCodeTable()
    {
        return codeTable;
    }

    private List<KeyValuePair<string, int>> FindFrequentPairs(string text)
    {
        var pairs = new List<KeyValuePair<string, int>>();

        for (int i = 0; i < text.Length - 1; i++)
        {
            string pair = text.Substring(i, 2);
            if (!IsPunctuationOrSymbol(pair))
            {
                var existingPair = pairs.FindIndex(p => p.Key == pair);
                if (existingPair == -1)
                {
                    pairs.Add(new KeyValuePair<string, int>(pair, 1));
                }
                else
                {
                    pairs[existingPair] = new KeyValuePair<string, int>(pair, pairs[existingPair].Value + 1);
                }
            }
        }

        pairs = pairs.Where(pair => pair.Value > 1).OrderByDescending(pair => pair.Value).Take(5).ToList();
        return pairs;
    }

    private bool IsPunctuationOrSymbol(string pair)
    {
        char[] allowedSymbols = { ' ', '.' };
        foreach (char c in pair)
        {
            if (!allowedSymbols.Contains(c))
            {
                return false;
            }
        }
        return true;
    }

    private string CompressText(string text, List<KeyValuePair<string, int>> frequentPairs)
    {
        string compressedText = text;
        int index = 0;
        char[] replacementSymbols = { '&', '₽', '#', '@', '%' };

        foreach (var pair in frequentPairs)
        {
            if (index >= replacementSymbols.Length)
                break;

            codeTable.Add(new KeyValuePair<string, string>(pair.Key, $"{replacementSymbols[index]}"));
            compressedText = compressedText.Replace(pair.Key, $"{replacementSymbols[index]}");
            index++;
        }

        var numbers = Regex.Matches(compressedText, @"\d+");
        foreach (Match number in numbers)
        {
            if (index >= replacementSymbols.Length)
                break;

            codeTable.Add(new KeyValuePair<string, string>(number.Value, $"{replacementSymbols[index]}"));
            compressedText = compressedText.Replace(number.Value, $"{replacementSymbols[index]}");
            index++;
        }

        return compressedText;
    }
}

class Task_10 : Task
{
    private List<KeyValuePair<string, string>> codeTable;
    private string encodedText;

    public Task_10(string text, List<KeyValuePair<string, string>> codeTable) : base(text)
    {
        this.codeTable = codeTable;
    }

    public override void ParseText(string text)
    {
        encodedText = text;
    }

    public override string ToString()
    {
        string decodedText = DecodeText(encodedText);
        return "Decoded Text:\n" + decodedText;
    }

    private string DecodeText(string encodedText)
    {
        string decodedText = encodedText;
        foreach (var pair in codeTable)
        {
            decodedText = decodedText.Replace(pair.Value, pair.Key);
        }
        return decodedText;
    }
}

class Program
{
    public static void Main()
    {
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";

        Task_9 task9 = new Task_9(text);
        task9.ParseText(text);

        Task_10 task10 = new Task_10(text, task9.GetCodeTable());
        task10.ParseText(text);

        Console.WriteLine(task9);
        Console.WriteLine(task10);
    }
}