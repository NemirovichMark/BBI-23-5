
class Program
{        
    struct Lizhniki
    {
        private string lastname;
        private int group;
        public double deltatime;

        public Lizhniki(string ln, int gr, double dt)
        {
            lastname = ln;
            group = gr;
            deltatime = dt;
        }

        public void Print(int place)
        {
            Console.WriteLine(" {0, 3}  {1, 3}  {2, 10}  {3}m {4, 2:f0}s ", place, group, lastname, Math.Floor(deltatime / 60), 60 * (deltatime / 60 - Math.Floor(deltatime / 60)));
        }

    }
    static void Main(string[] args)
    {


        int N = 10;
        Random rand = new Random();
        string[] lastnames =
        {
            "Бе",
            "Большунов",
            "Шипулин",
            "Иванов",
            "Кленов",
            "Джака",
            "Володцев",
            "Ярмолин",
            "Дамирбаев",
        };

        Lizhniki[] results = new Lizhniki[N];
        for (int i = 0; i < N; i++)
        {
            int lastnamesIndex = rand.Next(lastnames.Length);
            double result = 120 + rand.NextDouble() *100;
            Lizhniki snowData = new Lizhniki(lastnames[lastnamesIndex], i % 2, result);
            results[i] = snowData;
        }
        static void Sort(Lizhniki[] results, int n)
        {
            int i = 0;
            while (i < n)
            {
                if (i == 0)
                    i++;
                if (results[i].deltatime >= results[i - 1].deltatime)
                    i++;
                else
                {
                    Lizhniki t = results[i];
                    results[i] = results[i - 1];
                    results[i - 1] = t;
                    i--;
                }


            }
        }
        Sort(results, N);
        Console.WriteLine("Место  Группа Фамилия  Время");
        
        int place = 1;
        foreach (Lizhniki data in results)
        {
            data.Print(place++);
        }

    }
}