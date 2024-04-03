/*
Для формирования сборной по хоккею предварительно отобрано 30 игроков. На
основании протоколов игр составлена таблица, в которой содержится штрафное
время каждого игрока по каждой игре (2, 5 или 10 мин). Написать программу,
которая составляет список кандидатов в сборную в порядке возрастания
суммарного штрафного времени. Игрок, оштрафованный на 10 мин, из списка
кандидатов исключается.

 8.	Сделать абстрактный класс, и от него создать 2-х наследников: «Хоккей» и «Баскетбол». 
В баскетболе вместо штрафного времени, используется поле «количество фолов» (0 – 5). 
Переопределить базовый метод «Добавить штраф» в каждом из классов-наследников, 
чтобы он изменял соответствующее классу поле. Игроки с 4 и 5 фолами исключаются.
 */

abstract class Sportsmen
{
    protected string name;
    protected int _penaltytime1;
    protected int _penaltytime2;
    protected int _rezz;


    public Sportsmen(string names, int q1, int q2)
    {

        name = names;
        _penaltytime1 = q1;
        _penaltytime2 = q2;
        _rezz = _penaltytime1 + _penaltytime2;

    }

    virtual public void Sort(Sportsmen[] a)
    {

        for (int i = 0; i < a.Length - 1; i++)
        {
            double amax = a[i]._rezz;
            int imax = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j]._rezz < amax)
                {
                    amax = a[j]._rezz;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = a[imax];
            a[imax] = a[i];
            a[i] = temp;
        }
    }

    virtual public void AddPenalty()
    {
        if (_penaltytime1 != 10 & _penaltytime2 != 10)
            Console.WriteLine("Фамилия {0}\t  Результат  {1:f2}",
            name, _rezz);
    }

}

class Basketball : Sportsmen
{
    public Basketball(string n, int y, int x) : base(n, y, x) { }

    override public void AddPenalty()
    {
        if (_penaltytime1 != 4 & _penaltytime2 != 4 & _penaltytime1 != 5 & _penaltytime2 != 5)
            Console.WriteLine("Фамилия {0}\t  Фолы за 1 раунд  {1:f2}\t Фолы за 2 раунд {2:f2}",
            name, _penaltytime1, _penaltytime2);
    }

}

class Hockey : Sportsmen
{
    public Hockey(string t, int r, int e) : base(t, r, e) { }

}



internal class Program
{
    static void Main(string[] args)
    {
        Basketball[] basketball = new Basketball[]
        {

            new Basketball("Катя", 2, 4),
            new Basketball("Инга", 1, 3),
            new Basketball("Маша", 2, 5),
            new Basketball("Вадим", 5, 1),
            new Basketball("Саша", 0, 0),
            new Basketball("Лёша", 2, 2),
            new Basketball("Вова", 3, 2),
            new Basketball("Влад", 2, 5),
            new Basketball("Серёжа", 3, 4),
            new Basketball("Петя", 2, 5),
            new Basketball("Аня", 1, 2),
            new Basketball("Игорь", 4, 5),
            new Basketball("Богдан", 5, 5),
            new Basketball("Макс", 1, 2),
            new Basketball("Настя", 2, 4),
            new Basketball("Варя", 5, 5),
            new Basketball("Ева", 1, 0),
            new Basketball("Олеся", 2, 0),
            new Basketball("Люба", 2, 1),
            new Basketball("Кира", 5, 3),
            new Basketball("Лиза", 5, 1),
            new Basketball("Влада", 0, 5),
            new Basketball("Женя", 0, 0),
            new Basketball("Полина", 2, 1),
            new Basketball("Семён", 2, 2),
            new Basketball("Витя", 5, 2),
            new Basketball("Коля", 2, 1),
            new Basketball("Антон", 3, 2),
            new Basketball("Юра", 2, 4)
        };

        Hockey[] hockey = new Hockey[]
        {

            new Hockey("Катя", 2, 5),
            new Hockey("Инга", 5, 5),
            new Hockey("Маша", 10, 10),
            new Hockey("Вадим", 5, 10),
            new Hockey("Саша", 2, 10),
            new Hockey("Лёша", 5, 2),
            new Hockey("Вова", 10, 2),
            new Hockey("Влад", 10, 10),
            new Hockey("Серёжа", 2, 2),
            new Hockey("Петя", 2, 10),
            new Hockey("Аня", 10, 2),
            new Hockey("Игорь", 10, 5),
            new Hockey("Богдан", 5, 5),
            new Hockey("Макс", 10, 2),
            new Hockey("Настя", 2, 10),
            new Hockey("Варя", 5, 5),
            new Hockey("Ева", 10, 10),
            new Hockey("Олеся", 2, 5),
            new Hockey("Люба", 10, 5),
            new Hockey("Кира", 5, 5),
            new Hockey("Лиза", 5, 10),
            new Hockey("Влада", 10, 5),
            new Hockey("Женя", 10, 10),
            new Hockey("Полина", 2, 10),
            new Hockey("Семён", 2, 2),
            new Hockey("Витя", 5, 2),
            new Hockey("Коля", 2, 10),
            new Hockey("Антон", 10, 2),
            new Hockey("Юра", 2, 2)
        };

        Console.WriteLine("Баскетбол");

        foreach (var b in basketball)
        {
            b.Sort(basketball);
        }

        foreach (var b in basketball)
        {
            b.AddPenalty();
        }

        Console.WriteLine();
        Console.WriteLine("Хоккей");

        foreach (var h in hockey)
        {
            h.Sort(hockey);
        }


        foreach (var h in hockey)
        {
            h.AddPenalty();
        }

    }
}