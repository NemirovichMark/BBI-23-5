using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //3 вариант 
    struct Disciple
    {
        private string _name;
        private int _age;
       // private int _maso;
        private double _sredb;
        private bool _statkd;

        public Disciple (string n, int a,  double sb, bool st)
        {
            _name = n;
            _age = a;
            _sredb = sb;
            _statkd = st;
            if (sb == 5.0) 
            { st = true;
              
            }
            
        }
        public void PrintTitle()
        {
            Console.WriteLine("Имя        Возраст     Ср. б   Красный атестат ");
        }
        public void Print()
        {
            Console.Write($"{ _name, -7 }" );
            Console.WriteLine("{0,10:d} {1,10:f1}  ", _age, _sredb, _statkd);
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
