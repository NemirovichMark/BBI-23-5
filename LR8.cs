using System.Text;
using System.Text.RegularExpressions;


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

//1
class Task_1 : Task
{
    public Task_1(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return sb.ToString();
    }
    StringBuilder sb = new();
    protected override void ParseText(string text)
    {
        text = text.ToUpper();

        int totalLettersCount = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                totalLettersCount++;
            }
        }
        int letterCount;
        for (int i = 0; i < text.Length; i++)
        {
            bool isRussianLetter = Convert.ToInt32(text[i]) >= 1040 && Convert.ToInt32(text[i]) <= 1071;
            bool isBehindTheEnd = i != text.Length - 1;

            if (isBehindTheEnd && isRussianLetter && text[i] != text[i + 1])
            {
                letterCount = Array.FindAll(text.ToCharArray(), x => x == text[i]).Length;
                sb.AppendLine($"{text[i]}: {letterCount}/{totalLettersCount}");
                text = text.Replace(text[i].ToString(), "");
            }
        }
    }
}
//3
class Task_3 : Task
{
    public Task_3(string text) : base(text)
    {
        ParseText(text);
    }

    public override string ToString()
    {
        return sb.ToString();
    }

    StringBuilder sb = new StringBuilder();

    protected override void ParseText(string text)
    {
        var words = text.Split(' ');
        var line = new StringBuilder();

        foreach (var word in words)
        {
            if (line.Length + word.Length + 1 <= 50)
            {
                if (line.Length > 0)
                {
                    line.Append(" ");
                }
                line.Append(word);
            }
            else
            {
                sb.AppendLine(line.ToString());
                line.Clear();
                line.Append(word);
            }
        }

        if (line.Length > 0)
        {
            sb.AppendLine(line.ToString());
        }
    }
}
class Task_5 : Task
{
    public Task_5(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return sb.ToString();
    }
    StringBuilder sb = new();
    protected override void ParseText(string text)
    {
        text = text.ToUpper();

        string[] strings = text.Split();

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var s in strings)
        {
            if (char.IsLetter(s[0]))
            {
                stringBuilder.Append(s[0]);
            }
        }

        text = stringBuilder.ToString();

        StringBuilder lettersCount = new();

        while (text.Length != 0)
        {
            sb.Append(text[0]);
            lettersCount.Append(Array.FindAll(text.ToCharArray(), x => x == text[0]).Length + " ");

            text = text.Replace(text[0].ToString(), "");
        }

        string[] noSpacesCount = lettersCount.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] counts = Array.ConvertAll(noSpacesCount, int.Parse);

        for (int i = 0; i < sb.Length; i++)
        {
            for (int j = sb.Length - 1; j > 0; j--)
            {
                if (counts[j] > counts[j - 1])
                {
                    (counts[j], counts[j - 1]) = (counts[j - 1], counts[j]);
                    (sb[j], sb[j - 1]) = (sb[j - 1], sb[j]);
                }
            }
        }

        sb.AppendLine();

        foreach (var item in counts)
        {
            sb.Append(item);
        }
    }
}
//7
class Task_7 : Task
{
    public Task_7(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return sb.ToString();
    }
    StringBuilder sb = new();
    protected override void ParseText(string text)
    {
        string sequence = "ен";

        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in words)
        {
            if (word.Contains(sequence))
            {
                sb.Append(word + " ");
            }
        }
    }
}


//11

class Task_11 : Task
{
    public Task_11(string text) : base(text)
    {
        ParseText(text);
    }

    public override string ToString()
    {
        return sb.ToString();
    }

    StringBuilder sb = new StringBuilder();

    protected override void ParseText(string text)
    {
        string[] surnameArray = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        InsertionSort(surnameArray);

        sb.AppendLine("Отсортированный список фамилий:");
        foreach (var surname in surnameArray)
        {
            sb.AppendLine(surname.Trim());
        }
    }

    static void InsertionSort(string[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            string current = array[i];
            int j = i - 1;

            while (j >= 0 && CompareStrings(array[j], current) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = current;
        }
    }

    static int CompareStrings(string s1, string s2)
    {
        int minLength = Math.Min(s1.Length, s2.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (s1[i] != s2[i])
            {
                return s1[i] - s2[i];
            }
        }

        return s1.Length - s2.Length;
    }
}

//14
class Task_14 : Task
{
    public Task_14(string text) : base(text)
    {
        ParseText(text);
    }
    public override string ToString()
    {
        return sb.ToString();
    }
    StringBuilder sb = new();
    protected override void ParseText(string text)
    {
        var nowNumber = Regex.Matches(text, @"(\d*[,.]\d+|d+)");
        var result = 0.0;
        for (var i = 0; i < nowNumber.Count; i++)
        {
            result += double.Parse(nowNumber[i].Value.Replace('.', ','));
        }
        sb.AppendLine($"{result}");
    }
}

class Program
{
    static void Main()
    {
        string str1 = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке\r\nлесов Амазонии. Анализ данных показал, что основной участник разрушения лесного\r\nпокрова – человеческая деятельность. За последние десятилетия рост объема вырубки\r\nдостиг критических показателей. Главными факторами, способствующими этому, являются\r\nпромышленные рубки, производство древесины, расширение сельскохозяйственных\r\nугодий и незаконная добыча древесины. Это приводит к серьезным экологическим\r\nпоследствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания\r\nмногих видов животных и растений.";
        string str2 = "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.";
        string str3 = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга.";
        string str4 = "Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        string str5 = "Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.\n";
        string str6 = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.\n";
        string str7 = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";
        string spisok1 = "Иванов, Петров, Смирнов, Соколов, Кузнецов, Попов, Лебедев, Волков, Козлов, Новиков, Иванова, Петрова, Смирнова";
        string spisok2 = "Ivanov, Petrov, Smirnov, Sokolov, Kuznetsov, Popov, Lebedev, Volkov, Kozlov, Novikov, Ivanova, Petrova, Smirnova";

        //Console.WriteLine("task_1");
        //Task_1 task_1 = new(str1);

        //Console.WriteLine(task_1);
        //Console.WriteLine();

        //Console.WriteLine("task_3");
        //Task_3 task_3 = new(str2);

        //Console.WriteLine(task_3);
        //Console.WriteLine();

        Console.WriteLine("task_5");
        Task_5 task_5 = new(str3);

        Console.WriteLine(task_5);
        Console.WriteLine();

        //Console.WriteLine("task_7");
        //Task_7 task_7 = new(str4);

        //Console.WriteLine(task_7);
        //Console.WriteLine();

        //Console.WriteLine("task_11");
        //Task_11 task_11 = new(spisok2);

        //Console.WriteLine(task_11);
        //Console.WriteLine();

        //Console.WriteLine("task_14");
        //Task_14 task_14 = new(str3);

        //Console.WriteLine(task_14);
    }
}

