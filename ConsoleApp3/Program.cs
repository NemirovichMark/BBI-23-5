//НОМЕР 2
//сеттеры сделать приватными, и все предметы запистаь в один массив


using System;

struct Sessia
{
    private int[] _preds;
    private string _name;
    private double _sr;

    public double Sredn
    {
        get { return _sr; }
        private set { _sr = value; }
    }

    public Sessia(string nm, params int[] kolvo_ocen)
    {
        _preds = kolvo_ocen;
        _name = nm;
        _sr = GetSredn();
    }

    private double GetSredn()
    {
        double sum = 0;
        foreach (int predmet in _preds)
        {
            sum += predmet;
        }
        return sum / _preds.Length;
    }

    public void Print()
    {
        if (_sr >= 4)
        {
            Console.WriteLine(_name + ": " + string.Join(" ", _preds) + " Sred: " + _sr);
        }
        else
        {
            Console.WriteLine(_name + ": " + string.Join(" ", _preds) + " Sred: " + _sr + " Не прошел по баллам");
        }
    }
}

class Program
{
    static void Main()
    {
        Sessia smert = new Sessia("Иванов1", 4, 3, 5, 4);
        Sessia[] ocenki = new Sessia[]
        {
            new Sessia("Иванов1", 4, 5, 3, 4),
            new Sessia("Иванов2", 5, 5, 5, 3),
            new Sessia("Иванов3", 3, 3, 5, 2),
            new Sessia("Иванов4", 5, 5, 5, 5),
        };
        Sort(ocenki);
        foreach (Sessia rezultati in ocenki)
        {
            rezultati.Print();
        }
    }

    static void Sort(Sessia[] ocenki)
    {
        int i = 0;
        int j = 1;
        while (j < ocenki.Length - 1)
        {
            if (i < 0 || ocenki[i].Sredn >= ocenki[i + 1].Sredn)
            {
                i = j;
                j++;
            }
            while (i >= 0 && ocenki[i].Sredn < ocenki[i + 1].Sredn)
            {
                Sessia temp = ocenki[i];
                ocenki[i] = ocenki[i + 1];
                ocenki[i + 1] = temp;
                i--;
            }
        }
    }
}