using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

abstract class Task
{
    protected string processedText;

    public Task(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Текст пустой");
        }
        processedText = ProcessText(text);
    }

    protected abstract string ProcessText(string text);


    protected string DecodeText(string text, Dictionary<string, string> codes)
    {
        foreach (var code in codes)
        {
            text = text.Replace(code.Value, code.Key);
        }
        return text;
    }
    protected string EncodeText(string text, string[] codes)
    {
        for (int i = 0; i < codes.Length; i++)
        {
            text = text.Replace(codes[i], ((char)('v' + i)).ToString());
        }
        return text;
    }
}

class Task_1 : Task
{
    public Task_1(string text) : base(text) { }

    protected override string ProcessText(string text)
    {
        string processedText = "";
        int currentLength = 0;
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            if (currentLength + word.Length > 50)
            {
                processedText += "\n" + word + " ";
                currentLength = word.Length + 1;
            }
            else
            {
                processedText += word + " ";
                currentLength += word.Length + 1;
            }
        }
        return processedText;
    }

    public override string ToString()
    {
        return processedText;
    }

}

class Task_2 : Task
{
    private List<KeyValuePair<string, char>> infoposleds;

    public Task_2(string text) : base(text)
    {
        infoposleds = new List<KeyValuePair<string, char>>();
        processedText = CompressText(text);
    }
    public List<KeyValuePair<string, char>> GetInfoPosleds()
    {
        return infoposleds;
    }
    protected override string ProcessText(string text)
    {
        return text;
    }
    protected string CompressText(string text)
    {
        Dictionary<string, int> posledCounts = new Dictionary<string, int>();
        for (int i = 0; i < text.Length - 1; i++)
        {
            string posled = text.Substring(i, 2); 
            if (!Char.IsWhiteSpace(posled[0]) && !Char.IsWhiteSpace(posled[1])) // Проверяем, что cимволы не пробелы
            {
                if (!posledCounts.ContainsKey(posled))
                    posledCounts[posled] = 0;
                posledCounts[posled]++;
            }
        }
        List<KeyValuePair<string, int>> posledList = posledCounts.ToList();
        SortPosledList(posledList);
        for (int i = 0; i < 5; i++)
        {
            string code = ((char)('p' + i)).ToString();
            infoposleds.Add(new KeyValuePair<string, char>(posledList[i].Key, code[0]));
            text = text.Replace(posledList[i].Key, code);
        }

        return text;

    }
    private void SortPosledList(List<KeyValuePair<string, int>> posledList)
    {
        for (int i = 0; i < posledList.Count - 1; i++)
        {
            for (int j = 0; j < posledList.Count - i - 1; j++)
            {
                if (posledList[j].Value < posledList[j + 1].Value)
                {
                    var temp = posledList[j];
                    posledList[j] = posledList[j + 1];
                    posledList[j + 1] = temp;
                }
            }
        }
    }
    public override string ToString()
    {
        string table = "Таблица кодов:\n";
        foreach (var posledInfo in infoposleds)
        {
            table += $"{posledInfo.Key}: {posledInfo.Value}\n";
        }
        return $"\n{processedText}\n\n{table}";
    }

}
class Task_3 : Task
{
    private List<KeyValuePair<string, char>> infoposleds;

    public Task_3(string text, List<KeyValuePair<string, char>> infoposleds) : base(text)
    {
        this.infoposleds = infoposleds;
        processedText = DecodeText(text, infoposleds.ToDictionary(k => k.Key, v => v.Value.ToString()));
    }

    protected override string ProcessText(string text)
    {
        return text;
    }

    public override string ToString()
    {
        return processedText;
    }   
}

class Task_4 : Task
{
    private string[] codes; 
    private string encodedText; 

    public Task_4(string text, string[] codes) : base(text)
    {
        this.codes = codes;
        encodedText = EncodeText(text, codes);
        processedText = DecodeText(text, codes.ToDictionary(k => k, v => ((char)('v' + Array.IndexOf(codes, v))).ToString()));
    }

    protected override string ProcessText(string text)
    {
        return text;
    }

    public override string ToString()
    {
        return $"Закодированный текст:\n{encodedText}\n\nДекодированный текст:\n{processedText}";
    }
}
class Task_5 : Task
{
    public Task_5(string text) : base(text) { }

    protected override string ProcessText(string text)
    {
        Dictionary<char, int> letterCounts = new Dictionary<char, int>();
        string[] words = text.Split(new char[] { ' ', '.', ',', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            char firstLetter = char.ToLower(word[0]); // Приводим первую букву слова к нижнему регистру
            if (char.IsLetter(firstLetter))
            {
                if (!letterCounts.ContainsKey(firstLetter))
                {
                    letterCounts[firstLetter] = 0;
                }
                letterCounts[firstLetter]++;
            }
        }
        // Гномья сортировка
        var pairs = letterCounts.ToList();
        SortLetterCounts(pairs);
        string result = "Доля слов, начинающихся на различные буквы:\n";
        int totalWords = words.Length;
        foreach (var pair in pairs)
        {
            double prosent = (double)pair.Value / totalWords * 100;
            result += $"{pair.Key}: {prosent:F2}%\n";
        }

        return result;
    }
    private void SortLetterCounts(List<KeyValuePair<char, int>> pairs)
    {
        int i = 1;
        while (i < pairs.Count)
        {
            if (i == 0 || pairs[i].Key >= pairs[i - 1].Key)
            {
                i++;
            }
            else
            {
                var temp = pairs[i];
                pairs.RemoveAt(i);
                pairs.Insert(i - 1, temp);
                i--;
            }
        }
    }

    public override string ToString()
    {
        return processedText;
    }
}
class Task_6 : Task
{
    public Task_6(string text) : base(text) { }

    protected override string ProcessText(string text)
    {
        int sum = FindSumOfNumbers(text);
        return $"Сумма чисел в тексте: {sum}";
    }

    private int FindSumOfNumbers(string text)
    {
        int sum = 0;
        string currentNumber = "";

        foreach (char c in text)
        {
            if (char.IsDigit(c))
            {
                currentNumber += c;
            }
            else
            {
                if (currentNumber != "")
                {
                    sum += int.Parse(currentNumber);
                    currentNumber = "";
                }
            }
        }
        if (currentNumber != "")
        {
            sum += int.Parse(currentNumber);
        }

        return sum;
    }
    public override string ToString()
    {
        return processedText;
    }
}
class Program
{
    public static void Main()
    {
        Task_1 task1 = new Task_1("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений");
        Task_2 task2 = new Task_2("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.");
        List<KeyValuePair<string, char>> infoposleds = task2.GetInfoPosleds();
        string[] codes = { "сложная", "инженерная", "конструкция", "движение", "воздушного" };
        Task_3 task3 = new Task_3("Двигатель самолета – эs сложная инжpерная конtрукция, обеспечивающая подъем, упrвлpие и движpие в воздухе. Он сосsит из множеtва компонpsв, каждый из коsрых игrет важную роль в общей rботе мехаqзма. Внутрpнее уtройtво двигателя включает в себя компрессор, камеру сгоrqя, турбину и сиtемы упrвлpия и охлаждpия. Принцип rботы основан на воздушно-sпливной смеси,коsrя подвергается сжатию, воспламppию и rсширpию, обеспечивая движpие воздушного судна.", infoposleds);
        Task_4 task4 = new Task_4("Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.", codes);
        Task_5 task5 = new Task_5("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        Task_6 task6 = new Task_6("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        Console.WriteLine(task1);
        Console.WriteLine(task2);
        Console.WriteLine(task3);
        Console.WriteLine(task4);
        Console.WriteLine(task5);
        Console.WriteLine(task6);
    }
}
