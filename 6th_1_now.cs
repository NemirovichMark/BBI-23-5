struct Answer
{
    private string famile;
    private double count;
    private double percent;
    private static double summ;
    public Answer(string famile, double count)
    {
        this.famile = famile;
        this.count = count;
        percent = 0;
    }

    public static void SetSum(double total)
    {
        summ = total;
    }

    public double Count { get { return count; } }

    public void Get_Percent()
    {
        percent = (count / summ) * 100;
        Console.WriteLine($"Личность: {famile}, Процент: {percent}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Answer[] cl = new Answer[6];
        cl[0] = new Answer("James", 10);
        cl[1] = new Answer("Pedro", 9);
        cl[2] = new Answer("Bogdan", 2);
        cl[3] = new Answer("Alex", 4);
        cl[4] = new Answer("Mark", 13);
        cl[5] = new Answer("Alexandra", 23);

        double total = 0;
        for (int i = 0; i < cl.Length; i++)
        {
            total += cl[i].Count;
        }

        Answer.SetSum(total);


        for (int i = 1; i < cl.Length; i++)
        {
            Answer temp = cl[i];
            int j = i - 1;
            while (j >= 0 && cl[j].Count < temp.Count)
            {
                cl[j + 1] = cl[j];
                j--;
            }
            cl[j + 1] = temp;
        }

        for (int i = 0; i < cl.Length; i++)
        {
            cl[i].Get_Percent();
        }
    }
}