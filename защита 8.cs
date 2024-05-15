using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

abstract class Task
{
    protected string _text= "";
    public string Text
    {
        get => _text;
        protected set => _text = value;
    }
    public Task(string text)
    { _text = text; }
   
}

class Couple
{
    private char _letter1;
    private char _letter2;
    private int _counter;
    private char _code;
    public char Letter1
    {
        get => _letter1;
        private set => _letter1 = value;
    }
    public char Letter2
    {
        get => _letter2;
        private set => _letter2 = value;
    }
    public int Counter
    {
        get => _counter;
        set => _counter = value;
    }
    public char Code
    {
        get => _code;
        private set => _code = value;
    }
    public Couple(char letter1, char letter2,char code='\0')
    {
        _letter1 = letter1;
        _letter2 = letter2;
        _counter = 0;
        _code = code;
    }
}
class Task_9 : Task
{
    private List<Couple> _couples;
    private List<Couple> _codeTable;
    public List<Couple> Couples
    {
        get => _couples;
        private set => _couples = value;
    }
    public List<Couple> CodeTable { get { return _codeTable; } private set { } }
    public Task_9(string text) : base(text)
    {
        _couples= new List<Couple>();
        _codeTable= new List<Couple>();
    }
    public override string ToString()
    {
        CountCouples();
        SortCouples();
        EncodeText();
        ShowCodeTable();
        return _text;
    }
    private void CountCouples()
    {
        for (int i = 97; i < 123; i++)
        {
            for (int j = 97; j < 123; j++)
            {
                _couples.Add(new Couple((char)i, (char)j));
            }
        }
        for (int i = 1072; i < 1104; i++)
        {
            for (int j = 1072; j < 1104; j++)
            {
                _couples.Add(new Couple((char)i, (char)j));
            }
        }
        for (int i = 1072; i < 1104; i++)
        {
            _couples.Add(new Couple((char)i, (char)1105));
            _couples.Add(new Couple((char)1105, (char)i));
        }
        for (int i = 0; i < _text.Length - 1; i++)
        {
            if (char.IsLetter(_text[i]) && char.IsLetter(_text[i + 1]))
            {
                char letter1 = char.ToLower(_text[i]);
                char letter2 = char.ToLower(_text[i + 1]);
                for (int j = 0; j < _couples.Count(); j++)
                {
                    if (letter1 == _couples[j].Letter1 && letter2 == _couples[j].Letter2)
                    {
                        _couples[j].Counter++;
                        break;
                    }
                }
            }
        }
    }
    private void SortCouples()
    {
        for (int j = 0; j < _couples.Count() - 1; j++)
        {
            for (int i = j + 1; i < _couples.Count(); i++)
            {
                if (_couples[j].Counter < _couples[i].Counter)
                {
                    Couple a = _couples[j];
                    _couples[j] = _couples[i];
                    _couples[i] = a;
                }
            }
        }
    }
    private void ShowCodeTable()
    {
        Console.WriteLine("Таблица кодов:");
        for (int i = 0; i < _codeTable.Count; i++)
        {
            Console.WriteLine($"Пара символов '{_codeTable[i].Letter1}{_codeTable[i].Letter2}' заменяется на '{_codeTable[i].Code}'");
        }
    }
    private void EncodeText()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 33; j < 1000; j++)
            {             
     
                bool ok = true;
                for (int k = 0; k < _codeTable.Count; k++)
                {
                    if (_codeTable[k].Code == (char)j)
                    {
                        ok = false;
                        break;
                    }
                } 
                if (_text.Contains((char)j) == false && ok)
                {
                    _codeTable.Add(new Couple (_couples[i].Letter1, _couples[i].Letter2,(char)j));
                    string oldstring1 = _couples[i].Letter1.ToString() + _couples[i].Letter2.ToString();
                    string oldstring2 = char.ToUpper(_couples[i].Letter1).ToString() + _couples[i].Letter2.ToString();
                    string newstring = ((char)j).ToString();
                    _text = _text.Replace(oldstring1, newstring);
                    _text = _text.Replace(oldstring2, newstring);
                    break;
                }
            }
        }
    }
}
class Task_10 : Task
{
    private List<Couple> _codeTable;
    public List<Couple> CodeTable { get { return _codeTable; } private set { } }
    public Task_10(string text, List<Couple> codeTable ) : base(text)
    {
        _codeTable = codeTable;
    }
    private void DecodeText()
    {
        for (int i=0; i < _codeTable.Count; i++)
        {
            string newstring = _codeTable[i].Letter1.ToString() + _codeTable[i].Letter2.ToString();
            string oldstring = _codeTable[i].Code.ToString();
            _text = _text.Replace(oldstring, newstring);
        }
    }
    public override string ToString()
    {
        DecodeText();
        return _text;
    }

}



class Program
{
    static void Main()
    {
        //string s = "После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.";
        //string s = "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.";
        //string s = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
        //string s = "Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.";
        //string s = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";
        string s = "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий.";

        Console.WriteLine("номер 9");
        Task_9 task_9 = new Task_9(s);
        Console.WriteLine(task_9.ToString());
        Console.WriteLine(" номер 10");
        Task_10 task_10 = new Task_10(task_9.Text, task_9.CodeTable);
        Console.WriteLine("Декодированный текст:");
        Console.WriteLine(task_10.ToString());

    }
}