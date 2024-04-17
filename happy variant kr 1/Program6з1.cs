using System;

struct SimpleDate
{
    private int _day;
    private int _month;
    private int _year;
    public int Day => _day;
    public int Month => _month;
    public int Year => _year;


    public SimpleDate(int day, int month, int year)
    {
        _day = day;
        _month = month;
        _year = year;
    }

    public bool IsLeapYear()
    {
        return (_year % 4 == 0 && _year % 100 != 0) || (_year % 400 == 0);
    }

    public string FormatDate()
    {
        return $"{_day:D2}.{_month:D2}.{_year % 100:D2}";
    }
}

class Program
{
    static void Main()
    {
        SimpleDate[] dates = new SimpleDate[]
        {
            new SimpleDate(12, 5, 2023),
            new SimpleDate(28, 2, 2000),
            new SimpleDate(15, 9, 2004),
            new SimpleDate(1, 1, 2020),
            new SimpleDate(20, 11, 1999),
            new SimpleDate(8, 3, 1988),
            new SimpleDate(5, 7, 1995),
            new SimpleDate(30, 4, 2010),
            new SimpleDate(22, 12, 1980),
            new SimpleDate(10, 10, 2008)
        };

        BubbleSort(dates);
        PrintDates(dates);
    }

    static void BubbleSort(SimpleDate[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (CompareDates(array[j], array[j + 1]))
                {
                    SimpleDate temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    static bool CompareDates(SimpleDate date1, SimpleDate date2)
    {
        if (date1.Year != date2.Year)
            return date1.Year > date2.Year;
        if (date1.Month != date2.Month)
            return date1.Month > date2.Month;
        return date1.Day > date2.Day;
    }

    static void PrintDates(SimpleDate[] dates)
    {
        Console.WriteLine("День  Месяц  Год");
        foreach (var date in dates)
        {
            Console.WriteLine($"{date.FormatDate()}");
        }
    }
}