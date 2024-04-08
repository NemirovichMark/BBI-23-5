abstract class Sportsmen
{
    protected string familiya;
    protected int group;
    protected string fam_prepod;
    protected double rez;

    public Sportsmen(string Familiya, int Group, string Fam_prepod, double Rez)
    {
        familiya = Familiya;
        group = Group;
        fam_prepod = Fam_prepod;
        rez = Rez;
    }

    public double Rez
    {
        get { return rez; }
    }

    public static void PrintTabl()
    {
        Console.WriteLine($"{"Фамилия",-20} {"Группа",-10} {"Фамилия преподователя",-20} {"Результат",-20}");
    }


    public virtual void Print()
    {
        Console.WriteLine($"{familiya,-20} {group,-10} {fam_prepod,-25} {rez,-20}");
    }
}

class run500 : Sportsmen
{
    public run500(string Familiya, int Group, string Fam_prepod, double Rez) : base(Familiya, Group, Fam_prepod, Rez) { }

    public override void Print()
    {
        Console.WriteLine();
        Console.WriteLine("Забег на 500 метров:");
        base.Print();
    }
}

class run1000 : Sportsmen
{
    public run1000(string Familiya, int Group, string Fam_prepod, double Rez) : base(Familiya, Group, Fam_prepod, Rez) { }

    public override void Print()
    {
        Console.WriteLine();
        Console.WriteLine("Забег на 1000 метров:");
        base.Print();
    }
}

class Program
{
    static void Main(string[] args)
    {
        run500[] run500s = new run500[5];
        run500s[0] = new run500("Runner 1.1", 5, "A", 41.2);
        run500s[1] = new run500("Runner 2.1", 3, "B", 40.6);
        run500s[2] = new run500("Runner 3.1", 2, "C", 45.0);
        run500s[3] = new run500("Runner 4.1", 6, "D", 28.89);
        run500s[4] = new run500("Runner 5.1", 1, "F", 34.1);

        ShellSort(run500s);
        Sportsmen.PrintTabl();
        foreach (var runner in run500s)
        {
            runner.Print();
        }

        run1000[] run1000s = new run1000[5];
        run1000s[0] = new run1000("Runner 1.2", 2, "E", 61.2);
        run1000s[1] = new run1000("Runner 2.2", 1, "G", 59.6);
        run1000s[2] = new run1000("Runner 3.2", 3, "H", 60.91);
        run1000s[3] = new run1000("Runner 4.2", 4, "J", 59.98);
        run1000s[4] = new run1000("Runner 5.2", 5, "K", 63.2);

        ShellSort(run1000s);
        Sportsmen.PrintTabl();
        foreach (var runner in run1000s)
        {
            runner.Print();
        }

    }

    static void ShellSort(Sportsmen[] runs)
    {
        int n = runs.Length;
        int step = n / 2;
        while (step > 0)
        {
            for (int i = step; i < n; i++)
            {
                Sportsmen temp = runs[i];
                int j = i;
                while (j >= step && runs[j - step].Rez < temp.Rez)
                {
                    runs[j] = runs[j - step];
                    j -= step;
                }
                runs[j] = temp;
            }
            step /= 2;
        }
    }
}