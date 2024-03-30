using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2
{
    abstract class Sportsmen
    {
       // private  int _Norm;//норматив
        protected string _famile;
        protected string _group;
        protected string _famileP;
        protected double _time;
        protected bool _isNorm;
        public double time  => _time;
       public bool isNorm => _isNorm;
        public  Sportsmen(string s1, string gr, string s2, double time, int Norm)
        {
            _famile = s1;
            _group = gr;
            _famileP = s2;
            _time = time;
            if (time < Norm)
                _isNorm = true;
            else
                _isNorm = false;
        }
        public void Print()
        {
            Console.Write($"{_famile,-15} {_group,-12} {_famileP,-12}");
            Console.WriteLine("     {0,6:f2}       {1} ", _time, _isNorm);

        }
        public virtual void PrintTitle()
        {
            Console.WriteLine($"{"Фамилия",-15} {"Группа",-12} {"Преподаватель",-12} {"Результат",-12} {"Сдан норм.",-12}");

        }
    }

    class Cross500 : Sportsmen
    {
        private const int _norm500 = 100;
        private const string _cross = "Кросс 500м";
        public Cross500(string s1, string gr, string s2, double time) : base(s1, gr, s2, time, _norm500)
        { }
       public override void PrintTitle()
        {
            Console.WriteLine();
            Console.Write($"{_cross,-15} ");
            Console.WriteLine("Норматив {0:d} c", _norm500);
            Console.WriteLine($"{"Фамилия",-15} {"Группа",-12} {"Преподаватель",-12} {"Результат",-12} {"Сдан норм.",-12}");
        }
    }
        class Cross100 : Sportsmen
    {
        private const int _norm100 = 18;
        private const string _cross = "Кросс 100м";
        public Cross100(string s1, string gr, string s2, double time):base(s1, gr, s2, time, _norm100)
        {  }
        public override void PrintTitle()
        {
            Console.WriteLine();
            Console.Write($"{_cross,-15} ");
            Console.WriteLine("Норматив {0:d} c", _norm100);
            Console.WriteLine($"{"Фамилия",-15} {"Группа",-12} {"Преподаватель",-12} {"Результат",-12} {"Сдан норм.",-12}");
        }


    }
    internal class Program
    {


            static void Main(string[] args)
            {
                Cross500[] cr500 = new Cross500[]
                {
                    new Cross500("Иванова", "ББИ-23-5", "Шмеерзон", 105.3),
                    new Cross500("Петрова", "ББИ-23-4", "Лавров", 99.23),
                    new Cross500("Сидорова", "ББИ-23-3", "Комзалов", 98.11),
                    new Cross500("Ковальчук", "ББИ-23-2", "Зинчук", 101.2)
                };


                Cross100[] cr100 = new Cross100[]
                {
                    new Cross100("Иванова", "ББИ-23-5", "Шмеерзон", 17.3),
                    new Cross100("Петрова", "ББИ-23-4", "Лавров", 18.23),
                    new Cross100("Сидорова", "ББИ-23-3", "Комзалов", 17.11),
                    new Cross100("Ковальчук", "ББИ-23-2", "Зинчук", 17.2),
                };

                Console.WriteLine("Исходные данные");
                cr100[0].PrintTitle();
                foreach (Cross100 sp in cr100)
                {
                    sp.Print();
                }
                cr500[0].PrintTitle();
                foreach (Cross500 sp in cr500)
                {
                    sp.Print();
                }

                Sort(cr100);
                Sort(cr500);

                Console.WriteLine("После обработки");
                cr100[0].PrintTitle();
                int kol = 0;
                foreach (Cross100 sp in cr100)
                {
                    sp.Print();
                    if (sp.isNorm) kol++;
                }
                Console.WriteLine("Выполнили норматив {0} чел.", kol); 
                cr500[0].PrintTitle();
               
                kol = 0;
                foreach (Cross500 sp in cr500)
                {
                    sp.Print();
                    if (sp.isNorm) kol++;
                }
                Console.WriteLine("Выполнили норматив {0} чел.", kol);
            }
            static void Sort(Sportsmen[] cross)
            {
                int imin;
                for (int i = 0; i < cross.Length - 1; i++)
                {
                    imin = i;

                    for (int j = i + 1; j < cross.Length; j++)
                    {
                        if (cross[j].time < cross[imin].time)
                        {
                            imin = j;
                        }
                    }
                    Sportsmen spTemp = cross[i];
                    cross[i] = cross[imin];
                    cross[imin] = spTemp;
                }
            }
        }
    }

