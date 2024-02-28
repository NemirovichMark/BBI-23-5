/*
Соревнования по футболу между командами проводятся в два этапа. Для 
проведения первого этапа участники разбиваются на две группы по 12 команд. 
Для проведения второго этапа выбирается 6 лучших команд каждой группы по 
результатам первого этапа. Составить список команд участников второго этапа.
*/

using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

struct Sportsmen
{
    public string name;
    private int _wins;
    private int _loses;
    public int wins => _wins;
    public int loses => _loses;

    public Sportsmen(string names, int q, int e)
    {
        name = names;
        _wins = q;
        _loses = e;
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



        for (int i = 0; i < firststage.Length - 1; i++)
        {
            double amax = firststage[i].wins;
            int imax = i;
            for (int j = i + 1; j < firststage.Length; j++)
            {
                if (firststage[j].wins > amax)
                {
                    amax = firststage[j].wins;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = firststage[imax];
            firststage[imax] = firststage[i];
            firststage[i] = temp;
        }

        for (int i = 0; i < secondstage.Length - 1; i++)
        {
            double amax = secondstage[i].wins;
            int imax = i;
            for (int j = i + 1; j < secondstage.Length; j++)
            {
                if (secondstage[j].wins > amax)
                {
                    amax = secondstage[j].wins;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = secondstage[imax];
            secondstage[imax] = secondstage[i];
            secondstage[i] = temp;
        }

        
        Sportsmen[] c = new Sportsmen[12];
        int a, r, f;
        a = r = 0;
        for (f = 0; f < c.Length; f++) 
        {
            if (a >= firststage.Length/2)
            {
                c[f] = secondstage[r];
                r++;
            }
            else if (r >= secondstage.Length/2)
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

        for (int i = 0; i < c.Length - 1; i++)
        {
            double amax = c[i].wins;
            int imax = i;
            for (int j = i + 1; j < c.Length; j++)
            {
                if (c[j].wins > amax)
                {
                    amax = c[j].wins;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = c[imax];
            c[imax] = c[i];
            c[i] = temp;
        }

        Console.WriteLine("Список участников второго этапа:");
        Console.WriteLine();

        for (int k = 0; k < c.Length; k++)
        {
            Console.WriteLine("Название команды {0}\t   Победы {1:f2}\t   Поражения {2:f2}",
            c[k].name, c[k].wins, c[k].loses);

        }

    }
}

