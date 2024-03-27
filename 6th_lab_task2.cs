struct Jump
{
    private string famile;
    private double[] estimate;
    private int distance;
    private double rez;
    private double amax;
    private int imax;
    public Jump(string famile, double[] estimate, int distance)
    {
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
    public string Famile { get { return famile; } }
    public double[] Estimate { get { return estimate; } set { estimate = value; } }
    public int Distance { get { return distance; } }

    public double Rez { get { return rez; } }
}

class Program
{
    static void Main(string[] args)
    {
        Jump[] jump = new Jump[5];
        jump[0] = new Jump("John", new double[5] { 10.0, 20.0, 10.0, 20.0, 10.0 }, 122);
        jump[1] = new Jump("Stiven", new double[5] { 15.0, 25.0, 20.0, 10.0, 10.0 }, 130);
        jump[2] = new Jump("Tomas", new double[5] { 12.0, 22.0, 16.0, 27.0, 13.0 }, 119);
        jump[3] = new Jump("Alexander", new double[5] { 16.0, 26.0, 17.0, 28.0, 19.0 }, 90);
        jump[4] = new Jump("Vaska", new double[5] { 19.0, 21.0, 16.0, 20.0, 20.0 }, 105);
        for (int i = 0; i < jump.Length - 1; i++)
        {
            double amax = jump[i].Rez;
            int imax = i;
            for (int j = i + 1; j < jump.Length; j++)
            {
                if (amax < jump[j].Rez)
                {
                    amax = jump[j].Rez;
                    imax = j;
                }
            }
            Jump temp;
            temp = jump[imax];
            jump[imax] = jump[i];
            jump[i] = temp;
        }


        for (int i = 0; i < jump.Length; i++)
        {
            Console.WriteLine(jump[i].Famile + " " + jump[i].Rez);
        }
    }
}