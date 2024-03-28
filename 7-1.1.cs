/* 
Результаты соревнований по прыжкам в длину определяются по сумме двух
попыток. В протоколе для каждого участника указываются: фамилия, общество,
результаты первой и второй попыток. Вывести протокол в виде таблицы с
заголовком в порядке занятых мест.

1. Добавить поле «дисквалификация» и метод, который позволяет дисквалифицировать участника. 
В итоговую таблицу такие участники входить не должны. 

*/



struct Sportsmen
{
    private string famile;
    private string society;
    private double _rez1, _rez2, _rez;
    private string _disqualification;
    public Sportsmen(string famile1, string society1,
    double rezz1, double rezz2, string disqualification)
    {
        famile = famile1;
        society = society1;
        _rez1 = rezz1;
        _rez2 = rezz2;
        _rez = _rez1 + _rez2;
        _disqualification = disqualification;
    }

    public void Disqualification()
    {
        if (_disqualification != "дисквалифицирован")
        {

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
        sp[0] = new Sportsmen("Иванов", "Юмористы", 1.50, 1.52, "дисквалифицирован");
        sp[1] = new Sportsmen("Петров", "Синяя Лагуна", 1.55, 1.80, "нарушений нет");
        sp[2] = new Sportsmen("Сидоров", "Солнце", 1.47, 1.50, "дисквалифицирован");
        sp[3] = new Sportsmen("Любимов", "Хмурая Туча", 1.46, 1.43, "нарушений нет");
        sp[4] = new Sportsmen("Макаров", "Фонарь", 1.64, 1.41, "нарушений нет");
        sp[5] = new Sportsmen("Зайцев", "Удача", 1.24, 1.47, "нарушений нет");
        sp[6] = new Sportsmen("Костин", "Символ", 1.59, 1.40, "дисквалифицирован");
        sp[7] = new Sportsmen("Мишкин", "Небеса", 1.52, 1.64, "нарушений нет");
        sp[8] = new Sportsmen("Рябинин", "Радость", 1.62, 1.57, "нарушений нет");

        foreach (var sportsmen in sp)
        {
            sportsmen.Sort(sp);
        }
        foreach (var sportsmen in sp)
        {
            sportsmen.Disqualification();
        }
    }
}