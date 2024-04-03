using System;

class Chelovek
{
    protected int _pred1;
    protected int _pred2;
    protected int _pred3;
    protected int _pred4;
    protected string _name;
    protected double _sr;

    public int Pred1
    {
        get { return _pred1; }
        private set { _pred1 = value; }
    }
    public int Pred2
    {
        get { return _pred2; }
        private set { _pred2 = value; }
    }
    public int Pred3
    {
        get { return _pred3; }
        private set { _pred3 = value; }
    }
    public int Pred4
    {
        get { return _pred4; }
        private set { _pred4 = value; }
    }
    public double Sredn
    {
        get { return _sr; }
        private set { _sr = value; }
    }
    public Chelovek(string nm, int p1, int p2, int p3, int p4)
    {
        _pred1 = p1;
        _pred2 = p2;
        _pred3 = p3;
        _pred4 = p4;
        _name = nm;
        _sr = getsred();
    }

    protected double getsred()
    {
        return (_pred1 + _pred2 + _pred3 + _pred4) / 4.0;
    }

    public virtual void Print()
    {
        if (_sr >= 4)
        {
            Console.WriteLine(_name + ": " + _pred1 + " " + _pred2 + " " + _pred3 + " " + _pred4 + " Sred: " + _sr);
        }
        else
        {
            Console.WriteLine(_name + ": " + _pred1 + " " + _pred2 + " " + _pred3 + " " + _pred4 + " Sred: " + _sr + " Не прошел по баллам");
        }
    }
}

class Student : Chelovek
{
    private static int _studak = 0;

    public readonly int Studak;

    public Student(int p1, int p2, int p3, int p4, string nm) : base(nm, p1, p2, p3, p4)
    {
        _studak++;
        Studak = _studak;
    }

    public override void Print()
    {
        if (_sr >= 4)
        {
            Console.WriteLine("СтудБилет № " + Studak + " " + _name + ": " + _pred1 + " " + _pred2 + " " + _pred3 + " " + _pred4 + " Sred: " + _sr);
        }
        else
        {
            Console.WriteLine("СтудБилет № " + Studak + " " + _name + ": " + _pred1 + " " + _pred2 + " " + _pred3 + " " + _pred4 + " Sred: " + _sr + " Не прошел по баллам");
        }
    }
}

class Program
{
    static void Main()
    {
        Chelovek smert = new Chelovek("Иванов1", 4, 3, 5, 4);
        Chelovek[] ocenki = new Chelovek[]
        {
            new Student(4, 5, 3, 4, "Иванов1"),
            new Student(5, 5, 5, 3, "Иванов2"),
            new Student(4, 5, 5, 2, "Иванов3"),
            new Student(2, 2, 2, 2, "Иванов4"),
        };
        Sort(ocenki, 0, ocenki.Length - 1);
        foreach (Chelovek rezultati in ocenki)
        {
            rezultati.Print();
        }
    }

    static void Sort(Chelovek[] ocenki, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Razdelenie(ocenki, low, high);

            Sort(ocenki, low, pivotIndex - 1);
            Sort(ocenki, pivotIndex + 1, high);
        }
    }

    static int Razdelenie(Chelovek[] ocenki, int low, int high)
    {
        double pivot = ocenki[high].Sredn;
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (ocenki[j].Sredn > pivot)
            {
                i++;

                Chelovek temp = ocenki[i];
                ocenki[i] = ocenki[j];
                ocenki[j] = temp;
            }
        }

        Chelovek temp1 = ocenki[i + 1];
        ocenki[i + 1] = ocenki[high];
        ocenki[high] = temp1;

        return i + 1;
    }

}