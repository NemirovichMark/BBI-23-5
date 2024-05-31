using System.Text.Json.Serialization;

namespace ConsoleApp1.shapes;

[JsonDerivedType(typeof(Rectangle), typeDiscriminator: "rectangle")]
[JsonDerivedType(typeof(Triangle), typeDiscriminator: "triangle")]
[JsonDerivedType(typeof(Circle), typeDiscriminator: "circle")]
public abstract class Shape
{
    private string name;
    
    protected Shape(){}

    protected Shape(string name)
    {
        this.name = name;
    }

    // публичные геттеры для сериализации
    public string Name => name;

    public override string ToString()
    {
        return $"name: {name}";
    }

    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();
}