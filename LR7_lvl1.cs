namespace ConsoleApp1
{
    class Program
    {

        abstract class SportData
        {
            protected string name { get; }
            public double time { get; }

            protected int distance;

            protected SportData(string name, double time, int distance)
            {
                this.name = name;
                this.time = time;
                this.distance = distance;
            }

            public void show()
            {
                Console.WriteLine("{0, 12}: {1:f1} / Ср. скорость: {2:f1} м/c", name, time, distance / time);
            }

        }

        class RunData100 : SportData
        {
            public RunData100(string name, double time) : base(name, time, 100) { }

            
        }

        class RunData500 : SportData
        {
            public RunData500(string name, double time) : base(name, time, 500) { }

            
        }

        static void Main(string[] args)
        {
            const int N = 10;
            string[] surnames = {
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
            Random rand = new Random();
            RunData100[] rd100 = new RunData100[N];
            RunData500[] rd500 = new RunData500[N];
            for (int i = 0; i < N; i++)
            {
                string surname = surnames[rand.Next(surnames.Length - 1)];
                double time = rand.NextDouble() * 10 + 12;
                rd100[i] = new RunData100(surname, time);
            }
            for (int i = 0; i < N; i++)
            {
                string surname = surnames[rand.Next(surnames.Length - 1)];
                double time = rand.NextDouble() * 10 + 70;
                rd500[i] = new RunData500(surname, time);
            }
            
            static void Sort100 (RunData100[] rd, int n)
            {
                int i = 0;
                while (i < n)
                {
                    if (i == 0)
                        i++;
                    if (rd[i].time >= rd[i - 1].time)
                        i++;
                    else
                    {
                        RunData100 temp = rd[i];
                        rd[i] = rd[i - 1];
                        rd[i - 1] = temp;
                        i--;
                    }


                }
            }
            static void Sort500(RunData500[] rd, int n)
            {
                int i = 0;
                while (i < n)
                {
                    if (i == 0)
                        i++;
                    if (rd[i].time >= rd[i - 1].time)
                        i++;
                    else
                    {
                        RunData500 temp= rd[i];
                        rd[i] = rd[i - 1];
                        rd[i - 1] = temp;
                        i--;
                    }


                }
            }
            Sort100(rd100, N);
            Sort500(rd500, N);
            Console.WriteLine("Бег 100м.");
            foreach (SportData item in rd100)
            {
                item.show();
            }
            Console.WriteLine("Бег 500м.");
            foreach (SportData item in rd500)
            {
                item.show();
            }
        }
    }
}