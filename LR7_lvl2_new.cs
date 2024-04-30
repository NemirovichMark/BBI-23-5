using System;

namespace ConsoleApp1
{
    class Program
    {
        abstract class SportHuman
        {
            public string Name { get; }
            public int Team { get; }
            public double Time { get; }

            protected SportHuman(string name, double time, int team)
            {
                Name = name;
                Team = team;
                Time = time;
            }

            public void Show()
            {
                Console.WriteLine("{0}: {1, 10} - {2:f1} секунд", Team, Name, Time);
            }
        }

        class SportMan : SportHuman
        {
            public SportMan(string name, double time) : base(name, time, 0) { }
        }

        class SportWoman : SportHuman
        {
            public SportWoman(string name, double time) : base(name, time, 1) { }
        }

        static void Main(string[] args)
        {
            const int N = 5;
            string[] surnames_f = {
                "Ivanova",
                "Petrova",
                "Rudenko",
                "Klochay",
                "Vasnecova",
                "Kan",
                "Romanova",
                "Smolina",
                "Darmograi",
            };

            string[] surnames_m = {
                "Ivanov",
                "Petrov",
                "Rudenko",
                "Klochay",
                "Vasnecov",
                "Kan",
                "Romanov",
                "Smolin",
                "Kuchuk",
            };
            Random rand = new Random();
            SportMan[] man = new SportMan[N];
            SportWoman[] woman = new SportWoman[N];
            SportHuman[] common = new SportHuman[N * 2];
            for (int i = 0; i < N; i++)
            {
                string surname = surnames_f[rand.Next(surnames_f.Length - 1)];
                double time = rand.NextDouble() * 45 + 60;
                woman[i] = new SportWoman(surname, time);
                common[i] = woman[i];
            }
            for (int i = 0; i < N; i++)
            {
                string surname = surnames_m[rand.Next(surnames_m.Length - 1)];
                double time = rand.NextDouble() * 60 + 50;
                man[i] = new SportMan(surname, time);
                common[i + N] = man[i];
            }

            Sort_Human(common, N * 2);

            Console.WriteLine("-- Мужчины --");
            foreach (SportHuman item in man)
            {
                item.Show();
            }
            Console.WriteLine("-- Женщины --");
            foreach (SportHuman item in woman)
            {
                item.Show();
            }
            Console.WriteLine("-- Общее --");
            foreach (SportHuman item in common)
            {
                item.Show();
            }
        }

        static void Sort_Human(SportHuman[] humans, int n)
        {
            int i = 0;
            while (i < n)
            {
                if (i == 0)
                    i++;
                if (humans[i].Time >= humans[i - 1].Time)
                    i++;
                else
                {
                    SportHuman temp = humans[i];
                    humans[i] = humans[i - 1];
                    humans[i - 1] = temp;
                    i--;
                }
            }
        }
    }
}
