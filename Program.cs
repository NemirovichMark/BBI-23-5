using System;
class Programm
{ 
    struct Uchastnik
    {
        private string lastname, obzhestvo;
        private double result1, result2, summ;
        public Uchastnik(string ln, string obzh, double r1, double r2)
        {
            lastname = ln;
            obzhestvo = obzh;
            result1 = r1;
            result2 = r2;
            summ = r1 + r2;
        }
        static void PrintUch(Uchastnik[] uchastniks)
        {
            Console.WriteLine("Фамилия    Общество   FA    SA    Сумма"); //FA-first attempt, SA-second attempt.
            for (int i = 0; i < uchastniks.Length; i++)
            {
                Console.WriteLine($"{uchastniks[i].lastname}    {uchastniks[i].obzhestvo}  {uchastniks[i].result1}    {uchastniks[i].result2,-2}    {uchastniks[i].summ}");
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
            sortirovka(uchastniks);
            PrintUch(uchastniks);
        }
        static void sortirovka(Uchastnik[] uchastniks)
        {
            for (int i = 0; i < uchastniks.Length; i++)
            {
                for (int j = 0; j < uchastniks.Length - i - 1; j++)
                {
                    if (uchastniks[j].summ < uchastniks[j + 1].summ)
                    {
                        Uchastnik t = uchastniks[j];
                        uchastniks[j] = uchastniks[j + 1];
                        uchastniks[j + 1] = t;
                    }
                }
            }

        }
    }

}