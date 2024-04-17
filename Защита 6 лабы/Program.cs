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
    private double Getsum(Result[] r)
    {
        double sum = 0;
        for (int i = 0; i < r.Length; i++)
        {
            sum += r[i].pg;
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
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write($"{result[i]}");
        }
        Console.WriteLine("points for tournament");
    }

        static void Sortirovka(Shaxmatisti[] shaxmatistis)
        {
            int index = 1;
            int nextindex = index + 1;
            double temp;
            while (index < shaxmatistis.Length)
            {
                if (shaxmatistis[index - 1].Sumigr > shaxmatistis[index].Sumigr)
                {
                    index = nextindex;
                    nextindex++;
                }
                else
                {
                    temp = shaxmatistis[index - 1].Sumigr;
                    shaxmatistis[index - 1].Sumigr = shaxmatistis[index].Sumigr;
                    shaxmatistis[index].Sumigr = temp;
                    index--;
                    if (index == 0)
                    {
                        index = nextindex;
                        nextindex++;
                    }
                }
            }
        }
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
            for (int i = 0; i < shaxmatistis.Length; i++)
            {
                shaxmatistis[i].Getinfo();
            }

        }





    }


}
