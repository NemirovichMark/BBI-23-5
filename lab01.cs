/*Результаты соревнований по прыжкам в высоту определяются по лучшей из двух попыток. Вывести список участников в порядке занятых мест.*/


namespace lab1
{
    class Sportsmen
    {
        public string FIO { get; set; }
        public double Res1 { get; set; }
        public double Res2 { get; set; }
        public double Res { get; set; }

        public Sportsmen(string FIO, double Res1, double Res2)
        {
            this.FIO = FIO;
            this.Res1 = Res1;
            this.Res2 = Res2;
            this.Res = Math.Max(Res1, Res2);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Sportsmen[] Players = new Sportsmen[4];
            Players[0] = new Sportsmen("Иванов      Иван        Иванович    ", 1.50, 1.53);
            Players[1] = new Sportsmen("Пупкин      Василий     Васильевич  ", 1.47, 1.36);
            Players[2] = new Sportsmen("Пушкин      Александр   Сергеевич   ", 1.52, 1.45);
            Players[3] = new Sportsmen("Лермонтов   Михаил      Юрьевич     ", 1.49, 1.61);

            for (int i = 0; i < Players.Length; i++)
            {
                Console.WriteLine(Players[i].FIO + " " + Players[i].Res);
            }
            Console.WriteLine();

            for (int i = 0; i < Players.Length - 1; i++)
            {
                double amax = Players[i].Res;
                int imax = i;
                for (int j = i + 1; j < Players.Length; j++)
                {
                    if (Players[j].Res > amax)
                    {
                        amax = Players[j].Res;
                        imax = j;
                    }
                }
                Sportsmen temp;
                temp = Players[imax];
                Players[imax] = Players[i];
                Players[i] = temp;
            }

            for (int i = 0; i < Players.Length; i++)
            {
                Console.WriteLine(Players[i].FIO + " " + Players[i].Res);
            }

        }
    }
}