using System.Globalization;

abstract class Jump
{

    protected string disciplineName;

    public abstract void DisplayName();

    public abstract void GetInfo();

}

class Jump120 : Jump
{
    protected string famile;
    protected double[] estimate;
    protected int distance;
    protected double rez;
    protected double amax;
    protected int imax;
    public Jump120(string disciplineName, string famile, double[] estimate, int distance)
    {
        this.disciplineName = disciplineName;
        this.famile = famile;
        this.estimate = estimate;
        this.distance = distance;
        rez = 0;
        amax = imax = 0;
        for (int i = 0; i < estimate.Length - 1; i++)
        {
            amax = estimate[i];
            imax = i;
            for (int j = i + 1; j < estimate.Length; j++)
            {
                if (amax < estimate[j])
                {
                    amax = estimate[j];
                    imax = j;
                }
            }
            double temp;
            temp = estimate[imax];
            estimate[imax] = estimate[i];
            estimate[i] = temp;
        }
        for (int i = 0; i < estimate.Length; i++)
        {
            rez += estimate[i];
        }
        rez -= (estimate[0] + estimate[4]);
        if (distance >= 120)
        {
            rez += (distance - 120) * 2;
        }
        else if (distance < 120)
        {
            rez -= (120 - distance) * 2;
        }
    }

    public override void DisplayName()
    {
        Console.WriteLine($"Дисциплина: {disciplineName}");
    }

    public override void GetInfo()
    {
        Console.WriteLine(famile + " " + rez);
    }

    public double Rez_120 { get { return rez; } }
}

class Jump180 : Jump
{
    protected string famile;
    protected double[] estimate;
    protected int distance;
    protected double rez;
    protected double amax;
    protected int imax;
    string disciplineName;
    public Jump180(string disciplineName, string famile, double[] estimate, int distance)
    {
        this.disciplineName = disciplineName;
        this.famile = famile;
        this.estimate = estimate;
        this.distance = distance;
        rez = 0;
        amax = imax = 0;
        for (int i = 0; i < estimate.Length - 1; i++)
        {
            amax = estimate[i];
            imax = i;
            for (int j = i + 1; j < estimate.Length; j++)
            {
                if (amax < estimate[j])
                {
                    amax = estimate[j];
                    imax = j;
                }
            }
            double temp;
            temp = estimate[imax];
            estimate[imax] = estimate[i];
            estimate[i] = temp;
        }
        for (int i = 0; i < estimate.Length; i++)
        {
            rez += estimate[i];
        }
        rez -= (estimate[0] + estimate[4]);
        if (distance >= 180)
        {
            rez += (distance - 180) * 2;
        }
        else if (distance < 180)
        {
            rez -= (180 - distance) * 2;
        }
    }

    public override void DisplayName()
    {
        Console.WriteLine($"Дисциплина: {disciplineName}");
    }

    public override void GetInfo()
    {
        Console.WriteLine(famile + " " + rez);
    }

    public double Rez_180 { get { return rez; } }
}



class Program
{
    static void Main(string[] args)
    {
        Jump120[] jump120 = new Jump120[5];
        jump120[0] = new Jump120("skiing_120", "John", new double[5] { 11.0, 20.0, 10.0, 20.0, 10.0 }, 122);
        jump120[1] = new Jump120("skiing_120", "Stiven", new double[5] { 10.0, 25.0, 20.0, 10.0, 10.0 }, 130);
        jump120[2] = new Jump120("skiing_120", "Tomas", new double[5] { 10.0, 22.0, 16.0, 27.0, 13.0 }, 119);
        jump120[3] = new Jump120("skiing_120", "Alexander", new double[5] { 9.0, 26.0, 17.0, 28.0, 19.0 }, 90);
        jump120[4] = new Jump120("skiing_120", "Vaska", new double[5] { 35.0, 21.0, 16.0, 20.0, 20.0 }, 105);

        Jump180[] jump180 = new Jump180[5];
        jump180[0] = new Jump180("skiing_180", "John", new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 }, 180);
        jump180[1] = new Jump180("skiing_180", "Stiven", new double[5] { 15.0, 25.0, 20.0, 10.0, 10.0 }, 185);
        jump180[2] = new Jump180("skiing_180", "Tomas", new double[5] { 12.0, 22.0, 16.0, 27.0, 13.0 }, 175);
        jump180[3] = new Jump180("skiing_180", "Alexander", new double[5] { 16.0, 26.0, 17.0, 28.0, 19.0 }, 170);
        jump180[4] = new Jump180("skiing_180", "Vaska", new double[5] { 19.0, 21.0, 16.0, 20.0, 20.0 }, 190);

        for (int i = 0; i < jump120.Length - 1; i++)
        {
            double amax = jump120[i].Rez_120;
            int imax = i;
            for (int j = i + 1; j < jump120.Length; j++)
            {
                if (amax < jump120[j].Rez_120)
                {
                    amax = jump120[j].Rez_120;
                    imax = j;
                }
            }
            Jump120 temp;
            temp = jump120[imax];
            jump120[imax] = jump120[i];
            jump120[i] = temp;
        }


        for (int i = 0; i < jump180.Length - 1; i++)
        {
            double amax = jump180[i].Rez_180;
            int imax = i;
            for (int j = i + 1; j < jump180.Length; j++)
            {
                if (amax < jump180[j].Rez_180)
                {
                    amax = jump180[j].Rez_180;
                    imax = j;
                }
            }
            Jump180 temp;
            temp = jump180[imax];
            jump180[imax] = jump180[i];
            jump180[i] = temp;
        }

        jump120[1].DisplayName();
        for (int i = 0; i < jump120.Length; i++)
        {
            jump120[i].GetInfo();
        }

        Console.WriteLine();

        jump180[1].DisplayName();
        for (int i = 0; i < jump180.Length; i++)
        {
            jump180[i].GetInfo();
        }
    }

}
