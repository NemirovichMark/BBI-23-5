using System.Text.Json.Serialization;
using ConsoleApp1.shapes;

namespace ConsoleApp1.catalog;

public partial class ShapeCatalog : IAnalyzer
{
    private static double EPS = 1e-9; // точность для сравнение дробных чисел
    
    private string name;
    private List<Shape> shapes = new List<Shape>();
   
    public ShapeCatalog()
    {
    }

    public ShapeCatalog(string name)
    {
        this.name = name;
    }

    // конструктор для десериализации
    [JsonConstructor]
    public ShapeCatalog(string name, List<Shape> shapes)
    {
        this.name = name;
        this.shapes = shapes;
    }
    
    // публичные геттеры для сериализации
    public List<Shape> Shapes => shapes;

    public string Name => name;

    // метод добавления в католог фигуры
    public void AddShape(Shape shape)
    {
        shapes.Add(shape);
    }

    // метод удаления фигуры из каталога
    public void RemoveShape(Shape shape)
    {
        shapes.Remove(shape);
    }
    
    // проверяем, что фигура shape1 описана вокруг фигуры shape2
    public bool IsInscriable(Shape shape1, Shape shape2)
    {
        Circle circle;
        Rectangle rectangle;
        Triangle triangle;
        if (IsCircle(shape1))
        {
            circle = (Circle)shape1;
            if (IsRectangle(shape2))
            {
                rectangle = (Rectangle)shape2;
                // окружность описана вокруг прямоугольника тогда,
                // когда диаметр окружности равен диагонале прямоугольника
                return Math.Abs(2 * circle.R - Math.Sqrt(rectangle.A * rectangle.A + rectangle.B * rectangle.B)) < EPS;
            }
            if (IsTriangle(shape2))
            {
                triangle = (Triangle)shape2;
                // окружность описана вокруг треугольника тогда,
                // когда радиус окружности будет равен радиусу описанной окружности вокруг треугольника
                return Math.Abs(circle.R - triangle.A * triangle.B * triangle.C / (4 * triangle.CalculateArea())) < EPS;
            }
        } else if (IsRectangle(shape1))
        {
            rectangle = (Rectangle)shape1;
            if (IsCircle(shape2) && Math.Abs(rectangle.A - rectangle.B) < EPS)
            {
                circle = (Circle)shape2;
                // прямоугольник будет описан вокруг окружности,
                // когда он будет квадратом (a == b) и диаметр окружности будет равен стороне квадрата
                return Math.Abs(2 * circle.R - rectangle.A) < EPS;
            }
        }
        else if (IsTriangle(shape1))
        {
            triangle = (Triangle)shape1;
            if (IsCircle(shape2))
            {
                circle = (Circle)shape2;
                // треугольник будет описан вокруг окружности,
                // когда радиус вписанной окружности треугольника будет равен радиусу нашей окружности
                return Math.Abs(circle.R - 2 * triangle.CalculateArea() / triangle.CalculatePerimeter()) < EPS;
            }
        }

        return false;
    }

    // проверяем, что фигура shape1 вписана в фигуру shape2
    public bool IsCircumscribed(Shape shape1, Shape shape2)
    {
        // если 1 фигура вписана во 2, то 2 фигура описана вокруг 1
        // а проверять описанность мы уже умеем, поэтому меняем местами фигуры
        return IsInscriable(shape2, shape1);
    }

    // проверяем что данная фигура является прямоугольником
    private bool IsRectangle(Shape shape)
    {
        return shape.GetType() == typeof(Rectangle);
    }
    
    // проверяем что данная фигура является окружностью
    private bool IsCircle(Shape shape)
    {
        return shape.GetType() == typeof(Circle);
    }
    
    // проверяем что данная фигура является треугольников
    private bool IsTriangle(Shape shape)
    {
        return shape.GetType() == typeof(Triangle);
    }
}