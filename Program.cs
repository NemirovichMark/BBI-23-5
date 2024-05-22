using System;
using System.ComponentModel.Design;

public class Number
{
    public int Real;

    public Number(int real)
    {
        Real = real;
    }

    public override string ToString()
    {
        return $"Number={Real}";
    }

    public static Number operator +(Number a, Number b)
    {
        return new Number(a.Real + b.Real);
    }

    public static Number operator -(Number a, Number b)
    {
        return new Number(a.Real - b.Real);
    }

    public static Number operator /(Number a, Number b)
    {
        if (b.Real == 0) throw new DivideByZeroException("Деление на ноль невозможно");
        return new Number(a.Real / b.Real);
    }
}

public class ComplexNumber : Number
{
    public int Imaginary;

    public ComplexNumber(int real, int imaginary) : base(real)
    {
        Imaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(
            a.Real * b.Real - a.Imaginary * b.Imaginary,
            a.Real * b.Imaginary + a.Imaginary * b.Real
        );
    }

    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        int denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        if (denominator == 0) throw new DivideByZeroException("Деление на ноль невозможно");
        return new ComplexNumber(
            (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
            (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator
        );
    }

    public override string ToString()
    {
  
         return $"Number={Real}+-{Imaginary}i";
    }
    
}

class Program
{
    static void Main()
    {
        ComplexNumber num1 = new ComplexNumber(3, 2);
        ComplexNumber num2 = new ComplexNumber(1, -1);

        ComplexNumber sum = num1 + num2;
        ComplexNumber difference = num1 - num2;
        ComplexNumber proizvedenie = num1 * num2;
        ComplexNumber chastnoe = num1 / num2;

        Console.WriteLine(num1);
        Console.WriteLine(num2);
        Console.WriteLine(sum);
        Console.WriteLine(difference);
        Console.WriteLine(proizvedenie);
        Console.WriteLine(chastnoe);
    }
}