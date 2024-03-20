struct SimpleDate
{
    private int day;
    private int month;
    private int year;

    public int Day { get { return day; } }
    public int Month { get { return month; } }
    public int Year { get { return year; } }

    public SimpleDate(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    public bool IY()
    {
        if (year % 400 == 0) return true;
        if (year % 100 == 0) return false;
        return year % 4 == 0;
    }

    public string FD()
    {
        return $"{day:00}.{month:00}.{year:0000}";
    }

    public static int CD(SimpleDate a, SimpleDate b)
    {
        if (a.Year != b.Year)
            return a.Year - b.Year;
        if (a.Month != b.Month)
            return a.Month - b.Month;
        return a.Day - b.Day;
    }
}

class Program
{
    static void Main()
    {
        SimpleDate[] dates = new SimpleDate[] {
            new SimpleDate(1, 1, 2020),
            new SimpleDate(12, 12, 2019),
            new SimpleDate(25, 12, 2020),
            new SimpleDate(1, 2, 2019),
            new SimpleDate(5, 5, 2018),
            new SimpleDate(15, 8, 2020),
            new SimpleDate(23, 3, 2018),
            new SimpleDate(31, 10, 2019),
            new SimpleDate(28, 2, 2020),
            new SimpleDate(20, 11, 2020)
        };

        for (int i = 0; i < dates.Length - 1; i++)
        {
            for (int j = i + 1; j < dates.Length; j++)
            {
                if (SimpleDate.CD(dates[i], dates[j]) > 0)
                {
                    SimpleDate d = dates[i];
                    dates[i] = dates[j];
                    dates[j] = d;
                }
            }
        }

        Console.WriteLine("Date");
        Console.WriteLine("----");
        foreach (var date in dates)
        {
            Console.WriteLine(date.FD());
        }
    }
}
