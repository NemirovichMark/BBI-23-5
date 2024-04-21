using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Task 
    {
        protected  static string _srcWord;


        public Task(string srcWord)
        {
            _srcWord = srcWord;
        }
        public virtual void ParseText()
        {
            _srcWord += " ";
            string sout = ""; string anyWord = "";
            for (int i = 0; i < _srcWord.Length; i++)
            {
                char c = _srcWord[i];
                if ((c >= 'А' && c <= 'я') || ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                {
                    anyWord = anyWord + _srcWord[i];

                }
                else
                {
                    if (anyWord.Length > 0)
                    {
                        sout = sout + TransWord(anyWord);
                        anyWord = "";
                    }
                    sout = sout + _srcWord[i];
                }



            }
            _srcWord = sout;

        }
    
        private static string TransWord(string s1)
        {
            string s2 = "";
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                s2 = s2 + s1[i];
            }
            return s2;

        }
        
    };

    class Task_2 : Task
    {  private const string TaskName = "Задание 2";
     public Task_2(string srcWord):base(srcWord)
        {
            Console.WriteLine();
            Console.WriteLine(TaskName);
        }
        public override string ToString()
        {
            return _srcWord;
        }
      
    }
    class Task_4 : Task
    {
        private const string TaskName = "Задание 4";
        public Task_4(string srcWord) : base(srcWord)
        {
            Console.WriteLine();
            Console.WriteLine(TaskName);
        }
        public override string ToString()
        {
            return _srcWord;
        }
        public override void ParseText()
        {
            string sout = ""; string anyWord = "";
            int nWords = 0;int nZn = 0;
            for (int i = 0; i < _srcWord.Length; i++)
            {
                char c = _srcWord[i];
                sout += c;
                if ((c >= 'А' && c <= 'я') || ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) || (c >= '0' && c <= '9') )
                {
                    anyWord = anyWord + _srcWord[i];

                }
                else
                {
                    if (anyWord.Length > 0)
                    {
                        nWords++;                        
                        anyWord = "";
                        if (c==',' || c == '-' || c == '.' || c== ':' || c == ';' || c == '!' || c =='?') { nZn++; }
                        if (c == '.' || c == '!' || c == '?')
                        {
                            Console.WriteLine(sout);
                            Console.WriteLine("Сложность {0}", nZn + nWords);
                            nZn = 0; nWords=0;sout = "";
                        }
                    }
                }
            }
        }
    }
    class Task_6 : Task
    {
        private const string TaskName = "Задание 6";
        private const string AllGlasn = "AaEeIiOoUuYyАаЕеЁёИиОоУуЫыЭэЮюЯя";
        private int[] countSl = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0 };
        public Task_6(string srcWord) : base(srcWord)
        {
            Console.WriteLine();
            Console.WriteLine(TaskName);
        }
        public override string ToString()
        {
            return _srcWord;
        }
        private void findSl(string text)
        {
            int nSl = 0;
            for (int i=0; i<text.Length; i++)
            {
                char c = text[i];
                if (AllGlasn.Contains(c)) nSl++;
            }
            if (nSl > 0) countSl[nSl - 1] ++;

        }
        public override void ParseText()
        {
            _srcWord += " ";
            string sout = ""; string anyWord = "";
            for (int i = 0; i < _srcWord.Length; i++)
            {
                char c = _srcWord[i];
                sout += c;
                if ((c >= 'А' && c <= 'я') || ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) )
                {
                    anyWord = anyWord + _srcWord[i];

                }
                else
                {
                    if (anyWord.Length > 0)
                    {
                        findSl(anyWord);
                        anyWord = "";
                       
                        
                    }
                }
            }
            Console.WriteLine("Слогов  слов");
            for (int i = 0; i < countSl.Length; i++)
            {
                if (countSl[i]>0)           
                    Console.WriteLine("{0}       {1}", i + 1, countSl[i]);
                
            }
            
        }
    }
    class Task_8 : Task
    {
        private const string TaskName = "Задание 8";
        public Task_8(string srcWord) : base(srcWord)
        {
            Console.WriteLine();
            Console.WriteLine(TaskName);
        }
        public override string ToString()
        {
            return _srcWord;
        }

        
        public override void ParseText()
        {
            string Ssout = "";
            do
            {

                string sout = "";
                int nKol = 0;
                if (_srcWord.Length >= 50)
                    sout = _srcWord.Substring(0, 50);
                else
                    sout = _srcWord + " ";

                for (int i = sout.Length - 1; i > 0; i--)
                {
                    nKol = i;
                    if (sout[i] == ' ') break;
                }
                sout=sout.Substring(0, nKol);

                if (_srcWord.Length >= 50)
                    _srcWord = _srcWord.Substring(nKol+1, _srcWord.Length - nKol-1);
                else
                    _srcWord = "";

                string[] words = sout.Split(' ');
                int addSpace = 50 - nKol;
                for (int i = 0;i<words.Length;i++) nKol -= words[i].Length;
                nKol += addSpace;
                if (words.Length > 1)
                {
                    int k = nKol / (words.Length - 1);
                     int m = nKol % (words.Length - 1);
                    sout = "";
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        sout = sout + words[i] + new string(' ', k);
                        if (i < m) sout = sout + " ";
                    }
                sout += words[words.Length - 1];
                }

                Ssout += sout +(char)10+(char)13;
            }
            while (_srcWord.Length > 1);
            _srcWord = Ssout;

           
        }
    }
    public struct CodePaar
    {
       public string TwoChars;
       public int count;
       public char key;
    }

    class Task_9_10 : Task
    {
        private static CodePaar[] cp = new CodePaar[1000];
        private static int Ncp = 0;
        private static int Nchars = 0;        
        

        private const string TaskName = "Задание 9";
        public Task_9_10(string srcWord) : base(srcWord)
        {
            Console.WriteLine();
            Console.WriteLine(TaskName);
        }
        public override string ToString()
        {
            return _srcWord;
        }

        private static bool FoundCP(string str)
        {
            for (int i = 0; i < Ncp; i++)
            {
                if (String.Equals(str, cp[i].TwoChars, StringComparison.Ordinal)) { return true; }
            }
            return false;
        }
        private void setTwoChars(char ch)
        {
            int k = Nchars;
            for (int i = k;i< Ncp;i++)
            {
                Nchars++;
               if ( _srcWord.Contains(cp[i].TwoChars))
                {
                    cp[i].key = ch;
                    break;

                }
            }
        }
        private void TestChars()
        {
            for (int i = 32; i < 255; i++)
            {
                char ch = (char)i;
                bool isUseChar = _srcWord.Contains(ch);
                if (!isUseChar)
                {
                    setTwoChars(ch);

                }

            }

        }

        private void SortCP()
        {
            int imax;
            for (int i = 0;i < Ncp-1; i++)
            {
                imax = i;
                for (int j = i+1;j<Ncp; j++)
                    if (cp[j].count> cp[imax].count) imax = j;
                CodePaar tmp= new CodePaar();
                tmp = cp[i];
                cp[i] = cp[imax]; cp[imax] = tmp;
               
            }
 
        }
        private void EncodeText()
        {
            for (int i = 0; i < Ncp; i++)
            {
                if (cp[i].key > (char)10) 
                {
                    string ss = cp[i].key.ToString();
                    _srcWord = _srcWord.Replace(cp[i].TwoChars, ss);

                }
            }
        }
        public void DecodeText()
        {
            for (int i = 0; i < Ncp; i++)
            {
                if (cp[i].key > (char)10)
                {
                    string ss = cp[i].key.ToString();
                    _srcWord = _srcWord.Replace(ss,cp[i].TwoChars );

                }
            }
        }
        public override void ParseText()
        {
            for (int i = 0; i < _srcWord.Length-1; i++)
            {
                string obr = _srcWord.Substring(i, 2);
                if (! FoundCP(obr)) 
                {
                   
                    cp[Ncp].TwoChars = obr;
                    cp[Ncp].count=(_srcWord.Length - _srcWord.Replace(obr, "").Length) / obr.Length;
                    cp[Ncp].key = (char)10;
  
                    Ncp++;
                }
             }

            SortCP();
            TestChars();
            EncodeText();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tests = new string[]
                {"После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений.",
                 "Двигатель самолета – это сложная инженерная конструкция, обеспечивающая подъем, управление и движение в воздухе. Он состоит из множества компонентов, каждый из которых играет важную роль в общей работе механизма. Внутреннее устройство двигателя включает в себя компрессор, камеру сгорания, турбину и системы управления и охлаждения. Принцип работы основан на воздушно-топливной смеси, которая подвергается сжатию, воспламенению и расширению, обеспечивая движение воздушного судна.",
                "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.",
                "Фьорды – это ущелья, формирующиеся ледниками и заполняющиеся морской водой. Название происходит от древнескандинавского слова \"fjǫrðr\". Эти глубокие заливы, окруженные высокими горами, представляют захватывающие виды и природную красоту. Они популярны среди туристов и известны под разными названиями: в Норвегии – \"фьорды\", в Шотландии – \"фьордс\", в Исландии – \"фьордар\". Фьорды играют важную роль в культуре и туризме региона, продолжая вдохновлять людей со всего мира.",
                "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.",
                "Первое кругосветное путешествие было осуществлено флотом, возглавляемым португальским исследователем Фернаном Магелланом. Путешествие началось 20 сентября 1519 года, когда флот, состоящий из пяти кораблей и примерно 270 человек, отправился из порту Сан-Лукас в Испании. Хотя Магеллан не закончил свое путешествие из-за гибели в битве на Филиппинах в 1521 году, его экспедиция стала первой, которая успешно обогнула Землю и доказала ее круглую форму. Это путешествие открыло новые морские пути и имело огромное значение для картографии и географических открытий."

                };
       
            string inpStr = "";
            Console.Write("Задайте 0..5 или текст для обработки =>");
            inpStr = Console.ReadLine();
            if (inpStr[0] <= '5' && inpStr[0] >= '0') { inpStr = tests[(int) inpStr[0] -48]; }
            Task_2 task2 = new Task_2(inpStr);
            Console.WriteLine("Исходный: {0}",task2);
            task2.ParseText();
            Console.WriteLine("Транслированный: {0}", task2);

            Task_4 task4 =new Task_4(inpStr);
            Console.WriteLine("Исходный: {0}", task4);
            task4.ParseText();

            Task_6 task6 = new Task_6(inpStr);
            Console.WriteLine("Исходный: {0}", task6);
            task6.ParseText();

            Task_8 task8 = new Task_8(inpStr);
            Console.WriteLine("Исходный: {0}", task8);
            task8.ParseText();
            Console.WriteLine("Форматированный: ");
            Console.WriteLine(task8);

            Task_9_10 task9_10 = new Task_9_10(inpStr);
            Console.WriteLine("Исходный: {0}", task9_10);
            task9_10.ParseText();
            Console.WriteLine("Закодированный: ");
            Console.WriteLine(task9_10);

            Console.WriteLine("Задание 10");
            Console.WriteLine("Закодированный: ");
            Console.WriteLine(task9_10);
            task9_10.DecodeText();
            Console.WriteLine("Раскодированный: ");
            Console.WriteLine(task9_10);
        }
    }
}
