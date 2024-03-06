//НОМЕР 1 
//Задание: сеттеры сделать приватными, переделать сортировку на вставкой, добавить i--.



using System;
using System.Runtime.ExceptionServices;
struct Results
{
    private string _secondname;
    private int _group;
    private string _prepodsecname;
    private int _rez;
    private static int _k;
    public static double time;
    public int Group
    {
        get { return _group; }
        private set { _group = value; }
    }
    public int Rez
    {
        get { return _rez; }
        private set { _rez = value; }
    }
    public static int Kop
    {
        get { return _k; }
        private set { _k = value; }
    }
    public Results(string sc, int g, string psc, int r)
    {
        _secondname = sc;
        _group = g;
        _prepodsecname = psc;
        _rez = r;
    }


    public void Print()
    {
        if (time < _rez)
        {
            Console.WriteLine(_secondname + " " + _group + " " + _prepodsecname + " " + _rez + " " + "не сдал");
        }
        else
        {
            Console.WriteLine(_secondname + " " + _group + " " + _prepodsecname + " " + _rez + " " + "сдал");
            _k++;
        }
    }
}
class Program
{
    static void Main()
    {
        Results.time = System.Convert.ToDouble(Console.ReadLine());
        Results ivanova2 = new Results("Иванова2", 2, "Тренерова2", 7);

        Results[] uchastniki = new Results[]
        {
            new Results("Иванова2", 5, "Тренерова2", 8),
            new Results("Иванова3", 4, "Тренерова3", 12),
            new Results("Иванова4", 8, "Тренерова4", 7),
            new Results("Иванова5", 6, "Тренерова5", 5),
        };
        Sort(uchastniki);
        foreach (Results rezultati in uchastniki)
        {
            rezultati.Print();
        }
        Console.WriteLine(Results.Kop);
    }
    static void Sort(Results[] uchastniki)
    {
        for (int i = 1; i < uchastniki.Length; i++)
        {
            Results k = uchastniki[i];
            int j = i - 1;
            while (j >= 0 && uchastniki[j].Rez > k.Rez)
            {
                uchastniki[j + 1] = uchastniki[j];
                j--;
            }
            uchastniki[j + 1] = k;
        }
    }
}