using System;
struct Sportsmen
{
    public string familia;
    public string obsh;
    private double _result1, _result2, _result;

    public double result1 => _result1;
    public double result2 => _result2;
    public double result => _result;

    public Sportsmen(string familia1, string obsh1,
    double resultt1, double resultt2)
    {
        familia = familia1;
        obsh = obsh1;
        _result1 = resultt1;
        _result2 = resultt2;
        _result = _result1 + _result2;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] sp = new Sportsmen[5];
        sp[0] = new Sportsmen("макаров", "общество 1", 1.49, 1.54);
        sp[1] = new Sportsmen("пирогов", "общество 2", 1.50, 1.75);
        sp[2] = new Sportsmen("петров", "общество 3", 1.58, 1.5);
        sp[3] = new Sportsmen("сидоров", "общество 4", 1.49, 1.41);
        sp[4] = new Sportsmen("иванов", "общество 5", 1.55, 1.44);

        for (int i = 0; i < sp.Length - 1; i++)
        {
            double maxResult = sp[i].result;
            int indexMax = i;
            for (int j = i + 1; j < sp.Length; j++)
            {
                if (sp[j].result > maxResult)
                {
                    maxResult = sp[j].result;
                    indexMax = j;
                }
            }
            Sportsmen temp;
            temp = sp[indexMax];
            sp[indexMax] = sp[i];
            sp[i] = temp;
        }

        for (int i = 0; i < sp.Length; i++)
        {
            Console.WriteLine("фамилия {0}\t  общество {1}\t 1 попытка {2:f2}  2 попытка {3:f2}  Результат  {4:f2}",
            sp[i].familia, sp[i].obsh, sp[i].result1, sp[i].result2, sp[i].result);
        }
    }
}