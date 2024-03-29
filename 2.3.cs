using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3
{

    abstract class Disciplina
    {
        protected string _namedis;
        protected string _famile;
        protected double[] _tests;
        protected double _best;
        public double best => _best;


        public Disciplina(string nd, string s1, double[] len)
        {
            _namedis = nd;
            _famile = s1;

            _tests = len;
            _best = len[0];
            for (int i = 1; i < len.Length; i++)
            {
                if (len[i] > _best)
                {
                    _best = len[i];
                }
            }

        }
        public virtual void Print()
        {
            Console.Write($"{_famile,-15}");
            for (int i = 0; i < _tests.Length; i++)
            {
                Console.Write(" {0:f2}", _tests[i]);
            }

            Console.WriteLine("   {0:f2}", _best);

        }
        public virtual void PrintTitle()
        {
            Console.WriteLine("Название дисциплины: {0}", _namedis);
            Console.WriteLine("Фамилия            Попытки      Лучший Рез.");

        }
    }
    class JumpL : Disciplina
    {

        new private const string  _namedis = "Прыжок в длину";
       
        public JumpL( string s1, double[] len) : base(_namedis, s1, len)
        { 
            
        
        }

    }

    class JumpH : Disciplina
    {

        new private const string _namedis = "Прыжок в высоту";

        public JumpH(string s1, double[] len) : base(_namedis, s1, len)
        {


        }
   }


    internal class Program
    {


        static void Main(string[] args)
        {
            JumpL[] rezultsL = new JumpL[] { 
            new JumpL("Иванова", new double[] { 5.56, 5.83, 5.73 }),
            new JumpL("Петрова", new double[] { 5.96, 5.75, 5.78 }),
            new JumpL("Сидорова", new double[] { 5.76, 6.02, 5.99 }),
            new JumpL("Ковальчук", new double[] { 5.86, 6.01, 5.97 }),
            new JumpL("Морозова", new double[] { 5.96, 5.83, 5.75 }),
            new JumpL("Травина", new double[] { 5.86, 5.85, 5.78 }),
            new JumpL("Семенова", new double[] { 5.76, 6.01, 5.89 }),
            new JumpL("Фургал", new double[] { 5.89, 5.93, 5.97 })
            };
            JumpH[] rezultsH = new JumpH[]{
            new JumpH("Иванова", new double[] { 2.06, 1.83, 2.30 }),
            new JumpH("Петрова", new double[] { 1.96, 1.75, 1.78 }),
            new JumpH("Сидорова", new double[] { 2.26, 1.98, 2.40 }),
            new JumpH("Морозова", new double[] { 1.97, 1.83, 2.35 }),
            new JumpH("Ковальчук", new double[] { 2.32, 2.21, 2.39})
            };

            Console.WriteLine("Исходные данные");
            OutMas(rezultsL);
            OutMas(rezultsH);
            Sort(rezultsL);
            Sort(rezultsH);

            Console.WriteLine();
            Console.WriteLine("После обработки");
            OutMas(rezultsL);
            OutMas(rezultsH);
     
        }
        static void Sort(Disciplina[] rezults)
        {
            int imax; 
            for (int i = 0; i < rezults.Length - 1; i++)
            {
                imax = i;

                for (int j = i + 1; j < rezults.Length; j++)
                {
                    if (rezults[j].best > rezults[imax].best)
                    {
                        imax = j;
                    }
                }
                Disciplina spTemp = rezults[i];
                rezults[i] = rezults[imax];
                rezults[imax] = spTemp;
            }
        }
        static void OutMas(Disciplina[] rezults)
        {
            Console.WriteLine();
            rezults[0].PrintTitle();
            foreach (Disciplina tmp in rezults)
            {
                tmp.Print();
            }
        }
    }
}
