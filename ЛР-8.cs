using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
abstract class Task
{
    protected Task(string text) { }
    public abstract void ParseText(string text);
}

class Task_8 : Task
{
    private string formattedText;
    public Task_8(string text) : base(text) { }

    public override void ParseText(string text)
    {
        int maxLineLength = 50;
        string[] words = text.Split(' ');

        List<string> lines = new List<string>();
        StringBuilder currentLine = new StringBuilder();

        foreach (string word in words)
        {
            if (currentLine.Length + word.Length <= maxLineLength)
            {
                currentLine.Append(word).Append(' ');
            }
            else
            {
                lines.Add(currentLine.ToString().TrimEnd());
                currentLine = new StringBuilder(word + " ");
            }
        }
        lines.Add(currentLine.ToString().TrimEnd());

        formattedText = FormatLines(lines.ToArray(), maxLineLength);
    }

    private static string FormatLines(string[] lines, int maxLineLength)
    {
        StringBuilder formattedText = new StringBuilder();

        foreach (string line in lines)
        {
            string[] words = line.Split();
            int totalWordLength = words.Sum(word => word.Length);
            int totalSpacesToAdd = maxLineLength - totalWordLength;
            int spacePerWord = words.Length > 1 ? totalSpacesToAdd / (words.Length - 1) : 0;
            int extraSpaces = words.Length > 1 ? totalSpacesToAdd % (words.Length - 1) : 0;

            StringBuilder formattedLine = new StringBuilder();
            for (int i = 0; i < words.Length - 1; i++)
            {
                formattedLine.Append(words[i]);
                formattedLine.Append(' ', spacePerWord);
                if (extraSpaces > 0)
                {
                    formattedLine.Append(' ');
                    extraSpaces--;
                }
            }
            formattedLine.Append(words[words.Length - 1]);
            formattedText.AppendLine(formattedLine.ToString());
        }
        return formattedText.ToString();
    }

    public override string ToString()
    {
        return formattedText;
    }
}


class Task_9 : Task
{
    private List<KeyValuePair<string, int>> frequentPairs = new List<KeyValuePair<string, int>>();
    private List<KeyValuePair<string, string>> codeTable = new List<KeyValuePair<string, string>>();
    private string compressedText;
    public Task_9(string text) : base(text) { }

    public override void ParseText(string text)
    {
        frequentPairs = FindFrequentPairs(text);
        compressedText = CompressText(text);
    }

    public override string ToString()
    {
        string result = "Compressed Text:\n";
        result += compressedText + "\n\n";
        result += "Code Table:\n";
        foreach (var kvp in codeTable)
        {
            result += $"{kvp.Key} : {kvp.Value}\n";
        }
        return result;
    }

    private List<KeyValuePair<string, int>> FindFrequentPairs(string text)
    {
        var pairs = new Dictionary<string, int>();

        for (int i = 0; i < text.Length - 1; i++)
        {
            char currentChar = text[i];
            char nextChar = text[i + 1];

            if (char.IsLetter(currentChar) && char.IsLetter(nextChar))
            {
                string pair = $"{currentChar}{nextChar}";

                if (!IsPunctuationOrSymbol(pair))
                {
                    if (!pairs.ContainsKey(pair))
                    {
                        pairs[pair] = 1;
                    }
                    else
                    {
                        pairs[pair]++;
                    }
                }
            }
        }

        var frequentPairs = new List<KeyValuePair<string, int>>();
        foreach (var pair in pairs)
        {
            if (pair.Value > 1)
            {
                frequentPairs.Add(pair);
            }
        }
        for (int i = 0; i < frequentPairs.Count - 1; i++)
        {
            for (int j = 0; j < frequentPairs.Count - 1 - i; j++)
            {
                if (frequentPairs[j].Value < frequentPairs[j + 1].Value)
                {
                    var temp = frequentPairs[j];
                    frequentPairs[j] = frequentPairs[j + 1];
                    frequentPairs[j + 1] = temp;
                }
            }
        }
        return frequentPairs.Take(5).ToList();
    }

    private bool IsPunctuationOrSymbol(string pair)
    {
        char[] allowedSymbols = { ' ', '.', ',' };
        foreach (char c in pair)
        {
            if (!allowedSymbols.Contains(c))
            {
                return false;
            }
        }
        return true;
    }

    private string CompressText(string text)
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

    public List<KeyValuePair<string, string>> GetCodeTable()
    {
        return codeTable;
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

class Task_12 : Task
{
    private List<string> wordsAndPunctuation = new List<string>();
    private List<int> wordCodes = new List<int>();
    public Task_12(string text) : base(text) { }
    public override void ParseText(string text)
    {
        string[] wordsAndPunctuationArray = Regex.Split(text, @"(\b\S+\b|[^\w\s])");
        int code = 1;

        foreach (string item in wordsAndPunctuationArray)
        {
            if (Regex.IsMatch(item, @"\b\S+\b"))
            {
                wordsAndPunctuation.Add(item);
                wordCodes.Add(code);
                code++;
            }
            else
            {
                wordsAndPunctuation.Add(item);
            }
        }
    }

    public override string ToString()
    {
        string result = "Decoded Text:\n";
        foreach (string item in wordsAndPunctuation)
        {
            if (item.StartsWith("#"))
            {
                int code = int.Parse(item.Substring(1));
                string word = GetDecoded(code);
                result += word + " ";
            }
            else
            {
                result += item;
            }
        }
        return result;
    }

    private string GetDecoded(int code)
    {
        int index = code - 1;
        if (index >= 0 && index < wordsAndPunctuation.Count)
        {
            return wordsAndPunctuation[index];
        }
        return "";
    }
}

class Task_13 : Task
{
    private List<char> letters = new List<char>();
    private List<int> letterCounts = new List<int>();

    public Task_13(string text) : base(text) { }

    public override void ParseText(string text)
    {
        bool isWordStart = true;

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char letter = char.ToLower(c);

                if (isWordStart)
                {
                    int index = letters.IndexOf(letter);

                    if (index == -1)
                    {
                        letters.Add(letter);
                        letterCounts.Add(1);
                    }
                    else
                    {
                        letterCounts[index]++;
                    }

                    isWordStart = false;
                }
            }
            else
            {
                isWordStart = true;
            }
        }
    }

    public override string ToString()
    {
        string result = "Доля слов, начинающихся на различные буквы:\n";
        int totalLetters = letterCounts.Sum();

        for (int i = 0; i < letters.Count; i++)
        {
            double percentage = (double)letterCounts[i] / totalLetters * 100;

            result += $"{char.ToUpper(letters[i])}: {percentage:F2}%\n";
        }
        return result;
    }
}


class Task_15 : Task
{
    private double sumOfNumbers;

    public Task_15(string text) : base(text) { }

    public override void ParseText(string text)
    {
        sumOfNumbers = CalculateSum(text);
    }

    private double CalculateSum(string text)
    {
        double sum = 0;
        Regex regex = new Regex(@"\b\d+(\,\d+)?(\.\d+)?\b");
        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            string matchValue = match.Value.Replace(",", ".");
            if (double.TryParse(matchValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
            {
                sum += number;
            }
        }

        return sum;
    }

    public override string ToString()
    {
        return $"Sum of numbers in the text: {sumOfNumbers}";
    }
}

class Program
{
    public static void Main()
    {
        string text = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        Task_8 task8 = new Task_8(text);
        task8.ParseText(text);

        Task_9 task9 = new Task_9(text);
        task9.ParseText(text);

        Task_10 task10 = new Task_10(text, task9.GetCodeTable());
        task10.ParseText(text);

        Task_12 task12 = new Task_12(text);
        task12.ParseText(text);

        Task_13 task13 = new Task_13(text);
        task13.ParseText(text);

        Task task15 = new Task_15(text);
        task15.ParseText(text);


        Console.WriteLine("Task 8:");
        Console.WriteLine(task8);

        Console.WriteLine("\nTask 9:");
        Console.WriteLine(task9);

        Console.WriteLine("\nTask 10:");
        Console.WriteLine(task10);

        Console.WriteLine("\nTask 12:");
        Console.WriteLine(task12);

        Console.WriteLine("\nTask 13:");
        Console.WriteLine(task13);

        Console.WriteLine("\nTask 15:");
        Console.WriteLine(task15);
    }
}
