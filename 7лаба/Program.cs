
using System;

class Program
{
    class Uchastnik
    {
        public string Lastname { get; private set; }
        public string Obzhestvo { get; private set; }
        public double Result1 { get; private set; }
        public double Result2 { get; private set; }
        public double Summ { get; private set; }
        public bool Disqualified { get; private set; }

        public Uchastnik(string ln, string obzh, double r1, double r2)
        {
            Lastname = ln;
            Obzhestvo = obzh;
            Result1 = r1;
            Result2 = r2;
            Summ = r1 + r2;
            Disqualified = false;
        }

        public void Disqualify()
        {
            Disqualified = true;
        }
    }

    static void PrintUch(Uchastnik[] uchastniks)
    {
        Console.WriteLine("Фамилия    Общество   FA    SA    Сумма"); //FA-first attempt, SA-second attempt.
        for (int i = 0; i < uchastniks.Length; i++)
        {
            if (!uchastniks[i].Disqualified)
            {
                Console.WriteLine($"{uchastniks[i].Lastname}    {uchastniks[i].Obzhestvo}  {uchastniks[i].Result1}    {uchastniks[i].Result2,-2}    {uchastniks[i].Summ}");
            }
        }
    }

    static void Main()
    {
        Uchastnik[] uchastniks = {
            new Uchastnik("Петров","общество1",8.1,7.3),
            new Uchastnik("Иванов","общество2",7.5, 7.1),
            new Uchastnik("Сидоров","общество3",6.7,6.3),
            new Uchastnik("Крутов", "общество4",7.7,7.8),
            new Uchastnik("Молодов","общество5",7.2,6.9),
        };

        uchastniks[2].Disqualify(); // Дисквалифицируем участника Сидорова

        sortirovka(uchastniks);
        PrintUch(uchastniks);
    }

    static void sortirovka(Uchastnik[] uchastniks)
    {
        for (int i = 0; i < uchastniks.Length; i++)
        {
            for (int j = 0; j < uchastniks.Length - i - 1; j++)
            {
                if (uchastniks[j].Summ < uchastniks[j + 1].Summ)
                {
                    Uchastnik t = uchastniks[j];
                    uchastniks[j] = uchastniks[j + 1];
                    uchastniks[j + 1] = t;
                }
            }
        }
    }
}