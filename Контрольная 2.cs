using System;
using System.IO;
using System.Text;


abstract class TextProcessingTask
{
    protected TextProcessingTask(string text)
    {
        Text = text;
    }

    public string Text { get; }

    public abstract string ProcessText();
}




class CapitalizeFirstWordTask : TextProcessingTask
{
    public CapitalizeFirstWordTask(string text) : base(text) { }

    public override string ProcessText()
    {
        StringBuilder result = new StringBuilder();
        bool newSentence = true;

        foreach (char c in Text)
        {
            if (newSentence && char.IsLetter(c))
            {
                result.Append(char.ToUpper(c));  
                newSentence = false;
            }
            else if (!newSentence && char.IsLetter(c))
            {
                result.Append(char.ToUpper(c));  
            }
            else
            {
                result.Append(char.ToLower(c)); 
            }

            if (c == '.')
            {
                newSentence = true;
            }
        }

        return result.ToString();
    }
}
 


class SwapLongestShortestWordTask : TextProcessingTask
{
    public SwapLongestShortestWordTask(string text) : base(text) { }

    public override string ProcessText()
    {
        string[] sentences = Text.Split('.');
        StringBuilder result = new StringBuilder();

        foreach (string sentence in sentences)
        {
            string[] words = sentence.Trim().Split(' ');
            if (words.Length <= 1)
            {
                result.Append(sentence).Append('.');  
                continue;
            }

            int longestIndex = 0, shortestIndex = 0;
            int longestLength = 0, shortestLength = int.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longestLength)
                {
                    longestLength = words[i].Length;
                    longestIndex = i;
                }
                if (words[i].Length < shortestLength)
                {
                    shortestLength = words[i].Length;
                    shortestIndex = i;
                }
            }

            string temp = words[longestIndex];
            words[longestIndex] = words[shortestIndex];
            words[shortestIndex] = temp;

            result.Append(string.Join(" ", words)).Append('.');
        }

        return result.ToString().TrimEnd('.'); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        string text = "такой первый текст. а это второй. и ещё один.";


        CapitalizeFirstWordTask сapitalizeFirstWordTask = new CapitalizeFirstWordTask(text);
        string capitalizedText = сapitalizeFirstWordTask.ProcessText();
        Console.WriteLine("Текст с заглавными буквами:");
        Console.WriteLine(capitalizedText);

       
        SwapLongestShortestWordTask swapTask = new SwapLongestShortestWordTask(text);
        string swappedText = swapTask.ProcessText();
        Console.WriteLine("\nТекст с заменой слов:");
        Console.WriteLine(swappedText);

       
        string userName = Environment.UserName;
        string solutionPath = Path.Combine(@"C:\Users", userName, "m2311176", "solution");
        Directory.CreateDirectory(solutionPath);

        string file1Path = Path.Combine(solutionPath, "cw2_1.json");
        string file2Path = Path.Combine(solutionPath, "cw2_2.json");

        if (!File.Exists(file1Path))
        {
            File.Create(file1Path).Dispose();
        }

        if (!File.Exists(file2Path))
        {
            File.Create(file2Path).Dispose();
        }
    }
}
