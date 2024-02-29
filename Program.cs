//Обработать результаты первенства по футболу. Результаты каждой игры заданы
//в виде названий команд и счета (количество забитых и пропущенных мячей).
//Сформировать таблицу очков (выигрыш – 3, ничья – 1, проигрыш – 0) и
//упорядочить результаты в соответствии с занятым местом. Если сумма очков у
//двух команд одинакова, то сравниваются разности забитых и пропущенных
//мячей. Вывести результирующую таблицу, содержащую место, название
//команды, количество очков.
using System;

namespace lab1
{
    class Team
    {
        public string Name { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }
        public int Goal { get; set; }
        public int Miss { get; set; }
        public int Score { get; set; }

        public Team(string Name)
        {
            this.Name = Name;
            this.Win = 0;
            this.Lose = 0;
            this.Draw = 0;
            this.Goal = 0;
            this.Miss = 0;
            this.Score = 0;
        }

        public static bool operator ==(Team A, Team B)
        {
            return A.Name == B.Name;
        }

        public static bool operator !=(Team A, Team B)
        {
            return A.Name != B.Name;
        }
    }

    class Match
    {
        public Team[] T { get; set; }
        public int n { get; set; }

        public Match()
        {
            this.T = new Team[100];
            this.n = 0;
        }

        public void Add(string NameA, string NameB, int a, int b)
        {
            int A = 0, B = 0, C = 0;
            if (a > b) A++;
            if (a < b) B++;
            if (a == b) C++;
            bool f = false;
            for (int i = 0; i < n; i++)
            {
                if (T[i].Name == NameA)
                {
                    T[i].Win += A;
                    T[i].Lose += B;
                    T[i].Draw += C;
                    T[i].Goal += a;
                    T[i].Miss += b;
                    T[i].Score += A * 3 + C * 1;
                    f = true;
                    break;
                }
            }
            if (!f)
            {
                T[n] = new Team(NameA);
                T[n].Win += A;
                T[n].Lose += B;
                T[n].Draw += C;
                T[n].Goal += a;
                T[n].Miss += b;
                T[n].Score += A * 3 + C * 1;
                n++;
            }

            f = false;
            for (int i = 0; i < n; i++)
            {
                if (T[i].Name == NameB)
                {
                    T[i].Win += B;
                    T[i].Lose += A;
                    T[i].Draw += C;
                    T[i].Goal += b;
                    T[i].Miss += a;
                    T[i].Score += B * 3 + C * 1;
                    f = true;
                    break;
                }
            }
            if (!f)
            {
                T[n] = new Team(NameB);
                T[n].Win += B;
                T[n].Lose += A;
                T[n].Draw += C;
                T[n].Goal += b;
                T[n].Miss += a;
                T[n].Score += B * 3 + C * 1;
                n++;
            }
        }

        public void Sort()
        {
            for (int i = 0; i < n - 1; i++)
            {
                double amax = T[i].Score;
                int imax = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (T[i].Score > amax) //|| (T[i].Score == amax && (T[i].Win - T[i].Lose < T[imax].Win - T[imax].Lose))
                    {
                        amax = T[i].Score;
                        imax = j;
                    }
                }
                Team temp;
                temp = T[imax];
                T[imax] = T[i];
                T[i] = temp;
            }
        }
    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            Match M = new Match();
            M.Add("G", "D", 4, 0);
            M.Add("K", "W", 5, 2);
            M.Add("V", "Z", 1, 3);
            M.Add("G", "Z", 3, 2);
            M.Add("K", "D", 1, 0);
            M.Add("W", "V", 2, 1);
            M.Add("K", "V", 2, 2);

            M.Sort();

            for (int i = 0; i < M.n; i++)
            {
                Console.WriteLine(i + 1 + ". " + M.T[i].Name + ": " + M.T[i].Score);
            }
        }
    }
}