/*
Соревнования по футболу между командами проводятся в два этапа. Для 
проведения первого этапа участники разбиваются на две группы по 12 команд. 
Для проведения второго этапа выбирается 6 лучших команд каждой группы по 
результатам первого этапа. Составить список команд участников второго этапа.


2.	Создать класс «Футбольная команда» с 2 классами-наследниками: 
«Женская футбольная команда» и «Мужская футбольная команда». 
Провести среди них отдельные соревнования, но вывести в общей таблице 
по 6 лучших женских и мужских команд, отсортированных по общему количеству баллов 
с указанием пола (т.е.: 1. ЦСКА женская команда 13 баллов; 2 Динамо мужская команда 12 баллов; 
3 Спартак мужская команда 10 баллов…). Использовать динамическую связку: преобразование классов.
*/


using System.Collections.Immutable;

abstract class FootballTeam
{
    protected string name;
    protected string _s;
    protected int _wins;
    protected int _loses;
    public int wins => _wins;

    public FootballTeam(string names, string s, int q, int e)
    {
        name = names; _s = s; _wins = q; _loses = e;
    }

    public void Print()
    {
        Console.WriteLine("Название команды    {0}\t {1}\t  Победы {2:f2}",
            name, _s, _wins);
    }

    protected static void Sort(FootballTeam[] a)
    {

        for (int i = 0; i < a.Length - 1; i++)
        {
            double amax = a[i].wins;
            int imax = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j].wins > amax)
                {
                    amax = a[j].wins;
                    imax = j;
                }
            }
            FootballTeam temp;
            temp = a[imax];
            a[imax] = a[i];
            a[i] = temp;
        }
    }


}

class Fteam : FootballTeam
{
    public Fteam(string n, string h, int y, int x) : base(n, h, y, x) { }



}

class MTeam : FootballTeam
{
    public MTeam(string t, string w, int r, int e) : base(t, w, r, e) { }




    internal class Program
    {
        static void Main(string[] args)


        {
            Fteam[] d = new Fteam[]
            {
        new Fteam("Панды", "женская команда", 7, 5),
        new Fteam("Звёзды", "женская команда", 8, 4),
        new Fteam("Ягуары", "женская команда", 2, 10),
        new Fteam("Молния", "женская команда", 3, 9),
        new Fteam("Волки", "женская команда", 3, 9),
        new Fteam("Тигры", "женская команда", 7, 5),
        new Fteam("Ястребы", "женская команда", 5, 7),
        new Fteam("Драконы", "женская команда", 4, 8),
        new Fteam("Друзья", "женская команда", 6, 6),
        new Fteam("Медведи", "женская команда", 5, 7),
        new Fteam("Орлы", "женская команда", 7, 5),
        new Fteam("Котики", "женская команда", 8, 4)

            };

            MTeam[] m = new MTeam[]
            {
        new MTeam("Львы", "мужская команда", 6, 6),
        new MTeam("Смельчаки","мужская команда", 4, 8),
        new MTeam("Ветер", "мужская команда", 7, 5),
        new MTeam("Лисы", "мужская команда", 2, 10),
        new MTeam("Банда","мужская команда", 5, 7),
        new MTeam("Ночь", "мужская команда", 8, 4),
        new MTeam("Воля", "мужская команда", 6, 6),
        new MTeam("Сокол", "мужская команда", 9, 3),
        new MTeam("Стужа","мужская команда", 8, 4),
        new MTeam("Шторм", "мужская команда", 10, 2),
        new MTeam("Комета", "мужская команда", 7, 5),
        new MTeam("Феникс", "мужская команда", 2, 10)
            };

            Sort(d);

            Sort(m);


            FootballTeam[] c = new FootballTeam[12];
            int a, r, f;
            a = r = 0;
            for (f = 0; f < c.Length; f++)
            {
                if (a >= d.Length / 2)
                {
                    c[f] = m[r];
                    r++;
                }
                else if (r >= m.Length / 2)
                {
                    c[f] = d[a];
                    a++;
                }
                else
                            if (d[a].wins > m[r].wins)
                {
                    c[f] = m[r];
                    r++;
                }
                else
                {
                    c[f] = d[a];
                    a++;
                }
            }


            Sort(c);



            Console.WriteLine("Список лучших команд");
            Console.WriteLine();

            foreach (var sportsmen in c)
            {

                { sportsmen.Print(); }
            }




        }
    }

}

