//Создайте структуру Point, представляющую точку в двумерном пространстве( с координатами x и y) Напишите метод для определения расстояния между двумя точками
//Напишите статический метод который принимает в себя 2 точки и выводит информацию об их координатах и расстоянии между ними.
//В конструктор передать массив из 2х элементов. В основной программе создайте массив из 3 точек и выведите информацию о каждой паре точек в виде таблицы
using System;
using System.Drawing;


using System;

struct Point
{
    private int x;
    private int y;

    public Point(int[] coordinates)
    {

        x = coordinates[0];
        y = coordinates[1];
    }

    public double Distance(Point other)
    {
        int dx = x - other.x;
        int dy = y - other.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public static void PrintPointInfo(Point p1, Point p2)
    {
        Console.WriteLine($"Координаты точки 1: ({p1.x}, {p1.y})");
        Console.WriteLine($"Координаты точки 2: ({p2.x}, {p2.y})");
        Console.WriteLine($"Расстояние между точками: {p1.Distance(p2)}");
        Console.WriteLine();
    }


    class Program
    {
        static void Main()
        {
            Point[] points = new Point[3];
            points[0] = new Point(new int[] { 1, 2 });
            points[1] = new Point(new int[] { 3, 4 });
            points[2] = new Point(new int[] { 5, 6 });

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    Point.PrintPointInfo(points[i], points[j]);
                }
            }
        } 

    }
}



        