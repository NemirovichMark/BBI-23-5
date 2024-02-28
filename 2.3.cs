using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    struct Sportsmen
    {
        private string _famile;
        private double [] _tests;
        private double _best;
        public double best => _best;

       
        public Sportsmen(string s1, double[] len)
        {
            _famile = s1;

            _tests = len;
            _best = len[0];
            for(int i = 1; i < len.Length; i++)
            {
                if (len[i] > _best) { 
                _best = len[i];}
            }

        }
        public void Print()
        {
            Console.Write($"{_famile,-15}");
            for(int i =0; i < _tests.Length; i++)
            {
                Console.Write(" {0:f2}",_tests[i]);
            }
              
            Console.WriteLine("   {0:f2}", _best);

        }
        public void PrintTitle()
        {
            Console.WriteLine("Фамилия            Попытки      Лучший Рез.");

        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {
              Sportsmen[] rezults = new Sportsmen[8];
              rezults[0] = new Sportsmen("Иванова", new double[] {5.56, 5.83, 5.73});
              rezults[1] = new Sportsmen("Петрова", new double[] { 5.96, 5.75, 5.78});
              rezults[2] = new Sportsmen("Сидорова", new double[] { 5.76, 6.02, 5.99 });
              rezults[3] = new Sportsmen("Ковальчук", new double[] { 5.86, 6.01, 5.97});
              rezults[4] = new Sportsmen("Морозова", new double[] { 5.96, 5.83, 5.75 });
              rezults[5] = new Sportsmen("Травина", new double[] { 5.86, 5.85, 5.78 });
              rezults[6] = new Sportsmen("Семенова", new double[] { 5.76, 6.01, 5.89});
              rezults[7] = new Sportsmen("Фургал", new double[] { 5.89, 5.93, 5.97 });
   
            Console.WriteLine("Исходные данные");
            rezults[0].PrintTitle();
            for (int i = 0; i < rezults.Length; i++)
            {
                rezults[i].Print();
            }

            int imax; Sportsmen spTemp = new Sportsmen();
            for (int i = 0; i < rezults.Length - 1; i++)
            {
                imax = i;

                for (int j = i + 1; j < rezults.Length; j++)
                {
                    if (rezults[j].best > rezults[imax].best)
                    {
                        imax= j;
                    }
                }
                spTemp = rezults[i];
                rezults[i] = rezults[imax];
                rezults[imax] = spTemp;
            }
            Console.WriteLine();
            Console.WriteLine("После обработки");
            rezults[0].PrintTitle();
            for (int i = 0; i < rezults.Length; i++)
            {
                rezults[i].Print();
            }

        }
    }
}
