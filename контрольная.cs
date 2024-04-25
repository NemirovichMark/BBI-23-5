using System;

class Task1
{
    public static void Freq(string[] args)
    {
        string text = "Всем приветик всем здарова";
        char maxletter = ' ';
        int maxcount = 0;

        int[] letters = new int[33]; 

        text = text.ToLower(); 

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                int index = (int)(c) - (int)('а'); 
                letters[index]++;
                if (letters[index] > maxcount)
                {
                    maxcount = letters[index];
                    maxletter = c;
                }
            }
        }

        double freq = (double)maxcount / text.Length;
    }
}
class Task2
{
    public static string Reverse()
    {
        string reversed = "";
        string text = "привет всем друзья";
        string word = "";

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                word = c + word;
            }
            else
            {
                reversed += word + c;
                word = "";
            }
        }
        reversed += word;
        return reversed
    }
}
class Program
{
    public static void Main()
    { 
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string answerFolderPath = Path.Combine(documentsPath, "answer");

        if (!Directory.Exists(answerFolderPath))
        {
            Directory.CreateDirectory(answerFolderPath); 
        }

        string cw1FilePath = Path.Combine(answerFolderPath, "cw2_1.json"); 
        string cw2FilePath = Path.Combine(answerFolderPath, "cw2_2.json");

        if (!File.Exists(cw1FilePath))
        {
            
            File.Create(cw1FilePath).Close();
        }

        if (!File.Exists(cw2FilePath))
        {
            
            File.Create(cw2FilePath).Close();
        }

        Console.WriteLine("файл создан");
    }
}



