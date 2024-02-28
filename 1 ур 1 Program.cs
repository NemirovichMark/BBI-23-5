/*
Результаты соревнований по прыжкам в длину определяются по сумме двух
попыток. В протоколе для каждого участника указываются: фамилия, общество,
результаты первой и второй попыток. Вывести протокол в виде таблицы с
заголовком в порядке занятых мест.
*/


using System;
struct Sportsmen
{
    public string famile;
    public string society;
    private double _rez1, _rez2, _rez;

    public double rez1 => _rez1;
    public double rez2 => _rez2;
    public double rez => _rez;

    public Sportsmen(string famile1, string society1,
    double rezz1, double rezz2)
    {
        famile = famile1;
        society = society1;
        _rez1 = rezz1;
        _rez2 = rezz2;
        _rez = _rez1 + _rez2;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] sp = new Sportsmen[5];
        sp[0] = new Sportsmen("Иванов", "Юмористы", 1.50, 1.52);
        sp[1] = new Sportsmen("Петров", "Синяя лагуна", 1.55, 1.8);
        sp[2] = new Sportsmen("Сидоров", "Солнце", 1.47, 1.5);
        sp[3] = new Sportsmen("Любимов", "Хмурая туча", 1.46, 1.43);
        sp[4] = new Sportsmen("Макаров", "Фонарь", 1.54, 1.44);


        for (int i = 0; i < sp.Length - 1; i++)
        {
            double amax = sp[i].rez;
            int imax = i;
            for (int j = i + 1; j < sp.Length; j++)
            {
                if (sp[j].rez > amax)
                {
                    amax = sp[j].rez;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = sp[imax];
            sp[imax] = sp[i];
            sp[i] = temp;
        }


        for (int i = 0; i < sp.Length; i++)
        {
            Console.WriteLine("Фамилия {0}\t  Общество {1}\t 1 попытка {2:f2}  2 попытка {3:f2}  Результат  {4:f2}",
            sp[i].famile, sp[i].society, sp[i].rez1, sp[i].rez2, sp[i].rez);
        }


    }
}