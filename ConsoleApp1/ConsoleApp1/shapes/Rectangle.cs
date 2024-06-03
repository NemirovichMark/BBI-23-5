using System.Text.Json.Serialization;

namespace ConsoleApp1.shapes;

public class Rectangle : Shape
{
    private double a;
    private double b;
    
    public Rectangle(){}

    [JsonConstructor]
    public Rectangle(string name, double a, double b) : base(name)
    {
        this.a = a;
        this.b = b;
    }

    // публичные геттеры для сериализации
    public double B => b;

    public double A => a;

    public override double CalculatePerimeter()
    {
        return 2 * (a + b);
    }

    public override double CalculateArea()
    {
        return a * b;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", a: {a}, b: {b}, perimeter: {CalculatePerimeter()}, area: {CalculateArea()}";
    }
}