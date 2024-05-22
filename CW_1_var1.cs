using System;

 struct Number
{
    private int Nubmers;

    public Number(int Nubmers1)
    {
        Nubmers = Nubmers1;
    }

    public static Number operator +(Number a, Number b)
    {
        return new Number(a.Nubmers + b.Nubmers);
    }

    public static Number operator -(Number a, Number b)
    {
        return new Number(a.Nubmers - b.Nubmers);
    }

    public static Number operator *(Number a, Number b)
    {
        return new Number(a.Nubmers * b.Nubmers);
    }

    public static Number operator /(Number a, Number b)
    {
        if (b.Nubmers == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно");
        }
        return new Number(a.Nubmers / b.Nubmers);
    }

    public override string ToString()
    {
        return $"Number={Nubmers}";
    }
}

class Program
{
    static void Main()
    {
        Number num1 = new Number(6);
        Number num2 = new Number(3);

        Number sum = num1 + num2;
        Number difference = num1 - num2;
        Number proizvedenie = num1 * num2;
        Number chastnoe = num1 / num2;

        Console.WriteLine(num1);
        Console.WriteLine(num2);
        Console.WriteLine(sum);
        Console.WriteLine(difference);
        Console.WriteLine(proizvedenie);
        Console.WriteLine(chastnoe);
    }
}