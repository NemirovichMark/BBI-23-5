using System;

namespace Variant_2
{
    public class Task2
    {
        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x = 0, double y = 0)
            {
                X = x;
                Y = y;
            }

            public double DistanceTo(Point other)
            {
                return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
            }
        }

        public abstract class Fourangle
        {
            protected Point[] points;

            public Fourangle(Point[] points)
            {
                if (points.Length == 4)
                {
                    this.points = points;
                }
                else
                {
                    this.points = new Point[4] { new Point(), new Point(), new Point(), new Point() };
                }
            }

            public abstract double Length();
            public abstract double Area();

            public override string ToString()
            {
                return $"{GetType().Name} with P = {Length()}, S = {Area()}";
            }
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Length()
            {
                return 4 * points[0].DistanceTo(points[1]);
            }

            public override double Area()
            {
                double side = points[0].DistanceTo(points[1]);
                return Math.Pow(side, 2);
            }
        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Length()
            {
                double length = points[0].DistanceTo(points[1]);
                double width = points[1].DistanceTo(points[2]);
                return 2 * (length + width);
            }

            public override double Area()
            {
                double length = points[0].DistanceTo(points[1]);
                double width = points[1].DistanceTo(points[2]);
                return length * width;
            }
        }
        private Fourangle[] fourangles;

        public Fourangle[] Fourangles
        {
            get { return fourangles; }
        }

        public Task2(Fourangle[] fourangles)
        {
            this.fourangles = fourangles;
        }

        public void Sorting()
        {
            for (int i = 0; i < fourangles.Length - 1; i++)
            {
                for (int j = i + 1; j < fourangles.Length; j++)
                {
                    if (fourangles[i].Area() < fourangles[j].Area())
                    {
                        var temp = fourangles[i];
                        fourangles[i] = fourangles[j];
                        fourangles[j] = temp;
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var fourangle in fourangles)
            {
                result += fourangle + "\n";
            }
            return result;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Point[] squarePoints = {
                new Point(0, 0),
                new Point(0, 2),
                new Point(2, 2),
                new Point(2, 0)
            };

            Point[] rectanglePoints = {
                new Point(0, 0),
                new Point(0, 4),
                new Point(6, 4),
                new Point(6, 0)
            };

            Fourangle[] figures = {
                new Square(squarePoints),
                new Rectangle(rectanglePoints)
            };

            Task2 task2 = new Task2(figures);

            Console.WriteLine("До сортировки:");
            Console.WriteLine(task2);

            task2.Sorting();

            Console.WriteLine("После сортировки:");
            Console.WriteLine(task2);
        }
    }
}