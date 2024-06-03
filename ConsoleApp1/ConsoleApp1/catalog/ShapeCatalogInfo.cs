using ConsoleApp1.shapes;

namespace ConsoleApp1.catalog;

public partial class ShapeCatalog
{
    public void ShapesInfo()
    {
        Console.WriteLine("Rectangles info:");
        ShapesInfo(typeof(Rectangle));
        Console.WriteLine("Circles info:");
        ShapesInfo(typeof(Circle));
        Console.WriteLine("Triangles info:");
        ShapesInfo(typeof(Triangle));
    }
    
    private void ShapesInfo(Type type)
    {
        int counter = 0;
        double sumArea = 0;
        double sumPerimeter = 0;
        foreach (var shape in shapes)
        {
            if (shape.GetType() == type)
            {
                counter++;
                sumArea += shape.CalculateArea();
                sumPerimeter += shape.CalculatePerimeter();
            }
        }

        Console.WriteLine($"Количество: " + counter + ", Средняя площадь: " +
                          sumArea / counter + ", Средний периметр: " +
                          sumPerimeter / counter);
    }
}