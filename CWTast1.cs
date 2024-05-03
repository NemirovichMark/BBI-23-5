
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

struct Dot
{
    public int x;
    public int y;
    public int z;

    public Dot(int[] coordinates)
    {
        x = coordinates[0];
        y = coordinates[1];
        z = coordinates[2];
    }
}

 struct Vector
{
    public Dot dot1;
    public Dot dot2;

    public Vector(int[,] matrix)
    {
        dot1 = new Dot(new int[] { matrix[0, 0], matrix[0, 1], matrix[0, 2] });
        dot2 = new Dot(new int[] { matrix[1, 0], matrix[1, 1], matrix[1, 2] });
    }

    public double CalculateLength()
    {
        int dx = dot1.x - dot2.x;
        int dy = dot1.y - dot2.y;
        int dz = dot1.z - dot2.z;

        double Lenght = Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
    public void Print()
    {
        Console.WriteLine("Координата певрой точки({0}, {1}, {2}) ", dot1.x, dot1.y, dot1.z);
        Console.WriteLine("Координата  второй точки({0}, {1}, {2}) ", dot2.x, dot2.y, dot2.z);
        Console.WriteLine("Длина вектора: {0}", CalculateLength());
        Console.WriteLine();
    }
    static void Sort(Vector [] arr)
    {
        int i = 0;

        if (i > arr.Length)
        {
            i = 1;

        }
        while (i>0)
        {
            Vector temp = arr[i];
            arr[i] = arr[i - 1];
            temp = arr[i];
            i--;
        }

    }
}
class Program
{
    static void Main()
    {
        int[,] matrices = new int[,]
            {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { 10, 11, 12 },
            { 13, 14, 15 }
            };

        
        Sort(matrices);
        foreach (var maq in matrices)
        {
            maq.Print();

        }
        
        
}


    


