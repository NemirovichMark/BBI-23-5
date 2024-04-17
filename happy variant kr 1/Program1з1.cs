using System;

struct Point
{
    private int _x;
    private int _y;
    public int X => _x;
    public int Y => _y;

    public Point(int[] coordinates)
    {
        if (coordinates.Length != 2)
            throw new ArgumentException("Coordinates array must contain exactly 2 elements.");

        _x = coordinates[0];
        _y = coordinates[1];
    }

    private double CalculateDistance(Point other)
    {
        int deltaX = other.X - X;
        int deltaY = other.Y - Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public static void PrintPointInfo(Point point1, Point point2)
    {
        double distance = point1.CalculateDistance(point2);
        Console.WriteLine($"Point 1: ({point1.X}, {point1.Y})");
        Console.WriteLine($"Point 2: ({point2.X}, {point2.Y})");
        Console.WriteLine($"Distance between points: {distance:F2}\n");
    }
}

class Program
{
    static void Main()
    {
        Point[] points = new Point[]
        {
            new Point(new int[] {1, 2}),
            new Point(new int[] {3, 4}),
            new Point(new int[] {-1, -1})
        };

        Console.WriteLine("Point pairs information:");
        for (int i = 0; i < points.Length - 1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                Point.PrintPointInfo(points[i], points[j]);
            }
        }
    }
}