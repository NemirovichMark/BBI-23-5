using System.Text.Json.Serialization;

namespace ConsoleApp1.shapes;

public class Circle : Shape
{
    private double r;
    
    public Circle(){}

    [JsonConstructor]
    public Circle(string name, double r) : base(name)
    {
        this.r = r;
    }

    // публичные геттеры для сериализации
    public double R => r;

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * r;
    }

    public override double CalculateArea()
    {
        return Math.PI * r * r;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", r: {r}, perimeter: {CalculatePerimeter()}, area: {CalculateArea()}";
    }
}