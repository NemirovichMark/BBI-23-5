/* Соревнования по прыжкам на лыжах со 120-метрового трамплина судят 5 судей.
Каждый судья выставляет оценку за стиль прыжка по 20-балльной шкале. Меньшая
и большая оценки отбрасываются, остальные суммируются. К этой сумме
прибавляются очки за дальность прыжка: 120 метров – 60 очков, за каждый метр
превышения добавляются по 2 очка, при меньшей дальности отнимаются 2 очка за
каждый метр. Получить итоговую таблицу соревнований, содержащую фамилию и
итоговый результат для каждого участника в порядке занятых мест.*/
using System;

namespace lab1
{
    class Res
    {
        public string Surname { get; private set; }
        public int Len { get;private set; }
        private int[] ScList { get; }
        public int Sc { get; private set; }

        public Res(string Surname, int Len, int[] ScList)
        {
            this.Surname = Surname;
            this.Len = Len;
            this.ScList = ScList;
            int Sum = 0, Mx = ScList[0], Mn = ScList[0];
            for (int i = 0; i < ScList.Length; i++)
            {
                Sum += ScList[i];
                Mx = Math.Max(Mx, ScList[i]);
                Mn = Math.Min(Mn, ScList[i]);
            }
            Sum -= Mx + Mn;
            if (Len >= 120)
            {
                Sum += 60 + (Len - 120) * 2;
            }
            else
            {
                Sum -= (120 - Len) * 2;
            }
            this.Sc = Sum;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Res[] m = new Res[4]; // Иванов Петров Сидоров Пупкин 
            m[0] = new Res("Иванов", 123, new int[] { 15, 14, 13, 11, 16 });
            m[1] = new Res("Петров", 111, new int[] { 13, 14, 15, 16, 17 });
            m[2] = new Res("Сидров", 120, new int[] { 16, 19, 20, 18, 17 });
            m[3] = new Res("Пупкин", 119, new int[] { 19, 19, 20, 19, 19 });


            for (int i = 0; i < m.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + m[i].Surname + ": " + m[i].Sc);
            }

            for (int i = 0; i < m.Length - 1; i++)
            {
                double amax = m[i].Sc;
                int imax = i;
                for (int j = i + 1; j < m.Length; j++)
                {
                    if (m[j].Sc > amax)
                    {
                        amax = m[j].Sc;
                        imax = j;
                    }
                }
                Res temp;
                temp = m[imax];
                m[imax] = m[i];
                m[i] = temp;
            }

            Console.WriteLine();
            for (int i = 0; i < m.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + m[i].Surname + ": " + m[i].Sc);
            }

        }
    }
}