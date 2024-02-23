using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
class Program
{        /*
         Лыжные гонки проводятся отдельно для двух групп участников. Результаты соревнований заданы в виде фамилий участников и их результатов в каждой группе. 
        Расположить результаты соревнований в каждой группе в порядке занятых мест. 
        Объединить результаты обеих групп с сохранением упорядоченности и вывести в виде таблицы с заголовком.
         */
    struct SnowData
    {
        private string surname;
        private int group;
        public double deltaTime;

        public SnowData(string _surname, int _group, double _deltaTime)
        {
            surname = _surname;
            group = _group;
            deltaTime = _deltaTime;
        }

        public void Print (int place)
        {
            Console.WriteLine("| {0, 3} | {1, 3} | {2, 10} | {3}m {4, 2:f0}s |", place, group, surname, Math.Floor(deltaTime / 60), 60 * (deltaTime / 60 - Math.Floor(deltaTime / 60)));
        }

    }
    static void Main(string[] args)
    {

        
        int N = 20;
        Random rand = new Random();
        string[] surnames =
        {
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

        SnowData[] results = new SnowData[N];
        for (int i = 0; i < N; i++)
        {
            int surnameIndex = rand.Next(surnames.Length);
            double result = 120 + rand.NextDouble() * 100;
            SnowData snowData = new SnowData(surnames[surnameIndex], i % 2, result);
            results[i] = snowData;
        }
        static void Sort(SnowData[] results, int n)
        {
            int i = 0;
            while (i < n)
            {
                if (i == 0)
                    i++;
                if (results [i].deltaTime >= results [i - 1].deltaTime)
                    i++;
                else
                {
                    SnowData  temp = results [i];
                    results [i] = results [i - 1];
                    results [i - 1] = temp;
                    i--;
                }


            }
        }
        Sort(results, N);
        Console.WriteLine("|Place|Group| Surname    | Time   |");
        Console.WriteLine("|/////|/////|////////////|////////|");
        int place = 1;
        foreach (SnowData data in results )
        {
            data.Print(place++);
        }

    }
}

