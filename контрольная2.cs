using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

abstract class Task
{
    string text = "Not write here yet";
    protected abstract virtual void ParseText(string text);
    public void Task(string text)
    {
          this.text = text;
    }
}
class Task1 : Task
{
    private int[] count;
    public Task1(string text): base(text) { count = new int[4]; ParseText(); }
    public void ToString()
    {
       return 
    }
    protected override void ParseText(string text)
    {
        int count = text.Split( ' ', ',', ';', ':', '!', '?', '.' ,);
        string [] letters = text.Split(new char[] { 'АБВГДЕЁЗЖИЙКЛМНОПРСТУЧШЩЪЫЬЭЮЯабвгдеёзжийклмнопрстучшщъыэюя' });
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                count[0]++;
            }
            else if (char.IsDigit(c))
            {
                count[1]++;
            }
            else if (char.IsPunctuation(c))
            {
                count[2]++;
            }
            else if (char.IsWhiteSpace(c))
            {
                count[3]++;
            }
        }

    }
}
class Task2 : Task
{
    private double counter;
    private int uniqueLetters;
    private int uniqueDigitsAndSymbols;
    public Task2(string text): base(text) { ParseText(text); Count(text); }
    public override string ToString()
    {
        return $"Number of unique letters: {uniqueLetters}\nNumber of unique digits and symbols: {uniqueDigitsAndSymbols}";
    }

    protected override void ParseText(string text)
    {
        this.text = text;
    }
    protected override void ParseText(string text)
    {
        string[] words = text.Split(new char[] { ' ', ',', ';', ':', '!', '?', '.' } , StringSplitOptions.RemoveEmptyEntries);
        List <string> letters = new List<string>();

    }
    private void Count(string text)
    {
        uniqueLetters = 0;
        uniqueDigitsAndSymbols = 0;

        HashSet<char> characters = new HashSet<char>();

        foreach (char c in text)
        {
            if (char.IsLetter(c) && !characters.Contains(c))
            {
                uniqueLetters++;
                characters.Add(c);
            }
            else if ((char.IsDigit(c) || !char.IsLetterOrDigit(c)) && !characters.Contains(c) && c != ' ')
            {
                uniqueDigitsAndSymbols++;
                characters.Add(c);
            }
        }
    }

}
class Program
{
    static void Main()
    {
        string text = "Дорогой дневник, мне не описать ту боль и унижение, которое я испытал сегодня, хочу честно признаться, я готовилась, но все забыла.";
        Task[] tasks =
        {
            new Task1(text),
            new Task2(text)
        };
        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);
    }
}
