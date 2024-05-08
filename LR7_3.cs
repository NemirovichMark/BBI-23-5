namespace ConsoleApp1
{
    class Program
    {
        abstract class SportHuman
        {
            protected string Name { get; }
            protected int Team { get; }
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

            public static void MergeSort(SportHuman[] humans, int left, int right)
            {
                if (left < right)
                {
                    int middle = (left + right) / 2;
                    MergeSort(humans, left, middle);
                    MergeSort(humans, middle + 1, right);
                    Merge(humans, left, middle, right);
                }
            }

            public static void Merge(SportHuman[] humans, int left, int middle, int right)
            {
                int n1 = middle - left + 1;
                int n2 = right - middle;

                SportHuman[] leftArray = new SportHuman[n1];
                SportHuman[] rightArray = new SportHuman[n2];

                for (int i = 0; i < n1; ++i)
                    leftArray[i] = humans[left + i];
                for (int j = 0; j < n2; ++j)
                    rightArray[j] = humans[middle + 1 + j];

                int k = left;
                int iLeft = 0, iRight = 0;

                while (iLeft < n1 && iRight < n2)
                {
                    if (leftArray[iLeft].Time <= rightArray[iRight].Time)
                    {
                        humans[k] = leftArray[iLeft];
                        iLeft++;
                    }
                    else
                    {
                        humans[k] = rightArray[iRight];
                        iRight++;
                    }
                    k++;
                }

                while (iLeft < n1)
                {
                    humans[k] = leftArray[iLeft];
                    iLeft++;
                    k++;
                }

                while (iRight < n2)
                {
                    humans[k] = rightArray[iRight];
                    iRight++;
                    k++;
                }
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

            SportHuman.MergeSort(man, 0, N - 1);
            SportHuman.MergeSort(woman, 0, N - 1);
            SportHuman.MergeSort(common, 0, N * 2 - 1);

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
    }
}
