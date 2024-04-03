
// 1 номер

/* 
Результаты соревнований по прыжкам в длину определяются по сумме двух
попыток. В протоколе для каждого участника указываются: фамилия, общество,
результаты первой и второй попыток. Вывести протокол в виде таблицы с
заголовком в порядке занятых мест.
1. Добавить поле «дисквалификация» и метод, который позволяет дисквалифицировать участника. 
В итоговую таблицу такие участники входить не должны. 
*/

/* 
struct Sportsmen
{
    private string famile;
    private string society;
    private double _rez1;
    private double _rez2;
    private double _rez;
    private string _disqualification;

    public Sportsmen(string famile1, string society1,
    double rezz1, double rezz2)
    {
        famile = famile1;
        society = society1;
        _rez1 = rezz1;
        _rez2 = rezz2;
        _rez = _rez1 + _rez2; _disqualification = string.Empty;
    }

    public void Disqualification(Sportsmen[] a)
    {
        a[2]._disqualification = "дисквалифицирован";
        a[5]._disqualification = "дисквалифицирован";
        a[6]._disqualification = "дисквалифицирован";
    }

    public void Print()
    {
        {
           if (_disqualification != "дисквалифицирован")
                Console.WriteLine("Фамилия {0}\t  Общество {1}\t 1 попытка {2:f2}  2 попытка {3:f2}  Результат  {4:f2}",
                    famile, society, _rez1, _rez2, _rez);
            
        }
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
        Sportsmen[] sp = new Sportsmen[9];
        sp[0] = new Sportsmen("Иванов", "Юмористы", 1.57, 1.52);
        sp[1] = new Sportsmen("Петров", "Синяя Лагуна", 1.55, 1.80);
        sp[2] = new Sportsmen("Сидоров", "Солнце", 1.47, 1.50);
        sp[3] = new Sportsmen("Любимов", "Хмурая Туча", 1.46, 1.54);
        sp[4] = new Sportsmen("Макаров", "Фонарь", 1.64, 1.41);
        sp[5] = new Sportsmen("Зайцев", "Удача", 1.24, 1.47);
        sp[6] = new Sportsmen("Костин", "Символ", 1.43, 1.40);
        sp[7] = new Sportsmen("Мишкин", "Небеса", 1.52, 1.64);
        sp[8] = new Sportsmen("Рябинин", "Радость", 1.62, 1.65);

        foreach (var sportsmen in sp)
        {
            sportsmen.Disqualification(sp);
        }

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

// 3 номер

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

    public static void Sort(FootballTeam[] a)
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


}

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

        FootballTeam.Sort(d);

        FootballTeam.Sort(m);


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


        FootballTeam.Sort(c);



            Console.WriteLine("Список лучших команд");
            Console.WriteLine();

            foreach (var sportsmen in c)
            {

                { sportsmen.Print(); }
            }


        }
    }

