// вариант 10.1
struct Triangle
{

    private double side1;
    private double side2;
    private double side3;

    public Triangle(double side1, double side2, double side3)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }
    public string DetermineType()
    {
        if (side1 == side2 && side2 == side3)
        {
            return "Равносторонний";
        }
        else if (side1 == side2 && side2 == side3)
        {
            return "Равнобедренный";
        }
        else
        {
            return "Разносторонний";
        }
    }

    public double CalculateArea()
    {
        double p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Стороны треугольника: {side1}, {side2}, {side3}");
        Console.WriteLine($"Тип треугольника: {DetermineType()}");
        Console.WriteLine($"Площадь треугольника: {CalculateArea()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Triangle[] triangles = new Triangle[5];
        triangles[0] = new Triangle(3, 4, 5);
        triangles[1] = new Triangle(5, 5, 5);
        triangles[2] = new Triangle(3, 4, 6);
        triangles[3] = new Triangle(4, 4, 6);
        triangles[4] = new Triangle(5, 12, 13);

        ShellSort(ref triangles);

        Console.WriteLine("Информация о треугольниках:");
        foreach (var triangle in triangles)
        {
            triangle.PrintInfo();
            Console.WriteLine();
        }
    }

    static void ShellSort(ref Triangle[] triangles)
    {
        int n = triangles.Length;
        int step = n / 2;
        while (step > 0)
        {
            for (int i = step; i < n; i++)
            {
                Triangle temp = triangles[i];
                int j = i;
                while (j >= step && triangles[j - step].CalculateArea() > temp.CalculateArea())
                {
                    triangles[j] = triangles[j - step];
                    j -= step;
                }
                triangles[j] = temp;
            }
            step /= 2;
        }
    }
}


