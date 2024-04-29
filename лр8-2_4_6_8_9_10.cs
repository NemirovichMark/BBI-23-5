using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;


abstract class Task
    {
        protected static string _text;
        public Task(string text)
        {
            _text = text;
        }
        public virtual void ParseText() { }

    };
    class Task_2 : Task
    {
        private const string Number = "Задание 2";
        public Task_2(string text) : base(text)
        {
            Console.WriteLine();
            Console.WriteLine(Number);
        }

        public override void ParseText()
        {
            _text += " ";
            string a = ""; string anyWord = "";
            for (int i = 0; i < _text.Length; i++)
            {
                char c = _text[i];
                if ((c >= 'А' && c <= 'я') || ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                {
                    anyWord = anyWord + _text[i];
                }
                else
                {
                    if (anyWord.Length > 0)
                    {
                        a = a + ChangeWord(anyWord);
                        anyWord = "";
                    }
                    a = a + _text[i];
                }

            }
            _text = a;
        }
        private static string ChangeWord(string s1)
        {
            string s2 = "";
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                s2 = s2 + s1[i];
            }
            return s2;

        }
        public override string ToString()
        {
            return _text;
        }

    }
    class Task_4 : Task
    {
        private const string Number = "Задание 4";
        public Task_4(string text) : base(text)
        {
            Console.WriteLine();
            Console.WriteLine(Number);
        }
        public override void ParseText()
        {
            string a = ""; string anyWord = "";
            int Words = 0; int Punctuationmarks = 0;
            for (int i = 0; i < _text.Length; i++)
            {
                char c = _text[i];
                a += c;
                if ((c >= 'А' && c <= 'я') || ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) || (c >= '0' && c <= '9'))
                {
                    anyWord = anyWord + _text[i];

                }
                else
                {
                    if (anyWord.Length > 0)
                    {
                        Words++;
                        anyWord = "";
                        if (c == ',' || c == '-' || c == '.' || c == ':' || c == ';' || c == '!' || c == '?') 
                        {
                            Punctuationmarks++;
                        }
                        if (c == '.' || c == '!' || c == '?')
                        {
                            Console.WriteLine(a);
                            Console.WriteLine("Сложность {0}", Punctuationmarks + Words);
                            Punctuationmarks = 0; Words = 0; a = "";
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            return _text;
        }
    }
    class Task_6 : Task
    {
        private const string Number = "Задание 6";
        private const string Vowels = "AaEeIiOoUuYyАаЕеЁёИиОоУуЫыЭэЮюЯя";
        private int[] countS = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Task_6(string text) : base(text)
        {
            Console.WriteLine();
            Console.WriteLine(Number);
        }
        private void Syllable(string text)
        {
            int Countsyllable = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (Vowels.Contains(c)) Countsyllable++;
            }
            if (Countsyllable > 0)
            { countS[Countsyllable - 1]++; }

        }
        public override void ParseText()
        {
            _text += " ";
            string a = ""; string anyWord = "";
            for (int i = 0; i < _text.Length; i++)
            {
                char c = _text[i];
                a += c;
                if ((c >= 'А' && c <= 'я') || ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                {
                    anyWord = anyWord + _text[i];

                }
                else
                {
                    if (anyWord.Length > 0)
                    {
                        Syllable(anyWord);
                        anyWord = "";


                    }
                }
            }
            Console.WriteLine("Слогов  слов");
            for (int i = 0; i < countS.Length; i++)
            {
                if (countS[i] > 0)
                    Console.WriteLine("{0}       {1}", i + 1, countS[i]);
            }
        }
        public override string ToString()
        {
            return _text;
        }
    }
    class Task_8 : Task
    {
        private const string Number = "Задание 8";
        public Task_8(string text) : base(text)
        {
            Console.WriteLine();
            Console.WriteLine(Number);
        }
        public override void ParseText()
        {
            string a1 = "";
            do
            {

                string a = "";
                int amount = 0;
                if (_text.Length >= 50)
                    a = _text.Substring(0, 50);
                else
                    a = _text + " ";

                for (int i = a.Length - 1; i > 0; i--)
                {
                    amount = i;
                    if (a[i] == ' ') break;
                }
                a = a.Substring(0, amount);

                if (_text.Length >= 50)
                    _text = _text.Substring(amount + 1, _text.Length - amount - 1);
                else
                    _text = "";

                string[] words = a.Split(' ');
                int addSpace = 50 - amount;
                for (int i = 0; i < words.Length; i++) amount -= words[i].Length;
                amount += addSpace;
                if (words.Length > 1)
                {
                    int k = amount / (words.Length - 1);
                    int m = amount % (words.Length - 1);
                    a = "";
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        a = a + words[i] + new string(' ', k);
                        if (i < m) a = a + " ";
                    }
                    a += words[words.Length - 1];
                }

                a1 += a + (char)10 + (char)13;
            }
            while (_text.Length > 1);
            _text = a1;


        }
        public override string ToString()
        {
            return _text;
        }
}

class Task_9_10 : Task
{
    Dictionary<string, char> codesTable = new Dictionary<string, char>();
    private string compressedText = "";
    private const string Number = "Задание 9 и 10";
    public Task_9_10(string text) : base(text)
    {
        Console.WriteLine();
        Console.WriteLine(Number);
    }

    public override void ParseText()
    {
        string compressedText = CompressText(_text, codesTable);
        Console.WriteLine("Сжатый текст: " + compressedText);
        Console.WriteLine("Таблица кодов:");
        foreach (var item in codesTable)
        {
            Console.WriteLine(item.Key + " -> " + item.Value);
        }
        string decompressedText = DecompressText(compressedText, codesTable);
        Console.WriteLine("Расшифрованный текст: " + decompressedText);
    }
    static string CompressText(string text, Dictionary<string, char> codesTable)
    {
        char code = '#';
        string compressedText = text;

        for (int i = 0; i < 10; i++)
        {
            if (!char.IsLetter(text[i]) || !char.IsLetter(text[i + 1])) continue; // Пропускаем не-буквенные символы
            string sequence = text.Substring(i, 2);
            if (!codesTable.ContainsKey(sequence))
            {
                codesTable.Add(sequence, code++);
            }
            compressedText = compressedText.Replace(sequence, codesTable[sequence].ToString());
        }
        
        _text = compressedText;
        return compressedText;
    }

    static string DecompressText(string compressedText, Dictionary<string, char> codesTable)
    {
        string decompressedText = compressedText;

        foreach (var item in codesTable)
        {
            decompressedText = decompressedText.Replace(item.Value.ToString(), item.Key);
        }
        _text = decompressedText;
        return decompressedText;
    }
    public override string ToString()
    {
        return compressedText;

    }
}

internal class Program
    {
        static void Main(string[] args)
        {

            //string s = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
            //string s = "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.";
            //string s = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
            //string s = "Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.";
            //string s = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";
            string s = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";


        Task_2 task2 = new Task_2(s);
        Console.WriteLine("Исходный: {0}", task2);
        task2.ParseText();
        Console.WriteLine("Перевёрнутый: {0}", task2);
        
        Task_4 task4 = new Task_4(s);
        Console.WriteLine("Исходный: {0}", task4);
        task4.ParseText();

        Task_6 task6 = new Task_6(s);
        Console.WriteLine("Исходный: {0}", task6);
        task6.ParseText();

        Task_8 task8 = new Task_8(s);
        Console.WriteLine("Исходный: {0}", task8);
        task8.ParseText();
        Console.WriteLine("Форматированный: ");
        Console.WriteLine(task8);

        Console.WriteLine();
        Task_9_10 task9_10 = new Task_9_10(s);
        Console.WriteLine("Исходный: {0}", task9_10);
        Console.WriteLine(task9_10);
        task9_10.ParseText();
        Console.WriteLine(task9_10); 


        }
    }
