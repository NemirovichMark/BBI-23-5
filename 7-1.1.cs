struct Sportsmen
{
    private string famile;
    private string society;
    public double _rez1 { get; private set; }
    public double _rez2 { get; private set; }
    private double _rez;

    public Sportsmen(string famile1, string society1,
    double rezz1, double rezz2)
    {
        famile = famile1;
        society = society1;
        _rez1 = rezz1;
        _rez2 = rezz2;
        _rez = _rez1 + _rez2;
    }

    public void Disqualification()
    {
        if (_rez1 != 0 && _rez2 != 0)
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
        sp[0] = new Sportsmen("Иванов", "Юмористы", 0, 1.52);
        sp[1] = new Sportsmen("Петров", "Синяя Лагуна", 1.55, 1.80);
        sp[2] = new Sportsmen("Сидоров", "Солнце", 1.47, 1.50);
        sp[3] = new Sportsmen("Любимов", "Хмурая Туча", 1.46, 0);
        sp[4] = new Sportsmen("Макаров", "Фонарь", 1.64, 1.41);
        sp[5] = new Sportsmen("Зайцев", "Удача", 1.24, 1.47);
        sp[6] = new Sportsmen("Костин", "Символ", 0, 1.40);
        sp[7] = new Sportsmen("Мишкин", "Небеса", 1.52, 1.64);
        sp[8] = new Sportsmen("Рябинин", "Радость", 1.62, 0);

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