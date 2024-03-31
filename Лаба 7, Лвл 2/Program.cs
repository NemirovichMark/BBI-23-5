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
            new Student(3, 3, 5, 2, "Иванов3"),
            new Student(5, 5, 5, 5, "Иванов4"),
        };
        Sort(ocenki);
        foreach (Chelovek rezultati in ocenki)
        {
            rezultati.Print();
        }
    }

    static void Sort(Chelovek[] ocenki)
    {
        int n = ocenki.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (ocenki[j].Sredn < ocenki[j + 1].Sredn)
                {
                    Chelovek temp = ocenki[j];
                    ocenki[j] = ocenki[j + 1];
                    ocenki[j + 1] = temp;
                }
            }
        }
    }
}