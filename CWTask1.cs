using System;
using System.Linq;

struct Triangle
{
    private double[] sides;

    public Triangle(double[] sides)
    {
        this.sides = sides;
    }

    public string GetTriangleType()
    {
       
        if (sides[0] + sides[1] <= sides[2])
        {
            return "Невозможно построить треугольник";
        }
        if (sides[0] == sides[1] && sides[1] == sides[2])
        {
            return "Равносторонний";
        }
        if (sides[0] == sides[1] || sides[1] == sides[2])
        {
            return "Равнобедренный";
        }
        return "Разносторонний";
    }

    public double GetArea()
    {
        double p = sides.Sum() / 2;
        return Math.Sqrt(p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]));
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Стороны треугольника: {sides[0]}, {sides[1]}, {sides[2]}");
        Console.WriteLine($"Тип треугольника: {GetTriangleType()}");
        Console.WriteLine($"Площадь треугольника: {GetArea()}");
    }

    
}

class Program
{
    static void Main()
    {
        Triangle[] triangles = new Triangle[]
        {
            new Triangle(new double[] {3, 4, 5}),
            new Triangle(new double[] {5, 5, 5}),
            new Triangle(new double[] {4, 4, 5}),
            new Triangle(new double[] {6, 8, 10}),
            new Triangle(new double[] {5, 12, 13})
        };

        Sort(triangles);

        foreach (var triangle in triangles)
        {
            triangle.PrintInfo();
            Console.WriteLine();
        }
    }
    static void Sort(Triangle[] triangles)
    {
        int i = 1;
        int j = 2;
        while (i < triangles.Length)
        {
            if (triangles[i - 1].GetArea() <= triangles[i].GetArea())
            {
                i = j;
                j++;
            }
            else
            {
                Triangle temp = triangles[i - 1];
                triangles[i - 1] = triangles[i];
                triangles[i] = temp;
                i--;
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }
    }
}