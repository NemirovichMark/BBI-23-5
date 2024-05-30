using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Task
{
    protected string text;
    public Task(string inputText)
    {
        this.text = inputText;
    }
}
class Task_2 : Task
{
    private double countLetters;

    public Task_2(string text) : base(text)
    {
        ParseText(text);
    }

    public override string ToString()
    {
        return ((double)countLetters) / (text.Distinct().Count() - 1)).ToString();
    }

    public override void ParseText(string text)
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?', ':', ';', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}, StringSplitOptions.RemoveEmptyEntries);
        List<string> longWords = words.Where(word => word.Length > 5).ToList();

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        string solutionPath = Path.Combine(desktopPath, "Solution");

        if (!Directory.Exists(solutionPath))
        {
            Directory.CreateDirectory(solutionPath);
        }

        string task1Path = Path.Combine(solutionPath, "task_1.json");
        if (!File.Exists(task1Path))
        {
            File.Create(task1Path).Close();
        }

        string task2Path = Path.Combine(solutionPath, "task_2.json");
        if (!File.Exists(task2Path))
        {
            File.Create(task2Path).Close();
        }

        char[] distinctChars = text.Where(c => !char.IsWhiteSpace(c)).Distinct().ToArray();
        countLetters = distinctChars.Length;
    }
}
