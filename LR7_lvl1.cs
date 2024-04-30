

namespace ConsoleApp1
{
    class Program
    {

        abstract class SportData
        {
            protected string Name { get; }
            public double Time { get; }

            protected int Distance;

            protected SportData(string name, double time, int distance)
            {
                Name = name;
                Time = time;
                Distance = distance;
            }

            public void Show()
            {
                Console.WriteLine("{0, 12}: {1:f1} / Ср. скорость: {2:f1} м/c", Name, Time, Distance / Time);
            }

            public static void Sort(SportData[] array)
            {
                int n = array.Length;
                int i, j;
                for (i = 1; i < n; ++i)
                {
                    SportData key = array[i];
                    j = i - 1;

                    while (j >= 0 && array[j].Time > key.Time)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }
                    array[j + 1] = key;
                }
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

            SportData.Sort(rd100);
            SportData.Sort(rd500);

            Console.WriteLine("Бег 100м.");
            foreach (SportData item in rd100)
            {
                item.Show();
            }
            Console.WriteLine("Бег 500м.");
            foreach (SportData item in rd500)
            {
                item.Show();
            }
        }
    }
}
