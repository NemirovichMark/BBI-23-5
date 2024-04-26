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
public class task_2 : Task
{
    
    public task_2(string message) : base(message)
    {
        
    }
    public string shifr (string text)
    {
        string[] a = text.Split(' ');
        for (int i = 0; i < a.Length; i++)
        {
            char[] b = a[i].ToCharArray();
            Array.Reverse(b);
            a[i] = new string(b);
        }
        return string.Join(" ", a);
    }
    public string deshifr (string text)
    {
        return shifr(text);
    }
    public override string ToString()
    {
        string shifr_text = shifr(base.Message);
        string deshifr_text = deshifr(shifr_text);
        return $"зашифрованный текст: {shifr_text} \n расшифрованный текст: {deshifr_text}";
    }
}
public class task_4 : Task
{
    public task_4(string message) : base(message)
    {
    }
    public int finding(string text)
    {
        string symbols = ",.?!:;";
        int count_words = 0;
        int count_symbols = 0;
        string[] b = text.Split(' ');
        foreach (var a in b)
        {
            if (a != " ")
            {
                count_words++;
            }
        }
        foreach (var a in text)
        {
            if (symbols.Contains(a))
            {
                count_symbols++;
            }
        }
        return count_words + count_symbols;
    }
    public override string ToString()
    {
        int difficulty = finding(base.Message);
        return $"сложность текста: {difficulty}";
    }
}
public class task_5 : Task
{
    public task_5(string message) : base(message)
    {
    }
    public string letter(string text)
    {
        List<char> letters = new List<char>();
        List<int> how_often = new List<int>(); // частота слов
        string[] words = text.Split(' '); // разделяем предложение на слова
        foreach (string word in words)
        {
            if (!word.Any(char.IsDigit))
            {
                int i = letters.IndexOf(char.ToLower(word[0])); // находим индекс первой буквы
                if (i == -1)
                {
                    how_often.Add(1);
                    letters.Add(char.ToLower(word[0])); // добавляем первую букву слова в список letters
                }
                else
                {
                    how_often[i]++;
                }
            }
        }
        for (int i = 0; i < how_often.Count - 1; i++)
        {
            for (int j = i + 1; j < how_often.Count; j++)
            {
                if (how_often[j] > how_often[i])
                {
                    int box = how_often[j]; //храним частоту
                    char boxChar = letters[j]; // для хранения букв

                    how_often[j] = how_often[i];
                    letters[j] = letters[i];

                    how_often[i] = box;
                    letters[i] = boxChar;
                }
            }
        }
        return string.Join(", ", letters);
    }
    public override string ToString()
    {
        string letters = letter(base.Message);
        return $"первые буквы в порядке убывания частоты употребления: {letters}";
    }
}
public class task_7 : Task
{
    public string Coren { get; }
    public task_7(string message, string coren) : base(message)
    {
        Coren = coren;
    }
    public List<string> Similar_words (string text, string coren)
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
        List <string> odnocr_words = Similar_words(base.Message, this.Coren);
        string word = string.Join(' ', odnocr_words);
        return $"однокоренные слова: {word.Trim(new char[] {',','.',':',':','!','?'})}";
    }
}
public class task_11 : Task
{
    public task_11(string message) : base(message)
    {
    }
    public string sort_surnames (string surnames)
    {
        List<string> list_surnames = new List<string>(surnames.Split(','));
        
        for (int i = 0; i < list_surnames.Count - 1; i++)
        {
            for (int j = 0; j < list_surnames.Count - 1 - i; j++)
            {
                if (string.Compare(list_surnames[j], list_surnames[j+1]) > 0) //сравниваем элемент с предыдущим
                {
                    string box = list_surnames[j]; //храним фамилию
                    list_surnames[j] = list_surnames[j+1];
                    list_surnames[j+1] = box;
                }
            }
        }
        return string.Join(", ", list_surnames);
    }
    public override string ToString()
    {
        string surnames = sort_surnames(base.Message);
        return $"фамилии в алфавитном порядке: {surnames}";
    }
}
public class task_14 : Task
{
    public task_14(string message) : base(message)
    {
    }
    public int Sum (string text)
    {
        int sum = 0;
        foreach (char i in text)
        {
            if (char.IsDigit(i))
            {
                int b = int.Parse(i.ToString()); // говороим, что i - это цифра
                sum += b;
            }
        }
        return sum;
    }
    public override string ToString()
    {
        int sum = Sum(base.Message);
        return $"сумма чисел, включенных в текст: {sum}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string all_text = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";
        task_2 c = new task_2(all_text);
        Console.WriteLine(c.ToString());

        task_4 d = new task_4(all_text);
        Console.WriteLine(d.ToString());

        task_5 f = new task_5(all_text);
        Console.WriteLine(f.ToString());

        string coren = "перв";
        task_7 e = new task_7(all_text, coren);
        Console.WriteLine(e.ToString());

        string surnames = "Иванов,Петров,Смирнов,Соколов,Кузнецов,Попов,Лебедев,Волков,Козлов,Новиков,Иванова,Петрова,Смирнова";
        task_11 g = new task_11(surnames);
        Console.WriteLine(g.ToString());

        task_14 p = new task_14(all_text);
        Console.WriteLine(p.ToString());
    }
}