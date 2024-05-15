//исправление не знаю какое по счету
using System;
using System.Text.RegularExpressions; // высокий уровень (не рекомендую) класс Regex
using System.Collections.Generic;
using System.Text;
using System.Linq;
abstract class Task
{
    public Task(string text) { }
    protected abstract void ParseText(string text); // все разные
    protected virtual int Count() // если несколько одинаковых, а один выбивается
    {
        return -1;
    }
    private double CountPersent(int number, int total) // все одинаковые
    {
        return (double)number / (double)total * 100;
    }


}

class Task_2 : Task
{
    private string encoded;
    private string decoded;
    public Task_2(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return $"encoded: {encoded} \ndecoded: {decoded}";
    }
    protected override void ParseText(string text)
    {
        string[] words = text.Split(' '); //разбив на массив строк , разедляем массив на буквы(слова), сколько слов-столько эл
        encoded = Encoded(words);
        decoded = Decoded(encoded);

    }
    private string Encoded(string[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            char[] array = words[i].ToCharArray(); //сохр элементы массива в символы
            int start = 0; //указывает изначальную позицию
            for (int j = 0; j < words[i].Length; j++)
            {
                if (char.IsPunctuation(words[i][j]) || j == words[i].Length - 1)//обрабатываем пунктук., является ли символом или last word
                {
                    int end = char.IsPunctuation(words[i][j]) ? j - 1 : j; //определяем конец нашего конца инвентирования, если текующий эл - запятая, то останваливается перед ним, если после, то ивентвкл его
                    while (start <= end)
                    {
                        char temp = array[start];
                        array[start] = array[end];
                        array[end] = temp;
                        start++;
                        end--;
                    }
                    start = j + 1; //двиг на слд эл
                }
            }
            words[i] = new string(array); //преобраз массив символов обратно в строку
        }
        return string.Join(" ", words); //добавл пробелы
    }

    private string Decoded(string text)
    {
        return Encoded(text.Split(' ')); //в обрат сторону
    }
}
class Task_4 : Task
{
    private int complexity;
    public Task_4(string text) : base(text) { ParseText(text); }
    public override string ToString()
    {
        return $"complexity = {complexity}";
    }
    protected override void ParseText(string text)
    {
        complexity = CalculateComplexity(text);
    }
    private int CalculateComplexity(string text)
    {
        int wordCount = 0; //количеств слов
        int punctuationCount = 0; //количество знаков преинания
        string[] words = text.Split(" ");
        wordCount = words.Length;
        for (int i = 0; i < text.Length; i++) //по пробелу, каждое слово - элемент
        {
            if (char.IsPunctuation(text[i]))
            {
                punctuationCount++; //считаем знаки препинания
            }
        }
        return wordCount + punctuationCount;
    }
}

class Task_6 : Task
{

    private List<SlogCount> _slogCounts;

    public Task_6(string text) : base(text)
    {
        _slogCounts = new List<SlogCount>();
        ParseText(text);
    }


    public override string ToString()
    {
        _slogCounts = _slogCounts.OrderByDescending(sc => sc.WordCount).ToList(); //сортировка по убыв,преобразуем в список
        return string.Join(Environment.NewLine, _slogCounts.Select(sc => $"Слов с {sc.SyllableCount} слогами: {sc.WordCount}"));
    }

    protected override void ParseText(string text)
    {
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            int syllables = CountSyllables(word);
            if (syllables > 0)
            {
                var entry = _slogCounts.FirstOrDefault(sc => sc.SyllableCount == syllables);//находим запись в списке и возрв, если не нашли
                if (entry != null)//проверяем есть ли такая вообще
                {
                    entry.IncrementWordCount();//добавляем
                }
                else
                {
                    _slogCounts.Add(new SlogCount(syllables));//добавляем новую запись
                }
            }
        }
    }

    private int CountSyllables(string word)
    {
        int syllables = 0;
        char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
        bool wasVowel = false;
        foreach (char c in word.ToLower())
        {
            if (vowels.Contains(c))
            {
                if (!wasVowel) syllables++;
                wasVowel = true;
            }
            else
            {
                wasVowel = false;
            }
        }
        return syllables;
    }
}

class SlogCount
{
    public int SyllableCount { get; private set; }
    public int WordCount { get; private set; }

    public SlogCount(int syllableCount)
    {
        SyllableCount = syllableCount;
        WordCount = 1;
    }

    public void IncrementWordCount()
    {
        WordCount++;
    }
}

class Task_8 : Task
{
    private string result;
    public Task_8(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return result;
    }
    protected override void ParseText(string text)
    {
        string[] words = text.Split(' ');
        int maxLength = 50;
        List<string> currentWords = new List<string>(); //хранит слова текущей строки
        int currentLineLength = 0; //тек длина
        result = "";

        foreach (string word in words)
        {
            if (currentLineLength + word.Length + currentWords.Count <= maxLength) //не превыш
            {
                currentWords.Add(word); //добавляем в список слово
                currentLineLength += word.Length; //наращ длину
            }
            else
            {
                result += Justify(currentWords, currentLineLength, maxLength) + "\n"; //обрезаю пробелы + доп строчку до макс длины
                currentWords = new List<string> { word };//новое слово кладем в лист, переиницилизируем
                currentLineLength = word.Length; //обнов длину
            }
        }

        if (currentWords.Count > 0)
        {
            result += Justify(currentWords, currentLineLength, maxLength); //провер остались ли не обработ
        }
    }

    private string Justify(List<string> words, int currentLength, int maxWidth)
    {
        if (words.Count == 1) //если содерж одно слово
            return words[0].PadRight(maxWidth); //возвращ слово дополненное пробелами справа 

        int totalSpaces = maxWidth - currentLength; //робщее кол-во
        int evenSpaces = totalSpaces / (words.Count - 1); //кол-во пробелов
        int extraSpaces = totalSpaces % (words.Count - 1);//остаток пробелов

        string result = "";
        for (int i = 0; i < words.Count; i++)
        {
            result += words[i];
            if (i < words.Count - 1)//если не послед
            {
                int spacesToAdd = evenSpaces + (i < extraSpaces ? 1 : 0);//кол-во пробелов = базовому кол-ву пробелов + 1 доп пробел для первых интервалов между словами- равномерно
                result += new string(' ', spacesToAdd);//добв строку
            }
        }
        return result;
    }

}

class Task_9
{
    private Dictionary<string, char> bigramCodes;
    private string encodedText;

    public Task_9(string text)
    {
        ParseText(text);
    }

    private void ParseText(string text)
    {
        bigramCodes = new Dictionary<string, char>();
        encodedText = EncodeText(text);
    }

    private string EncodeText(string inputText)
    {
        var bigramFrequencies = new Dictionary<string, int>();  //инициализируем словарь, что бы счит с каой частотой
        for (int i = 0; i < inputText.Length - 1; i++)
        {
            string bigram = inputText.Substring(i, 2); //каждое слово как под строку, начал позиция и длина/ извлечение биграммы из текста!
            if (!char.IsLetter(bigram[0]) || !char.IsLetter(bigram[1])) continue; //проверка 1 и 2 символ это буквы, пропускаем все, что не буквы

            if (bigramFrequencies.ContainsKey(bigram)) //если содержит ключ, то увел значение в нашем счетчике
                bigramFrequencies[bigram]++;
            else
                bigramFrequencies[bigram] = 1;
        }

        var sortedBigrams = bigramFrequencies.OrderByDescending(b => b.Value).ToList();
        //опред порядок сортировки по значениям(по колву), конвертируем в лист значения (сортировка по убыванию)
        //лист (из пар) удобнее для foreach
        int startCode = 0x1000; //бинарное
        foreach (var bigram in sortedBigrams)
        {
            if (!bigramCodes.ContainsKey(bigram.Key)) // если биграма не была закодирована, то (есть ли в словаре)
            {
                char code = (char)startCode++; // определяю код-перевожу в него символ его
                bigramCodes.Add(bigram.Key, code); //добавляем 
            }
        }

        string encoded = inputText;//инициализация закод строки как исход стр
        foreach (var code in bigramCodes) //по биграммам
        {
            encoded = encoded.Replace(code.Key, code.Value.ToString()); //замен на соответ ей символ
        }
        return encoded;
    }

    public string GetEncodedText()
    {
        return encodedText;
    }

    public Dictionary<string, char> GetBigramCodes()
    {
        return bigramCodes;
    }
}

class Task_10
{
    private Dictionary<char, string> codeTable;
    private string decodedText;

    public Task_10(string encodedText, Dictionary<char, string> codeTable)
    {
        this.codeTable = codeTable ?? throw new ArgumentNullException(nameof(codeTable)); //
        //убираем ошибку, если кодтаблэ = null, если null то убираем
        ParseText(encodedText);
    }

    private void ParseText(string encodedText)
    {
        decodedText = DecodeText(encodedText);
    }

    private string DecodeText(string encodedText)
    {
        string decoded = encodedText;
        foreach (var codePair in codeTable)
        {
            decoded = decoded.Replace(codePair.Key.ToString(), codePair.Value); //замен символы на текст
        }
        return decoded;
    }

    public override string ToString()
    {
        return $"Decoded text: {decodedText}";
    }

}

class Program
{
    public static void Main()
    {
        Task_2 task2 = new Task_2("1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой");
        Task_4 task4 = new Task_4(
            "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой " +
            "страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме.");
        Task_6 task6 = new Task_6("Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом.\" +\n            \" Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. \" +\n            \"Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, \" +\n            \"его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. \" +\n            \"Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        Task_8 task8 = new Task_8(
            "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом." +
            " Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. " +
            "Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, " +
            "его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. " +
            "Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.");
        Console.WriteLine(task2);
        Console.WriteLine(task4);
        Console.WriteLine(task6);
        Console.WriteLine(task8);

        Console.OutputEncoding = System.Text.Encoding.UTF8; //что бы корректно отображалось в консоле

        string text = "Привет привет мир мир Привет";
        Task_9 task9 = new Task_9(text);
        Dictionary<string, char> bigramCodes = task9.GetBigramCodes(); //получаем биграммы

        Task_10 task10 =
            new Task_10(task9.GetEncodedText(), InvertDictionary(bigramCodes)); //кидаем закодированный текст и инвертируем - разворачиваем словарь, те же символы меняем на биграммы

        Console.WriteLine("Task_9 output:");
        Console.WriteLine($"Encoded Text: {task9.GetEncodedText()}");

        Console.WriteLine("Task_10 output:");
        Console.WriteLine(task10);

        Console.WriteLine("Code Table:");
        foreach (var codePair in bigramCodes)
        {
            Console.WriteLine($"'{codePair.Key}': '{codePair.Value}'"); //для таблицы
        }
    }

    static Dictionary<char, string> InvertDictionary(Dictionary<string, char> dictionary)
    {
        return dictionary.ToDictionary(pair => pair.Value, pair => pair.Key); //меняем местами ключ и значение
    }
}

