using System;
struct Lizhniki
{
    public string lastname;
    public double result1, result2,summ;
    public Lizhniki(string ln,double r1,double r2)
    {
        lastname = ln;
        result1 = r1;
        result2 = r2;
        summ = r1 + r2;
    }

}
class Programm
{
    static void Main()
    {
        Lizhniki[] lizhnikis = {
            new Lizhniki("Большунов",35,32),
            new Lizhniki("Шипулин",38,36),
            new Lizhniki("Устюгов",40,35),
            new Lizhniki("Клебо",37,34),
            new Lizhniki("БЁ",36,37),
        };
        sort1Group(lizhnikis);
        printtabl1(lizhnikis);
        sort2Group(lizhnikis);
        printtabl2(lizhnikis);
        sortobzhGroup(lizhnikis);
        printtablobzh(lizhnikis);
    }
    static void sort1Group(Lizhniki[] lizhnikis)
    {
        for (int i = 0; i < lizhnikis.Length; i++)
        {
            for(int j =0; j<lizhnikis.Length-i-1;j++)
            {
                if (lizhnikis[j].result1 > lizhnikis[j+1].result1)
                {
                    Lizhniki t = lizhnikis[j];
                    lizhnikis[j] = lizhnikis[j + 1];
                    lizhnikis[j + 1] = t;
                }
            }
        }
    }
    static void sort2Group(Lizhniki[] lizhnikis)
    {
        for (int i = 0; i < lizhnikis.Length; i++)
        {
            for (int j = 0; j < lizhnikis.Length - i - 1; j++)
            {
                if (lizhnikis[j].result2 > lizhnikis[j + 1].result2)
                {
                    Lizhniki t = lizhnikis[j];
                    lizhnikis[j] = lizhnikis[j + 1];
                    lizhnikis[j + 1] = t;
                }
            }
        }
    }
    static void sortobzhGroup(Lizhniki[] lizhnikis)
    {
        for (int i = 0; i < lizhnikis.Length; i++)
        {
            for (int j = 0; j < lizhnikis.Length - i - 1; j++)
            {
                if (lizhnikis[j].summ > lizhnikis[j + 1].summ)
                {
                    Lizhniki t = lizhnikis[j];
                    lizhnikis[j] = lizhnikis[j + 1];
                    lizhnikis[j + 1] = t;
                }
            }
        }
    }
    static void printtabl1(Lizhniki[] lizhnikis)
    {
        Console.WriteLine("1 Группа");
        Console.WriteLine("Фамилия     результат");
        for(int i =0; i<lizhnikis.Length;i++)
        {
            Console.WriteLine($"{lizhnikis[i].lastname,-14}  {lizhnikis[i].result1}");
        }
    }
    static void printtabl2(Lizhniki[] lizhnikis)
    {
        Console.WriteLine("2 Группа");
        Console.WriteLine("Фамилия     результат");
        for (int i = 0; i < lizhnikis.Length; i++)
        {
            Console.WriteLine($"{lizhnikis[i].lastname,-14}  {lizhnikis[i].result2}");
        }
    }
    static void printtablobzh(Lizhniki[] lizhnikis)
    {
        Console.WriteLine("Общая Группа");
        Console.WriteLine("Фамилия     результат");
        for (int i = 0; i < lizhnikis.Length; i++)
        {
            Console.WriteLine($"{lizhnikis[i].lastname,-14}  {lizhnikis[i].summ}");
        }
    }
}
