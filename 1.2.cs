using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
   
    internal class Program
    {
        public const int Norm = 100;//норматив
        struct Sportsmen
        {
            private string _famile;
            private string _group;
            private string _famileP;
            private double _time;
            private bool _isNorm;
            public double time => _time;
            public bool isNorm => _isNorm;
             public  Sportsmen(string s1, string gr, string s2, double time)
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
            public void PrintTitle()
            {
                Console.WriteLine($"{"Фамилия",-15} {"Группа",-12} {"Преподаватель",-12} {"Результат",-12} {"Сдан норм.",-12}");

            }
        }

        static void Main(string[] args)
        {
            Sportsmen[] rezults = new Sportsmen[4];
            rezults[0] = new Sportsmen("Иванова", "ББИ-23-5", "Шмеерзон", 105.3);
            rezults[1] = new Sportsmen("Петрова", "ББИ-23-4", "Лавров", 99.23);
            rezults[2] = new Sportsmen("Сидорова", "ББИ-23-3", "Комзалов", 98.11);
            rezults[3] = new Sportsmen("Ковальчук", "ББИ-23-2", "Зинчук", 101.2);
 
            Console.WriteLine("Исходные данные");
            rezults[0].PrintTitle();
            for (int i=0;i<rezults.Length;i++)
            {
                rezults[i].Print();
            }

            int imin; Sportsmen spTemp = new Sportsmen();   
            for (int i=0; i<rezults.Length-1; i++)
            {
                imin= i;
                
                for (int j=i+1;j<rezults.Length; j++)
                {
                    if (rezults[j].time < rezults[imin].time)
                    {
                        imin = j;
                    }
                }
                spTemp = rezults[i];
                rezults[i] = rezults[imin];
                rezults[imin] = spTemp;
            }

            int kol = 0;
            for (int i=0; i<rezults.Length; i++)
            {
                if (rezults[i].isNorm)
                {
                    kol ++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("После обработки");
            rezults[0].PrintTitle();
            for (int i = 0; i < rezults.Length; i++)
            {
                rezults[i].Print();
            }
            Console.WriteLine("Сдали норматив {0}", kol );
        }
    }
}
