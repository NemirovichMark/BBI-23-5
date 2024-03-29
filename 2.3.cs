abstract class Subject
{
    protected string name_subjict;
    private string familiya;
    private double try1;
    private double try2;
    private double try3;
    public Subject(string NameSubject, string Familiya, double Try1, double Try2, double Try3)
    {
        name_subjict = NameSubject;
        familiya = Familiya;
        try1 = Try1;
        try2 = Try2;
        try3 = Try3;
    }
    public double TheBestTry()
    {
        double max = try1;
        if (try2 > max)
        {
            max = try2;
        }
        if (try3 > max)
        {
            max = try3;
        }
        return max;
    }

    public virtual void PrintTabl()
    {
        Console.WriteLine($"{name_subjict,-25} ");
       Console.WriteLine($"{"Фамилия",-25} {"Попытка 1",-25} {"Попытка 2",-25} {"Попытка 3",-25}");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

    }
    public void Print()
    {
        Console.WriteLine($"{familiya,-25} {try1,-25} {try2,-25} {try3,-25}");
        Console.WriteLine("Лучший результат: {0:f1}", TheBestTry());
    }

}
class JumpUp : Subject
{

    public JumpUp(string name_subject, string familiya, double try1, double try2, double try3) : base(name_subject, familiya, try1, try2, try3)
    {

    }
    public override void PrintTabl()
    {
        //Console.WriteLine("Прыжок в высоту");
        base.PrintTabl();
    }
}
class JumpLong : Subject
{
    public JumpLong(string name_subject, string familiya, double try1, double try2, double try3) : base(name_subject, familiya, try1, try2, try3)
    {

    }
    public override void PrintTabl()
    {
        Console.WriteLine();
 
        base.PrintTabl();
    }
}
class Program
{
    static void Main(string[] args)
    {
        JumpUp[] JU = new JumpUp[5];
        JU[0] = new JumpUp("Прыжок в высоту", "Sportsmen 1.1", 2.5, 1.9, 1.2);
        JU[1] = new JumpUp("Прыжок в высоту", "Sportsmen 1.2", 1.43, 1.1, 1.3);
        JU[2] = new JumpUp("Прыжок в высоту", "Sportsmen 1.3", 1.9, 1.2, 1.32);
        JU[3] = new JumpUp("Прыжок в высоту", "Sportsmen 1.4", 1.5, 1.7, 1.23);
        JU[4] = new JumpUp("Прыжок в высоту", "Sportsmen 1.5", 1.2, 1.5, 1.9);

        double[] bestTries = new double[JU.Length];
        for (int i = 0; i < JU.Length; i++)
        {
            bestTries[i] = JU[i].TheBestTry();
        }

        Sort(bestTries);


        JumpUp[] SortSportsmen = new JumpUp[JU.Length];
        for (int i = 0; i < JU.Length; i++)
        {
            foreach (var sportsman in JU)
            {
                if (sportsman.TheBestTry() == bestTries[i])
                {
                    SortSportsmen[i] = sportsman;
                    break;
                }
            }
        }
        for (int i = 0; i < 1; i++)
        {
            JU[i].PrintTabl();

        }
        foreach (var sportsman in SortSportsmen)
        {
            sportsman.Print();
        }

        JumpLong[] JL = new JumpLong[5];
        JL[0] = new JumpLong("Прыжок в длину", "Sportsmen 2.1", 4.1, 3.9, 4.0);
        JL[1] = new JumpLong("Прыжок в длину", "Sportsmen 2.2", 3.8, 3.77, 3.53);
        JL[2] = new JumpLong("Прыжок в длину", "Sportsmen 2.3", 4.33, 4.16, 3.98);
        JL[3] = new JumpLong("Прыжок в длину", "Sportsmen 2.4", 3.46, 3.96, 3.64);
        JL[4] = new JumpLong("Прыжок в длину", "Sportsmen 2.5", 4.32, 3.39, 4.1);

        double[] BestTries = new double[JL.Length];
        for (int i = 0; i < JL.Length; i++)
        {
            BestTries[i] = JL[i].TheBestTry();
        }

        Sort(BestTries);


        JumpLong[] Sort_Sportsmen = new JumpLong[JL.Length];
        for (int i = 0; i < JL.Length; i++)
        {
            foreach (var sportsman in JL)
            {
                if (sportsman.TheBestTry() == BestTries[i])
                {
                    Sort_Sportsmen[i] = sportsman;
                    break;
                }
            }
        }
        for (int i = 0; i < 1; i++)
        {
            JL[i].PrintTabl();

        }
        foreach (var sportsman in Sort_Sportsmen)
        {
            sportsman.Print();
        }
    }
    static void Sort(double[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; ++i)
        {
            double k = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > k)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = k;
        }
    }
}
//abstract class Subject
//{
//    private string name_subjict;
//    private string familiya;
//    private double try1;
//    private double try2;
//    private double try3;
//    public Subject(string NameSubject, string Familiya, double Try1, double Try2, double Try3)
//    {
//        name_subjict = NameSubject;
//        familiya = Familiya;
//        try1 = Try1;
//        try2 = Try2;
//        try3 = Try3;
//    }
//    public double TheBestTry()
//    {
//        double max = try1;
//        if (try2 > max)
//        {
//            max = try2;
//        }
//        if (try3 > max)
//        {
//            max = try3;
//        }
//        return max;
//    }

//    public virtual void PrintTabl()
//    {

//        Console.WriteLine($"{"Название дисциплины",-25} {"Фамилия",-25} {"Попытка 1",-25} {"Попытка 2",-25} {"Попытка 3",-25}");
//        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

//    }
//    public void Print()
//    {
//        Console.WriteLine($"{name_subjict,-25} {familiya,-25} {try1,-25} {try2,-25} {try3,-25}");
//        Console.WriteLine("Лучший результат: {0:f1}", TheBestTry());
//    }

//}
//class JumpUp : Subject
//{

//    public JumpUp(string name_subject, string familiya, double try1, double try2, double try3) : base(name_subject, familiya, try1, try2, try3)
//    {

//    }
//    public override void PrintTabl()
//    {
//        Console.WriteLine("Прыжок в высоту");
//        base.PrintTabl();
//    }
//}
//class JumpLong : Subject
//{
//    public JumpLong(string name_subject, string familiya, double try1, double try2, double try3) : base(name_subject, familiya, try1, try2, try3)
//    {

//    }
//    public override void PrintTabl()
//    {
//        Console.WriteLine();
//        Console.WriteLine("Прыжок в длину");
//        base.PrintTabl();
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        JumpUp[] JU = new JumpUp[5];
//        JU[0] = new JumpUp("Прыжок в высотку", "Sportsmen 1.1", 2.5, 1.9, 1.2);
//        JU[1] = new JumpUp("Прыжок в высотку", "Sportsmen 1.2", 1.43, 1.1, 1.3);
//        JU[2] = new JumpUp("Прыжок в высотку", "Sportsmen 1.3", 1.9, 1.2, 1.32);
//        JU[3] = new JumpUp("Прыжок в высотку", "Sportsmen 1.4", 1.5, 1.7, 1.23);
//        JU[4] = new JumpUp("Прыжок в высотку", "Sportsmen 1.5", 1.2, 1.5, 1.9);

//        double[] bestTries = new double[JU.Length];
//        for (int i = 0; i < JU.Length; i++)
//        {
//            bestTries[i] = JU[i].TheBestTry();
//        }

//        Sort(bestTries);


//        JumpUp[] SortSportsmen = new JumpUp[JU.Length];
//        for (int i = 0; i < JU.Length; i++)
//        {
//            foreach (var sportsman in JU)
//            {
//                if (sportsman.TheBestTry() == bestTries[i])
//                {
//                    SortSportsmen[i] = sportsman;
//                    break;
//                }
//            }
//        }
//        for (int i = 0; i < 1; i++)
//        {
//            JU[i].PrintTabl();

//        }
//        foreach (var sportsman in SortSportsmen)
//        {
//            sportsman.Print();
//        }

//        JumpLong[] JL = new JumpLong[5];
//        JL[0] = new JumpLong("Прыжок в высотку", "Sportsmen 2.1", 4.1, 3.9, 4.0);
//        JL[1] = new JumpLong("Прыжок в высотку", "Sportsmen 2.2", 3.8, 3.77, 3.53);
//        JL[2] = new JumpLong("Прыжок в высотку", "Sportsmen 2.3", 4.33, 4.16, 3.98);
//        JL[3] = new JumpLong("Прыжок в высотку", "Sportsmen 2.4", 3.46, 3.96, 3.64);
//        JL[4] = new JumpLong("Прыжок в высотку", "Sportsmen 2.5", 4.32, 3.39, 4.1);

//        double[] BestTries = new double[JL.Length];
//        for (int i = 0; i < JL.Length; i++)
//        {
//            BestTries[i] = JL[i].TheBestTry();
//        }

//        Sort(BestTries);


//        JumpLong[] Sort_Sportsmen = new JumpLong[JL.Length];
//        for (int i = 0; i < JL.Length; i++)
//        {
//            foreach (var sportsman in JL)
//            {
//                if (sportsman.TheBestTry() == BestTries[i])
//                {
//                    Sort_Sportsmen[i] = sportsman;
//                    break;
//                }
//            }
//        }
//        for (int i = 0; i < 1; i++)
//        {
//            JL[i].PrintTabl();

//        }
//        foreach (var sportsman in Sort_Sportsmen)
//        {
//            sportsman.Print();
//        }
//    }
//    static void Sort(double[] array)
//    {
//        int n = array.Length;
//        for (int i = 1; i < n; ++i)
//        {
//            double k = array[i];
//            int j = i - 1;

//            while (j >= 0 && array[j] > k)
//            {
//                array[j + 1] = array[j];
//                j = j - 1;
//            }
//            array[j + 1] = k;
//        }
//    }
//}
//abstract class Subject
//{
//    private string name_subjict;

//    public Subject(string NameSubject)
//    {
//        name_subjict = NameSubject;
//    }
//    public double TheBestTry()
//    {
//        double max = try1;
//        if (try2 > max)
//        {
//            max = try2;
//        }
//        if (try3 > max)
//        {
//            max = try3;
//        }
//        return max;
//    }

//    public virtual void PrintTabl()
//    {

//        Console.WriteLine($"{"Название дисциплины",-25} {"Фамилия",-25} {"Попытка 1",-25} {"Попытка 2",-25} {"Попытка 3",-25}");
//        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------");

//    }

//}
//class JumpUp : Subject
//{
//    private string familiya;
//    private double try1;
//    private double try2;
//    private double try3;
//    public JumpUp(string name_subject, string familiya, double try1, double try2, double try3) : base(name_subject)
//    {

//    }
//    public override void PrintTabl()
//    {
//        Console.WriteLine("Прыжок в высоту");
//        base.PrintTabl();
//    }
//    public void Print()
//    {
//        Console.WriteLine($"{familiya,-25} {try1,-25} {try2,-25} {try3,-25}");
//        Console.WriteLine("Лучший результат: {0:f1}", TheBestTry());
//    }
//}
//class JumpLong : Subject
//{
//    public JumpLong(string name_subject, string familiya, double try1, double try2, double try3) : base(name_subject)
//    {

//    }
//    public override void PrintTabl()
//    {
//        Console.WriteLine();
//        Console.WriteLine("Прыжок в длину");
//        base.PrintTabl();
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {
//        JumpUp[] JU = new JumpUp[5];
//        JU[0] = new JumpUp("Sportsmen 1.1", 2.5, 1.9, 1.2);
//        JU[1] = new JumpUp("Прыжок в высотку", "Sportsmen 1.2", 1.43, 1.1, 1.3);
//        JU[2] = new JumpUp("Прыжок в высотку", "Sportsmen 1.3", 1.9, 1.2, 1.32);
//        JU[3] = new JumpUp("Прыжок в высотку", "Sportsmen 1.4", 1.5, 1.7, 1.23);
//        JU[4] = new JumpUp("Прыжок в высотку", "Sportsmen 1.5", 1.2, 1.5, 1.9);

//        double[] bestTries = new double[JU.Length];
//        for (int i = 0; i < JU.Length; i++)
//        {
//            bestTries[i] = JU[i].TheBestTry();
//        }

//        Sort(bestTries);


//        JumpUp[] SortSportsmen = new JumpUp[JU.Length];
//        for (int i = 0; i < JU.Length; i++)
//        {
//            foreach (var sportsman in JU)
//            {
//                if (sportsman.TheBestTry() == bestTries[i])
//                {
//                    SortSportsmen[i] = sportsman;
//                    break;
//                }
//            }
//        }
//        for (int i = 0; i < 1; i++)
//        {
//            JU[i].PrintTabl();

//        }
//        foreach (var sportsman in SortSportsmen)
//        {
//            sportsman.Print();
//        }

//        JumpLong[] JL = new JumpLong[5];
//        JL[0] = new JumpLong("Прыжок в высотку", "Sportsmen 2.1", 4.1, 3.9, 4.0);
//        JL[1] = new JumpLong("Прыжок в высотку", "Sportsmen 2.2", 3.8, 3.77, 3.53);
//        JL[2] = new JumpLong("Прыжок в высотку", "Sportsmen 2.3", 4.33, 4.16, 3.98);
//        JL[3] = new JumpLong("Прыжок в высотку", "Sportsmen 2.4", 3.46, 3.96, 3.64);
//        JL[4] = new JumpLong("Прыжок в высотку", "Sportsmen 2.5", 4.32, 3.39, 4.1);

//        double[] BestTries = new double[JL.Length];
//        for (int i = 0; i < JL.Length; i++)
//        {
//            BestTries[i] = JL[i].TheBestTry();
//        }

//        Sort(BestTries);


//        JumpLong[] Sort_Sportsmen = new JumpLong[JL.Length];
//        for (int i = 0; i < JL.Length; i++)
//        {
//            foreach (var sportsman in JL)
//            {
//                if (sportsman.TheBestTry() == BestTries[i])
//                {
//                    Sort_Sportsmen[i] = sportsman;
//                    break;
//                }
//            }
//        }
//        for (int i = 0; i < 1; i++)
//        {
//            JL[i].PrintTabl();

//        }
//        foreach (var sportsman in Sort_Sportsmen)
//        {
//            sportsman.Print();
//        }
//    }
//    static void Sort(double[] array)
//    {
//        int n = array.Length;
//        for (int i = 1; i < n; ++i)
//        {
//            double k = array[i];
//            int j = i - 1;

//            while (j >= 0 && array[j] > k)
//            {
//                array[j + 1] = array[j];
//                j = j - 1;
//            }
//            array[j + 1] = k;
//        }
//    }
//}