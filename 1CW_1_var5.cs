using System;

struct Rectangle
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double GetArea()
    {
        return Length * Width;
    }

    public double GetPerimeter()
    {
        return 2 * (Length + Width);
    }

    public static void CompareRectangles(Rectangle rect1, Rectangle rect2)
    {
        Console.WriteLine($"Сравнение прямоугольников:\n");

        if (rect1.Length > rect2.Length)
            Console.WriteLine($"Прямоугольник 1 длиннее Прямоугольника 2.");
        else if (rect1.Length < rect2.Length)
            Console.WriteLine($"Прямоугольник 2 длиннее Прямоугольника 1.");
        else
            Console.WriteLine("Длины прямоугольников равны.");

        if (rect1.Width > rect2.Width)
            Console.WriteLine($"Прямоугольник 1 шире Прямоугольника 2.");
        else if (rect1.Width < rect2.Width)
            Console.WriteLine($"Прямоугольник 2 шире Прямоугольника 1.");
        else
            Console.WriteLine("Ширины прямоугольников равны.");

        if (rect1.GetArea() > rect2.GetArea())
            Console.WriteLine($"Прямоугольник 1 больше по площади чем Прямоугольник 2.");
        else if (rect1.GetArea() < rect2.GetArea())
            Console.WriteLine($"Прямоугольник 2 больше по площади чем Прямоугольник 1.");
        else
            Console.WriteLine("Площади прямоугольников равны.");

        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Rectangle rect1 = new Rectangle(5.0, 3.0);
        Rectangle rect2 = new Rectangle(4.0, 6.0);
        Rectangle rect3 = new Rectangle(5.0, 3.5);

        Console.WriteLine("Ввод прямоугольников:");
        Console.WriteLine($"Прямоугольник 1: длина = {rect1.Length}, ширина = {rect1.Width}");
        Console.WriteLine($"Прямоугольник 2: длина = {rect2.Length}, ширина = {rect2.Width}");
        Console.WriteLine($"Прямоугольник 3: длина = {rect3.Length}, ширина = {rect3.Width}\n");

        Console.WriteLine("Сравнение прямоугольников:");
        Rectangle.CompareRectangles(rect1, rect2);
        Rectangle.CompareRectangles(rect1, rect3);
        Rectangle.CompareRectangles(rect2, rect3);
    }
}