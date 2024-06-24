using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Variant_2
{
    public class Task2
    {
        public struct Point
        {
            public double X { get; }
            public double Y { get; }

            public Point(double[] coordinates)
            {
                X = coordinates[0];
                Y = coordinates[1];
            }

            public override string ToString()
            {
                return $"x = {X}, y = {Y}";
            }

            public double Length(Point other)
            {
                return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            }

            public static string GetInfo(Point p1, Point p2)
            {
                return $"{p1}\n{p2}\nDistance: {Math.Round(p1.Length(p2), 3)}";
            }
        }

        private Point[] _points;
        public IReadOnlyList<Point> Points => _points.AsReadOnly();

        public Task2(Point[] points)
        {
            _points = points;
        }


        public void Sorting()
        {
             void QuickSortPoints(Point[] points, int left, int right)
            {
                if (left < right)
                {
                    int pivotIndex = Partition(points, left, right);

                    QuickSortPoints(points, left, pivotIndex - 1);
                    QuickSortPoints(points, pivotIndex + 1, right);
                }
            }

             int Partition(Point[] points, int left, int right)
            {
                Point pivot = points[right];
                int i = left - 1;

                for (int j = left; j < right; j++)
                {
                    if (DistanceToOrigin(points[j]) <= DistanceToOrigin(pivot))
                    {
                        i++;
                        Swap(ref points[i], ref points[j]);
                    }
                }

                Swap(ref points[i + 1], ref points[right]);
                return i + 1;
            }

             void Swap(ref Point a, ref Point b)
            {
                Point temp = a;
                a = b;
                b = temp;
            }

             double DistanceToOrigin(Point point)
            {
                return Math.Sqrt(point.X * point.X + point.Y * point.Y);
            }
        }
           

        public override string ToString()
        {
            return string.Join("\n", _points.Select(p => p.ToString()));
        }
        public abstract class Fourangle
        {
            protected Point[] points;

            public Fourangle(Point[] points)
            {
                if (points.Length != 4)
                {
                    Array.Clear(points, 0, points.Length);
                }
                else
                {
                    this.points = points;
                }
            }

            public Point[] Points => points;

            public abstract double Length();

            public abstract double Area();

            public override string ToString()
            {
                return $"Fourangle with P = {Length()}, S = {Area()}";
            }
        }

        public class Square : Fourangle
        {
            public Square(Point[] points) : base(points) { }

            public override double Length()
            {
                var length = 0d;
                for (int i = 0; i < 4; i++)
                {
                    length += Math.Sqrt(Math.Pow(points[i].X - points[(i + 1) % 4].X, 2) + Math.Pow(points[i].Y - points[(i + 1) % 4].Y, 2));
                }
                return length / 4;
            }

            public override double Area()
            {
                var area = 0d;
                for (int i = 0; i < 4; i++)
                {
                    area += points[i].X * points[(i + 1) % 4].Y;
                }
                return Math.Abs(area / 2);
            }
        }

        public class Rectangle : Fourangle
        {
            public Rectangle(Point[] points) : base(points) { }

            public override double Length()
            {
                var length = 0d;
                for (int i = 0; i < 4; i++)
                {
                    length += Math.Sqrt(Math.Pow(points[i].X - points[(i + 1) % 4].X, 2) + Math.Pow(points[i].Y - points[(i + 1) % 4].Y, 2));
                }
                return length / 4;
            }

            public override double Area()
            {
                var area = 0d;
                for (int i = 0; i < 4; i++)
                {
                    area += points[i].X * points[(i + 1) % 4].Y;
                }
                return Math.Abs(area / 2);
            }
        }



    }

}
