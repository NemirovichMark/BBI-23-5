using System;
using System.Linq;

class Programm
{
    static void Main()
    {
        Shaxmatisti[] shaxmatistis = new Shaxmatisti[5];
        {
             new Shaxmatisti("Karyakin", new Result[] { new Result(1), new Result(0.5), new Result(0), new Result(1), new Result(0.5) });
             new Shaxmatisti("Nepo", new Result[] { new Result(1), new Result(1), new Result(1), new Result(0), new Result(0) });
             new Shaxmatisti("Karlsen", new Result[] { new Result(1), new Result(1), new Result(1), new Result(1), new Result(0.5) });
             new Shaxmatisti("Botvink", new Result[] { new Result(0), new Result(0), new Result(0), new Result(0), new Result(0.5), });
             new Shaxmatisti("Dubov", new Result[] { new Result(0.5), new Result(1), new Result(0.5), new Result(1), new Result(1) });
        }

        foreach (Shaxmatisti shaxmatisti in shaxmatistis)
        {
            shaxmatisti.Getinfo();
        }
        Sortirovka(shaxmatistis);
        Console.WriteLine();
        for(int i =0; i<shaxmatistis.Length;i++)
        {
            shaxmatistis[i].Getinfo();
        }

    }
    static void Sortirovka(Shaxmatisti[] shaxmatistis)
    {
        for (int i = 0; i < shaxmatistis.Length - 1; i++)
        {
            for (int j = 0; j < shaxmatistis.Length; j++)
            {
                if (shaxmatistis[i].Sumigr < shaxmatistis[j].Sumigr)
                {
                    Shaxmatisti t = shaxmatistis[i];
                    shaxmatistis[i] = shaxmatistis[j];
                    shaxmatistis[j] = t;
                }
            }
        }
    }

}
struct Result
{
    private double pointgame;
    public double pg => pointgame;
    public Result(double pointg)
    {
        pointgame = pointg;
    }
}
    struct Shaxmatisti
    {
        private string lastname;
        private Result[] result;
        public double Sumigr { get; private set; }
        private double Getsum(Result[] igri)
        {
            double sum = 0;
            for (int i = 0; i < result.Length; i++)
            {
                sum += result[i].pg;
            }
            return sum;
        }

    public Shaxmatisti(string ln, Result[] r)
        {
            lastname = ln;
            result = r;
            Sumigr = Getsum(r);




        }
    
    public void Getinfo()
    {
        Console.Write($"Shaxmatis {lastname} has ");
        for(int i =0; i<result.Length;i++)
        {
            Console.Write($"{result[i]}");
        }
        Console.WriteLine("points for tournament");
    }
        





    }

