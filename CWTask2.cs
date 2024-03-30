using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class Disciple
    {
        protected string _name;
        protected int _age;
        //private int _maso;
        protected double _sredb;
        protected bool _statkd;
        

        public Disciple(string n, int a, double sb, bool st)
        {
            _name = n;
            _age = a;
            _sredb = sb;
            _statkd = st;
           
            if (sb == 5.0)
            {
                st = true;

            }
            
        }
        public virtual void PrintTitle()
        {
            Console.WriteLine("Имя        Возраст     Ср. б   Красный атестат  ");
        }
        public virtual void Print()
        {
            Console.Write($"{_name,-7}");
            Console.WriteLine("{0,10:d} {1,10:f1}  ", _age, _sredb, _statkd);
        }
    }
     class Pupil: Disciple
    {
        protected string _cl;
        protected string _cpec;
        public Pupil(string n, int a, double sb, bool st, string cl, string cp ) : base (n, a, sb, st)
        {
            _cl = cl;
            _cpec = cp;

        }
        public override void PrintTitle()
        {
            Console.WriteLine("Имя        Возраст     Ср. б   Красный атестат    Класс    Специализация ");
        }
        public override void Print()
        {
            Console.Write($"{_name,-7}");
            Console.Write("{0,10:d} {1,10:f1}  ", _age, _sredb, _statkd);
            Console.Write($"{_cl,-7}  {_cpec,-7}");
        }
    }
    class Student : Disciple
    {
        protected string _gr;
        protected bool _dol;
        public string _studbil { get; private set; }
        public Student (string n, int a, double sb, bool st, string gr, bool dl, string stb) : base(n, a, sb, st)
        {
            _gr= gr;
            _dol= dl;
            _studbil= stb;
        }
        public override void PrintTitle()
        {
            Console.WriteLine("Имя        Возраст     Ср. б   Красный атестат    Группа  Должник  Студ. бил  ");
        }
        public override void Print()
        {
            Console.Write($"{_name,-7}");
            Console.Write("{0,10:d} {1,10:f1}  ", _age, _sredb, _statkd);
            Console.Write($"{_cl,-7}  {_cpec,-7}");
        }
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {

            Disciple[] disciples = new Disciple[]
            {
                new Disciple ("Сидоров", 17, 4.5, true),
                new Disciple ("Иванов", 17, 4.4, true),
                new Disciple ("Петров", 18, 5.0, true),
                new Disciple ("Цзинь", 17, 4.5, true),
                new Disciple ("Хелп", 18, 3.5, true),
            };
            disciples[0].PrintTitle();
            foreach (Disciple mn in disciples)
            {
                mn.Print();
            }
            Sort(disciples);
            Console.WriteLine("После изменения");
            disciples[0].PrintTitle();
            foreach (Disciple mn in disciples)
            {
                mn.Print();
            }
        }
        static void Sort(Disciple[] disciples)
        {

        }
    }
}
