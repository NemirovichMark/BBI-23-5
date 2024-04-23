using System;
using System.Collections.Generic;
using System.Globalization;
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

class Task_8 : Task
{
    private string formattedText;

    public Task_8(string text) : base(text) { }

    public override void ParseText(string text)
    {
        int maxLineLength = 50;
        int currentLineLength = 0;
        string[] words = text.Split(' ');
        string formattedText = "";

        foreach (string word in words)
        {
            if (currentLineLength + word.Length <= maxLineLength)
            {
                formattedText += word + " ";
                currentLineLength += word.Length + 1;
            }
            else
            {
                formattedText += Environment.NewLine + word + " ";
                currentLineLength = word.Length + 1;
            }
        }
        formattedText += Environment.NewLine;
        this.formattedText = formattedText;
    }

    public override string ToString()
    {
        return formattedText;
    }
}

class Task_9 : Task
{
    private Dictionary<string, string> codeTable = new Dictionary<string, string>();
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
        foreach (var kvp in codeTable)
        {
            result += $"{kvp.Key} : {kvp.Value}\n";
        }
        return result;
    }

    public Dictionary<string, string> GetCodeTable()
    {
        return codeTable;
    }

    private Dictionary<string, int> FindFrequentPairs(string text)
    {
        var pairs = new Dictionary<string, int>();

        for (int i = 0; i < text.Length - 1; i++)
        {
            string pair = text.Substring(i, 2);
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

        return pairs.Where(pair => pair.Value > 1).OrderByDescending(pair => pair.Value).Take(5).ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    private bool IsPunctuationOrSymbol(string pair)
    {
        char[] punctuationAndSymbols = { ' ', '.', ',', '!', '?', '-', '(', ')', '"', '\'', '/', '\\', '*', '+', '=', '&', '^', '%', '$', '#', '@', '~', '`', ':', ';', '<', '>', '[', ']', '{', '}', '|', '_', '\t', '\n', '\r' };

        foreach (char c in pair)
        {
            if (punctuationAndSymbols.Contains(c))
            {
                return true;
            }
        }

        return false;
    }


    private string CompressText(string text, Dictionary<string, int> frequentPairs)
    {
        string compressedText = text;
        int index = 0;
        char[] replacementSymbols = { '&', '₽', '#', '@', '%' };

        foreach (var pair in frequentPairs)
        {
            if (index >= replacementSymbols.Length)
                break;

            codeTable.Add(pair.Key, $"{replacementSymbols[index]}");
            compressedText = compressedText.Replace(pair.Key, codeTable[pair.Key]);
            index++;
        }

        var numbers = Regex.Matches(compressedText, @"\d+");
        foreach (Match number in numbers)
        {
            if (index >= replacementSymbols.Length)
                break;

            codeTable.Add(number.Value, $"{replacementSymbols[index]}");
            compressedText = compressedText.Replace(number.Value, codeTable[number.Value]);
            index++;
        }

        return compressedText;
    }
}


class Task_10 : Task
{
    private Dictionary<string, string> codeTable;

    private string encodedText;

    public Task_10(string text, Dictionary<string, string> codeTable) : base(text)
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
        foreach (var kvp in codeTable)
        {
            decodedText = decodedText.Replace(kvp.Value, kvp.Key);
        }
        return decodedText;
    }
}

class Task_12 : Task
{
    private Dictionary<string, int> wordCodes = new Dictionary<string, int>();
    private List<string> encodedWordsAndPunctuation = new List<string>();

    public Task_12(string text) : base(text) { }

    public override void ParseText(string text)
    {

         string[] wordsAndPunctuation = Regex.Split(text, @"(\b\S+\b|[^\w\s])");

        foreach (string item in wordsAndPunctuation)
        {
            if (Regex.IsMatch(item, @"\b\S+\b")) 
            {
                if (!wordCodes.ContainsKey(item))
                {
                    wordCodes.Add(item, wordCodes.Count + 1);
                }
                int code = wordCodes[item];
                string encodedWord = $"#{code}";
                encodedWordsAndPunctuation.Add(encodedWord);
            }
            else
            {
                encodedWordsAndPunctuation.Add(item);
            }
        }
    }

    public override string ToString()
    {
        string result = "Decoded Text:\n";
        foreach (string item in encodedWordsAndPunctuation)
        {
            if (item.StartsWith("#"))
            {
                string word = GetDecodedWord(item);
                result += word + " ";
            }
            else
            {
                result += item;
            }
        }
        return result;
    }

    private string GetDecodedWord(string encodedWord)
    {
        int code = int.Parse(encodedWord.Substring(1));
        foreach (var pair in wordCodes)
        {
            if (pair.Value == code)
            {
                return pair.Key; 
            }
        }
        return "";
    }
}

class Task_13 : Task
{
    private Dictionary<char, double> letterPercentages = new Dictionary<char, double>();

    public Task_13(string text) : base(text) { }

    public override void ParseText(string text)
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?', '-', '(', ')', '"', '\'', '/', '\\', '*', '+', '=', '&', '^', '%', '$', '#', '@', '~', '`', ':', ';', '<', '>', '[', ']', '{', '}', '|', '_', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<char, int> letterCounts = new Dictionary<char, int>();
        int totalWords = words.Length;

        foreach (string word in words)
        {
            char firstLetter = char.ToLower(word[0]);
            if (!char.IsLetter(firstLetter))
                continue;

            if (letterCounts.ContainsKey(firstLetter))
            {
                letterCounts[firstLetter]++;
            }
            else
            {
                letterCounts[firstLetter] = 1;
            }
        }

        HashSet<char> allLetters = new HashSet<char>(text.ToLower().Where(char.IsLetter));

        foreach (char letter in allLetters)
        {
            if (letterCounts.ContainsKey(letter))
            {
                double percentage = (double)letterCounts[letter] / totalWords * 100;
                letterPercentages.Add(letter, percentage);
            }
            else
            {
                letterPercentages.Add(letter, 0);
            }
        }
    }

    public override string ToString()
    {
        string result = "Доля слов, начинающихся на различные буквы:\n";

        foreach (char letter in letterPercentages.Keys.OrderBy(c => c))
        {
            result += $"{char.ToUpper(letter)}: {letterPercentages[letter]:F2}%\n";
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
        sumOfNumbers = CalculateSumOfNumbers(text);
    }

    private double CalculateSumOfNumbers(string text)
    {
        double sum = 0;
        Regex regex = new Regex(@"\b\d+(\,\d+)?(\.\d+)?\b"); 
        MatchCollection matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            if (double.TryParse(match.Value.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
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
        string text = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений. ";

        Task_8 task8 = new Task_8(text);
        task8.ParseText(text);

        Task_9 task9 = new Task_9(text);
        task9.ParseText(text);

        Task_10 task10 = new Task_10(text, task9.GetCodeTable());
        task10.ParseText(text);

        Task_12 task12 = new Task_12(text);
        task12.ParseText(text);

        Task task15 = new Task_15(text);
        task15.ParseText(text);

        Task_13 task13 = new Task_13(text);
        task13.ParseText(text);


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
