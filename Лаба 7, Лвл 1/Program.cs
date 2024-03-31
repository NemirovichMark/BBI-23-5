using System;

abstract class Results
{
    protected string _secondname;
    protected int _group;
    protected string _prepodsecname;
    protected int _rez;
    protected static int _k;
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


    public virtual void Print()
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

class meters100 : Results
{
    private static int _metr = 100;
    public readonly int METR;
    public meters100(string sc, int g, string psc, int r) : base(sc, g, psc, r)
    {
        METR = _metr;
    }
    public override void Print()
    {
        if (time < _rez)
        {
            Console.WriteLine(_metr + ": " + _secondname + " " + _group + " " + _prepodsecname + " " + _rez + " " + "не сдал");
        }
        else
        {
            Console.WriteLine(_metr + ": " + _secondname + " " + _group + " " + _prepodsecname + " " + _rez + " " + "сдал");
            _k++;
        }
    }
}
class meters500 : Results
{
    private static int _metr = 500;
    public readonly int METR;
    public meters500(string sc, int g, string psc, int r) : base(sc, g, psc, r)
    {
        METR = _metr;
    }
}

class Program
{
    static void Main()
    {
        Results.time = Convert.ToDouble(Console.ReadLine());

        meters100 ivanova2 = new meters100("Иванова2", 2, "Тренерова2", 7);

        meters100[] uchastniki100 = new meters100[]
        {
            new meters100("Иванова2", 5, "Тренерова2", 8),
            new meters100("Иванова3", 4, "Тренерова3", 12),
            new meters100("Иванова4", 8, "Тренерова4", 7),
            new meters100("Иванова5", 6, "Тренерова5", 5),
        };

        meters500[] metr500 = new meters500[]
        {
            new meters500("Иванова2", 5, "Тренерова2", 8),
            new meters500("Иванова3", 4, "Тренерова3", 12),
            new meters500("Иванова4", 8, "Тренерова4", 7),
            new meters500("Иванова5", 6, "Тренерова5", 5),
        };

        Sort(uchastniki100);
        Sort(metr500);

        foreach (meters100 metrs100 in uchastniki100)
        {
            metrs100.Print();
        }
        foreach (meters500 metrs500 in metr500)
        {
            metrs500.Print();
        }
        Console.WriteLine(Results.Kop);
    }

    static void Sort(Results[] uchastniki)
    {
        for (int i = 0; i < uchastniki.Length - 1; i++)
        {
            for (int j = i + 1; j < uchastniki.Length; j++)
            {
                if (uchastniki[i].Rez < uchastniki[j].Rez)
                {
                    Results temp = uchastniki[i];
                    uchastniki[i] = uchastniki[j];
                    uchastniki[j] = temp;
                }
            }
        }
    }
}