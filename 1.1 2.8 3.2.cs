using System;
using System.Text.RegularExpressions;
// 1 номер
/*
struct Sportsmen
{
    private string famile;
    private string society;
    private double _rez1, _rez2, _rez;

    public Sportsmen(string famile1, string society1,
    double rezz1, double rezz2)
    {
        famile = famile1;
        society = society1;
        _rez1 = rezz1;
        _rez2 = rezz2;
        _rez = _rez1 + _rez2;
    }

    public void Print()
    {
        Console.WriteLine("Фамилия {0}\t  Общество {1}\t 1 попытка {2:f2}  2 попытка {3:f2}  Результат  {4:f2}",
            famile, society, _rez1, _rez2, _rez);

    }

    public void Sort(Sportsmen[] a)
    {

        {
            int i = 0, j = 1; 
            while (j < a.Length - 1)
            {
                if (i < 0 || a[i]._rez >= a[i + 1]._rez)
                {
                    i = j;
                    j++;
                }
                while (i >= 0 && a[i]._rez < a[i + 1]._rez)
                {
                    Sportsmen temp = a[i]; 
                    a[i] = a[i + 1];
                    a[i + 1] = temp; 
                    i--;
                }
            }
        }
    }

}
class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] sp = new Sportsmen[5];
        sp[0] = new Sportsmen("Иванов", "Юмористы", 1.50, 1.52);
        sp[1] = new Sportsmen("Петров", "Синяя Лагуна", 1.55, 1.80);
        sp[2] = new Sportsmen("Сидоров", "Солнце", 1.47, 1.50);
        sp[3] = new Sportsmen("Любимов", "Хмурая Туча", 1.46, 1.43);
        sp[4] = new Sportsmen("Макаров", "Фонарь", 1.54, 1.44);


        foreach (var sportsmen in sp)
        {
            sportsmen.Sort(sp);
        }

        foreach (var sportsmen in sp)
        {
            sportsmen.Print();
        }


    }
}
*/

// 2 номер
/*
struct Sportsmen
{
    private string name;
    private int _penaltytime1;
    private int _penaltytime2;
    private int _rezz;

    public int rezz => _rezz;

    public Sportsmen(string names, int q1, int q2)
    {

        name = names;
        _penaltytime1 = q1;
        _penaltytime2 = q2;
        _rezz = _penaltytime1 + _penaltytime2;

    }

    public void Print()
    {
        if (_penaltytime1 != 10 & _penaltytime2 != 10)
            Console.WriteLine("Фамилия {0}\t  Результат  {1:f2}",
            name, _rezz);
    }

}

internal class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] sportsmens = new Sportsmen[30];
        sportsmens[0] = new Sportsmen("Катя", 2, 5);
        sportsmens[1] = new Sportsmen("Инга", 5, 5);
        sportsmens[2] = new Sportsmen("Маша", 10, 10);
        sportsmens[3] = new Sportsmen("Вадим", 5, 10);
        sportsmens[4] = new Sportsmen("Саша", 2, 10);
        sportsmens[5] = new Sportsmen("Лёша", 5, 2);
        sportsmens[6] = new Sportsmen("Вова", 10, 2);
        sportsmens[7] = new Sportsmen("Влад", 10, 10);
        sportsmens[8] = new Sportsmen("Серёжа", 2, 2);
        sportsmens[9] = new Sportsmen("Яна", 5, 2);
        sportsmens[10] = new Sportsmen("Петя", 2, 10);
        sportsmens[11] = new Sportsmen("Аня", 10, 2);
        sportsmens[12] = new Sportsmen("Игорь", 10, 5);
        sportsmens[13] = new Sportsmen("Богдан", 5, 5);
        sportsmens[14] = new Sportsmen("Макс", 10, 2);
        sportsmens[15] = new Sportsmen("Настя", 2, 10);
        sportsmens[16] = new Sportsmen("Варя", 5, 5);
        sportsmens[17] = new Sportsmen("Ева", 10, 10);
        sportsmens[18] = new Sportsmen("Олеся", 2, 5);
        sportsmens[19] = new Sportsmen("Люба", 10, 5);
        sportsmens[20] = new Sportsmen("Кира", 5, 5);
        sportsmens[21] = new Sportsmen("Лиза", 5, 10);
        sportsmens[22] = new Sportsmen("Влада", 10, 5);
        sportsmens[23] = new Sportsmen("Женя", 10, 10);
        sportsmens[24] = new Sportsmen("Полина", 2, 10);
        sportsmens[25] = new Sportsmen("Семён", 2, 2);
        sportsmens[26] = new Sportsmen("Витя", 5, 2);
        sportsmens[27] = new Sportsmen("Коля", 2, 10);
        sportsmens[28] = new Sportsmen("Антон", 10, 2);
        sportsmens[29] = new Sportsmen("Юра", 2, 2);


        for (int i = 0; i < sportsmens.Length - 1; i++)
        {
            double amax = sportsmens[i].rezz;
            int imax = i;
            for (int j = i + 1; j < sportsmens.Length; j++)
            {
                if (sportsmens[j].rezz < amax)
                {
                    amax = sportsmens[j].rezz;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = sportsmens[imax];
            sportsmens[imax] = sportsmens[i];
            sportsmens[i] = temp;
        }

        foreach (var sportsmen in sportsmens)
        {
            sportsmen.Print();
        }

    }
}
*/

// 3 номер
/*
struct Sportsmen
{
    private string name;
    private int _wins;
    private int _loses;

    public int wins => _wins;

    public Sportsmen(string names, int q, int e)
    {
        name = names;
        _wins = q;
        _loses = e;
    }

    public void Print()
    {
        Console.WriteLine("Название команды {0}\t   Победы {1:f2}\t   Поражения {2:f2}",
            name, _wins, _loses);
    }

    public void Sort(Sportsmen[] a)
    {

        for (int i = 0; i < a.Length - 1; i++)
        {
            double amax = a[i]._wins;
            int imax = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j]._wins > amax)
                {
                    amax = a[j]._wins;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = a[imax];
            a[imax] = a[i];
            a[i] = temp;
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] firststage = new Sportsmen[12];
        firststage[0] = new Sportsmen("Панды", 7, 5);
        firststage[1] = new Sportsmen("Звёзды", 8, 4);
        firststage[2] = new Sportsmen("Ягуары", 2, 10);
        firststage[3] = new Sportsmen("Молния", 3, 9);
        firststage[4] = new Sportsmen("Волки", 3, 9);
        firststage[5] = new Sportsmen("Тигры", 7, 5);
        firststage[6] = new Sportsmen("Ястребы", 5, 7);
        firststage[7] = new Sportsmen("Драконы", 4, 8);
        firststage[8] = new Sportsmen("Друзья", 6, 6);
        firststage[9] = new Sportsmen("Медведи", 5, 7);
        firststage[10] = new Sportsmen("Орлы", 7, 5);
        firststage[11] = new Sportsmen("Котики", 8, 4);

        Sportsmen[] secondstage = new Sportsmen[12];
        secondstage[0] = new Sportsmen("Львы", 6, 6);
        secondstage[1] = new Sportsmen("Смельчаки", 4, 8);
        secondstage[2] = new Sportsmen("Ветер", 7, 5);
        secondstage[3] = new Sportsmen("Лисы", 2, 10);
        secondstage[4] = new Sportsmen("Банда", 5, 7);
        secondstage[5] = new Sportsmen("Ночь", 8, 4);
        secondstage[6] = new Sportsmen("Воля", 6, 6);
        secondstage[7] = new Sportsmen("Сокол", 9, 3);
        secondstage[8] = new Sportsmen("Стужа", 8, 4);
        secondstage[9] = new Sportsmen("Шторм", 10, 2);
        secondstage[10] = new Sportsmen("Комета", 7, 5);
        secondstage[11] = new Sportsmen("Феникс", 2, 10);




        foreach (var sportsmen in firststage)
        {
            sportsmen.Sort(firststage);
        }
        foreach (var sportsmen in secondstage)
        {
            sportsmen.Sort(secondstage);
        }

        Sportsmen[] c = new Sportsmen[12];
        int a, r, f;
        a = r = 0;
        for (f = 0; f < c.Length; f++)
        {
            if (a >= firststage.Length / 2)
            {
                c[f] = secondstage[r];
                r++;
            }
            else if (r >= secondstage.Length / 2)
            {
                c[f] = firststage[a];
                a++;
            }
            else
                        if (firststage[a].wins > secondstage[r].wins)
            {
                c[f] = secondstage[r];
                r++;
            }
            else
            {
                c[f] = firststage[a];
                a++;
            }
        }

        foreach (var sportsmen in c)
        {
            sportsmen.Sort(c);
        }

        Console.WriteLine("Список участников второго этапа:");
        Console.WriteLine();

        
        foreach (var sportsmen in c)
        {
            
            { sportsmen.Print(); }
        }


    }
}
*/