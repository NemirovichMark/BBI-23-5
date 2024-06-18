using System;
namespace Variant_2
{
    public class Task1
    {
        public struct Point
        {
            public double X { get; }
            public double Y { get; }
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
            public override string ToString()
            {
                return $"x = {X}, y = {Y}";
            }
            public double Length(Point other)
            {
                double distance = Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
                return Math.Round(distance, 3);
            }
            public double DistanceFromOrigin()
            {
                return Length(new Point(0, 0));
            }
        }
        private Point[] points;

        public Task1(Point[] pointsArray)
        {
            points = pointsArray;
        }

        public Point[] Points
        {
            get { return points; }
        }

        public static string GetPointsInfo(Point p1, Point p2)
        {
            double distance = p1.Length(p2);
            return $"{p1}\n{p2}\nDistance = {distance}";
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var point in points)
            {
                result += point.ToString() + "\n";
            }
            return result.TrimEnd();
        }

        public void Sorting()
        {
            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (points[i].Length(new Point(0, 0)) > points[j].Length(new Point(0, 0)))
                    {
                        Point temp = points[i];
                        points[i] = points[j];
                        points[j] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Point p1 = new Point(8, 2);
            Point p2 = new Point(3, 4);

            Task1 task = new Task1(new Point[] { p1, p2 });

            Console.WriteLine("info:");
            Console.WriteLine(Task1.GetPointsInfo(p1, p2));

            Console.WriteLine("\nbefore:");
            Console.WriteLine(task);

            task.Sorting();

            Console.WriteLine("\nafter:");
            Console.WriteLine(task);
        }
    }
}
