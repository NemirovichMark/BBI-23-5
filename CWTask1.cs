using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

struct Point
{
    private int X;
    private int Y;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public static double Distance(Point p1, Point p2)
    {

        int dx = p2.X - p1.X;
        int dy = p2.Y - p1.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    public static void PrintPointInfo(Point p1, Point p2)
    {
        Console.WriteLine($"Point 1: ({p1.X}, {p1.Y})");
        Console.WriteLine($"Point 2: ({p2.X}, {p2.Y})");
        Console.WriteLine($"Distance between points: {Distance(p1, p2)}");
        Console.WriteLine();

    }
}

class Program
{
    static void Main()
    {
        Point[] points = new Point[]
        {
            new Point(2, 2),
            new Point(3, 4),
            new Point(5, 6)
        };
        Point.PrintPointInfo(points[0], points[2]);
        for (int i = 0; i < points.Length - 1; i++)
        {
            Point.PrintPointInfo(points[i], points[i + 1]);
        }
    }
     
}