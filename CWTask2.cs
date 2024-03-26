using System;

abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

class Round : Shape
{
    private double _radius;

  
public Round(double radius)
    {
        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}

class Square : Shape
{
    private double _side;

   
public Square(double side)
    {
        _side = side;
    }

    public override double CalculateArea()
    {
        return _side * _side;
    }

    public override double CalculatePerimeter()
    {
        return 4 * _side;
    }
}

class Triangle : Shape
{
    private double _side1;
    private double _side2;
    private double _side3;

 
public Triangle(double side1, double side2, double side3)
    {
        _side1 = side1;
        _side2 = side2;
        _side3 = side3;
    }

    public override double CalculateArea()
    {
        double s = (_side1 + _side2 + _side3) / 2;
        return Math.Sqrt(s * (s - _side1) * (s - _side2) * (s - _side3));
    }

    public override double CalculatePerimeter()
    {
        return _side1 + _side2 + _side3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Round[] rounds = new Round[]
 {
            new Round(3),
            new Round(2),
            new Round(4),
            new Round(1),
            new Round(5)
 };

        Square[] squares = new Square[]
        {
            new Square(3),
            new Square(2),
            new Square(4),
            new Square(1),
            new Square(5)
        };

        Triangle[] triangles = new Triangle[]
        {
            new Triangle(3, 4, 5),
            new Triangle(2, 2, 2),
            new Triangle(4, 3, 5),
            new Triangle(1, 1, 2),
            new Triangle(5, 12, 13)
        };



        Sort(rounds);
        Sort(triangles);
        Sort(squares);

        Console.WriteLine("Фигура\t\tПлощадь\tПериметр");
        Console.WriteLine("--------------------------------------");
        foreach (var shape in rounds)
        {
            Console.WriteLine($"{shape.GetType().Name:15}\t{shape.CalculateArea():15}\t\t{shape.CalculatePerimeter():15}");
        }

        Console.WriteLine("Фигура\t\tПлощадь\tПериметр");
        Console.WriteLine("--------------------------------------");
        foreach (var shape in triangles)
        {
            Console.WriteLine($"{shape.GetType().Name:15}\t{shape.CalculateArea():15}\t\t{shape.CalculatePerimeter():15}");
        }

        Console.WriteLine("Фигура\t\tПлощадь\tПериметр");
        Console.WriteLine("--------------------------------------");
        foreach (var shape in squares)
        {
            Console.WriteLine($"{shape.GetType().Name:15}\t{shape.CalculateArea():15}\t\t{shape.CalculatePerimeter():15}");
        }

        Shape[] Array = new Shape[15];

        for (int i = 0; i < rounds.Length; i++)
        {
            Array[i] = rounds[i];
        }
        for (int i = 0; i < squares.Length; i++)
        {
            Array[i + rounds.Length] = squares[i];
        }
        for (int i = 0; i < triangles.Length; i++)
          {
             Array[i + rounds.Length + squares.Length] = triangles[i];
          }

            Sort(Array);

            Console.WriteLine("Фигура\t\tПлощадь\tПериметр");
            Console.WriteLine("--------------------------------------");
            foreach (var shape in Array)
            {
                Console.WriteLine($"{shape.GetType().Name:15}\t{shape.CalculateArea():15}\t\t{shape.CalculatePerimeter():15}");
            }

        }

        static void Sort(Shape[] shapes)
        {
            int i = 1;
            int j = 2;
            while (i < shapes.Length)
            {
                if (shapes[i - 1].CalculateArea() <= shapes[i].CalculateArea())
                {
                    i = j;
                    j++;
                }
                else
                {
                    Shape temp = shapes[i - 1];
                    shapes[i - 1] = shapes[i];
                    shapes[i] = temp;
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






