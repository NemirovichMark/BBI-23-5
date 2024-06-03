using System.Text.Json.Serialization;

namespace ConsoleApp1.shapes;

public class Triangle : Shape
{
    private double a;
    private double c;
    private double b;
    
    public Triangle(){}

    [JsonConstructor]
    public Triangle(string name, double a, double b, double c) : base(name)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // публичные геттеры для сериализации
    public double B => b;

    public double C => c;

    public double A => a;

    public override double CalculatePerimeter()
    {
        return a + b + c;
    }

    public override double CalculateArea()
    {
        return Math.Sqrt(CalculatePerimeter() / 2 * (CalculatePerimeter() / 2 - a) * (CalculatePerimeter() / 2 - b) *
                         (CalculatePerimeter() / 2 - c));
    }

    public override string ToString()
    {
        return base.ToString() + $", a: {a}, b: {b}, c: {c}, perimeter: {CalculatePerimeter()}, area: {CalculateArea()}";
    }
}