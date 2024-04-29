namespace ConsoleApp1
{
    class Program
    {

        abstract class SportHuman
        {
            protected string name { get; }
            protected int team { get; }
            public double time;

            protected SportHuman(string name, double time, int team)
            {
                this.name = name;
                this.team = team;
                this.time = time;
            }

            public void show()
            {
                Console.WriteLine("{0}: {1, 10} - {2:f1} секунд", team, name, time);
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
            static void Sort_man(SportMan[] man, int n)
            {
                int i = 0;
                while (i < n)
                {
                    if (i == 0)
                        i++;
                    if (man[i].time >= man [i - 1].time)
                        i++;
                    else
                    {
                        SportMan  temp = man[i];
                        man[i] = man[i - 1];
                        man[i - 1] = temp;
                        i--;
                    }


                }
            }
            static void Sort_Woman(SportWoman [] woman, int n)
            {
                int i = 0;
                while (i < n)
                {
                    if (i == 0)
                        i++;
                    if (woman[i].time >= woman [i - 1].time)
                        i++;
                    else
                    {
                        SportWoman  temp = woman[i];
                        woman[i] = woman [i - 1];
                        woman[i - 1] = temp;
                        i--;
                    }


                }
            }
            static void Sort_Human(SportHuman [] comman, int n)
            {
                int i = 0;
                while (i < n)
                {
                    if (i == 0)
                        i++;
                    if (comman[i].time >= comman[i - 1].time)
                        i++;
                    else
                    {
                        SportHuman temp = comman[i];
                        comman[i] = comman[i - 1];
                        comman[i - 1] = temp;
                        i--;
                    }


                }
            }
            Sort_man(man, N);
            Sort_Woman(woman, N);
            Sort_Human(common, N);
            Console.WriteLine("-- Мужчины --");
            foreach (SportHuman item in man)
            {
                item.show();
            }
            Console.WriteLine("-- Женщины --");
            foreach (SportHuman item in woman)
            {
                item.show();
            }
            Console.WriteLine("-- Общее --");
            foreach (SportHuman item in common)
            {
                item.show();
            }
        }
    }
}

