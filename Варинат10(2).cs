abstract class Shape
{

    private string name;


    public Shape(string Name)
    {
        name = Name;
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public abstract double CalculateArea();
    public abstract double CalculatePerimeter(); 
}

class Round : Shape
{
    private double radius;
    public Round(string Name, double Radius) : base(Name)
    {
        radius = Radius;
    }
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}

class Square : Shape
{
    private double sideLength;

    public Square(string Name, double SideLength) : base(Name)
    {
        sideLength = SideLength;
    }

    public override double CalculateArea()
    {
        return sideLength * sideLength;
    }

    public override double CalculatePerimeter()
    {
        return 4 * sideLength;
    }
}

class Triangle : Shape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(string Name, double SideA, double SideB, double SideC) : base(Name)
    {
        sideA = SideA;
        sideB = SideB;
        sideC = SideC;
    }

    public override double CalculateArea()
    {
        double p = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
    }

    public override double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Round[] rounds = new Round[5];
        rounds[0] = new Round("Round 1", 5);
        rounds[1] = new Round("Round 2", 8);
        rounds[2] = new Round("Round 3", 3);
        rounds[3] = new Round("Round 4", 6);
        rounds[4] = new Round("Round 5", 7);

        Square[] squares = new Square[5];
        squares[0] = new Square("Square 1", 4);
        squares[1] = new Square("Square 2", 6);
        squares[2] = new Square("Square 3", 5);
        squares[3] = new Square("Square 4", 3);
        squares[4] = new Square("Square 5", 7);

        Triangle[] triangles = new Triangle[5];
        triangles[0] = new Triangle("Triangle 1", 3, 4, 5);
        triangles[1] = new Triangle("Triangle 2", 6, 8, 10);
        triangles[2] = new Triangle("Triangle 3", 5, 12, 13);
        triangles[3] = new Triangle("Triangle 4", 7, 24, 25);
        triangles[4] = new Triangle("Triangle 5", 8, 15, 17);

        Console.WriteLine("Круги:");
        PrintShapesTable(rounds);
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Квадраты:");
        PrintShapesTable(squares);
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Треугольники:");
        PrintShapesTable(triangles);
    }

    static void PrintShapesTable(Shape[] shapes)
    {
        Console.WriteLine($"{"Name",-15}{"Area",-15}{"Perimeter",-15}");
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.Name,-15}{shape.CalculateArea(),-15:F2}{shape.CalculatePerimeter(),-15:f}");

        }
    }
}