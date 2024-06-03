using System;

namespace _8;
public abstract class Task
{
    public string Message { get; private set; }
    public Task(string message)
    {
        Message = message;
    }
}
public class task2 : Task
{

    public task2(string message) : base(message)
    {

    }
    public string shifr(string text)
    {
        string[] x = text.Split(' ');
        for (int i = 0; i < x.Length; i++)
        {
            char[] y = x[i].ToCharArray();
            Array.Reverse(y);
            x[i] = new string(y);
        }
        return string.Join(" ", x);
    }
    public string razshifr(string text)
    {
        return shifr(text);
    }
    public override string ToString()
    {
        string shifr_text = shifr(base.Message);
        string razshifr_text = razshifr(shifr_text);
        return $"Зашифрованный текст: {shifr_text} \n Расшифованный текст: {razshifr_text}";
    }
}
public class task4 : Task
{
    public task4(string message) : base(message)
    {
    }
    public int finding(string text)
    {
        string symbols = ",.?!:;";
        int count_w = 0;
        int count_s = 0;
        string[] b = text.Split(' ');
        foreach (var a in b)
        {
            if (a != " ")
            {
                count_w++;
            }
        }
        foreach (var a in text)
        {
            if (symbols.Contains(a))
            {
                count_s++;
            }
        }
        return count_w + count_s;
    }
    public override string ToString()
    {
        int dif = finding(base.Message);
        return $"Сложность предложения: {dif}";
    }
}
public class task5 : Task
{
    public task5(string message) : base(message)
    {
    }
    public string letter(string text)
    {
        List<char> letters = new List<char>();
        List<int> often = new List<int>(); 
        string[] words = text.Split(' '); 
        foreach (string word in words)
        {
            if (!word.Any(char.IsDigit))
            {
                int i = letters.IndexOf(char.ToLower(word[0])); 
                if (i == -1)
                {
                    often.Add(1);
                    letters.Add(char.ToLower(word[0]));
                }
                else
                {
                    often[i]++;
                }
            }
        }
        for (int i = 0; i < often.Count - 1; i++)
        {
            for (int j = i + 1; j < often.Count; j++)
            {
                if (often[j] > often[i])
                {
                    int a = often[j]; 
                    char boxChar = letters[j];
                    often[j] = often[i];
                    letters[j] = letters[i];
                    often[i] = a;
                    letters[i] = boxChar;
                }
            }
        }
        return string.Join(", ", letters);
    }
    public override string ToString()
    {
        string letters = letter(base.Message);
        return $"В порядке убывания частоты употребления: {letters}";
    }
}
public class task7 : Task
{
    public string Coren { get; }
    public task7(string message, string coren) : base(message)
    {
        Coren = coren;
    }
    public List<string> Simular_words(string text, string coren)
    {
        List<string> odnocr_words = new List<string>(); //список однокоренных слов
        string[] word = text.Split(' '); //разделяем предложения на слова

        foreach (string i in word)
        {

            if (i.ToLower().Contains(coren))
            {
                odnocr_words.Add(i);
            }
        }
        return odnocr_words;
    }
    public override string ToString()
    {
        string symbols = ",.:;!?";
        List<string> odnocr_words = Simular_words(base.Message, this.Coren);
        string word = string.Join(' ', odnocr_words);
        return $"Слова, содержащие данную последовательность: {word.Trim(new char[] { ',', '.', ':', ':', '!', '?' })}";
    }
}
public class task11 : Task
{
    public task11(string message) : base(message)
    {
    }
    public string sort_lastnames(string lastnames)
    {
        List<string> list_lastnames = new List<string>(lastnames.Split(','));

        for (int i = 0; i < list_lastnames.Count - 1; i++)
        {
            for (int j = 0; j < list_lastnames.Count - 1 - i; j++)
            {
                if (string.Compare(list_lastnames[j], list_lastnames[j + 1]) > 0) //сравниваем элемент с предыдущим
                {
                    string box = list_lastnames[j];
                    list_lastnames[j] = list_lastnames[j + 1];
                    list_lastnames[j + 1] = box;
                }
            }
        }
        return string.Join(", ", list_lastnames);
    }
    public override string ToString()
    {
        string surnames = sort_lastnames(base.Message);
        return $"Фамилии в алфавитном порядке: {surnames}";
    }
}
public class task14 : Task
{
    public task14(string message) : base(message)
    {
    }
    public int Sum(string text)
    {
        int sum = 0;
        foreach (char i in text)
        {
            if (char.IsDigit(i))
            {
                int b = int.Parse(i.ToString());
                sum += b;
            }
        }
        return sum;
    }
    public override string ToString()
    {
        int sum = Sum(base.Message);
        return $"Сумма чисел, включенных в текст: {sum}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string alltext = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";
        task2 c = new task2(alltext);
        Console.WriteLine(c.ToString());

        task4 d = new task4(alltext);
        Console.WriteLine(d.ToString());

        task5 f = new task5(alltext);
        Console.WriteLine(f.ToString());

        string coren = "on";
        task7 e = new task7(alltext, coren);
        Console.WriteLine(e.ToString());

        string surnames = "Иванов,Петров,Смирнов,Соколов,Кузнецов,Попов,Лебедев,Волков,Козлов,Новиков,Иванова,Петрова,Смирнова";
        task11 g = new task11(surnames);
        Console.WriteLine(g.ToString());

        task14 p = new task14(alltext);
        Console.WriteLine(p.ToString());
    }
}