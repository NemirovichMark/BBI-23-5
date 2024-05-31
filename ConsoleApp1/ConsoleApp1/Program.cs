using ConsoleApp1.catalog;
using ConsoleApp1.serialize;
using ConsoleApp1.shapes;

namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        // Создание массива Circle[] и заполнение его экземплярами Circle
        Circle[] circles = new[]
        {
            new Circle("C1", 10),
            new Circle("C2", 1),
            new Circle("C3", 11),
            new Circle("C4", 9),
            new Circle("C5", 5),
        };
        // Создание массива Rectangle[] и заполнение его экземплярами Rectangle
        Rectangle[] rectangles = new[]
        {
            new Rectangle("R1", 1, 5),
            new Rectangle("R2", 10, 10),
            new Rectangle("R3", 7, 8),
            new Rectangle("R4", 100, 10),
            new Rectangle("R5", 20, 2)
        };
        // Создание массива Triangle[] и заполнение его экземплярами Triangle
        Triangle[] triangles = new[]
        {
            new Triangle("T1", 1, 2, 2),
            new Triangle("T2", 4, 5, 7),
            new Triangle("T3", 5, 10, 9),
            new Triangle("T4", 1200, 2000, 1500),
            new Triangle("T5", 3, 4, 5)
        };

        // Создание ShapeCatalog
        ShapeCatalog shapeCatalog = new ShapeCatalog("Каталог");

        // Заполнение ShapeCatalog объектами из массивов circles, rectangles и triangle
        foreach (var circle in circles)
        {
            shapeCatalog.AddShape(circle);
        }

        foreach (var rectangle in rectangles)
        {
            shapeCatalog.AddShape(rectangle);
        }

        foreach (var triangle in triangles)
        {
            shapeCatalog.AddShape(triangle);
        }

        // Создание объекта типа MyJsonSerializer и сериализация ShapeCatalog в файл raw_data.json
        MyJsonSerializer myJsonSerializer = new MyJsonSerializer();
        string filename1 = "/Users/arinchik/Projects/ConsoleApp1/ConsoleApp1/resources/raw_data.json";
        myJsonSerializer.Write(shapeCatalog, filename1);

        // Добавление и удаление некоторых фигур
        shapeCatalog.AddShape(new Circle("C6", 52));
        shapeCatalog.AddShape(new Triangle("T6", 2, 2, 2));
        shapeCatalog.AddShape(new Rectangle("R6", 8, 10));
        shapeCatalog.RemoveShape(shapeCatalog.Shapes[0]);
        shapeCatalog.RemoveShape(shapeCatalog.Shapes[4]);

        // Сериализация измененного объекта типа  ShapeCatalog в файл data.json
        string filename2 = "/Users/arinchik/Projects/ConsoleApp1/ConsoleApp1/resources/data.json";
        myJsonSerializer.Write(shapeCatalog, filename2);

        // Попарное сравнение фигур на вписанность или описанность с помощью
        // соответсвующих методов класса ShapeCatalog и вывод на экран результатов сравнений
        Console.WriteLine("Сравнения:");
        for (int i = 0; i < shapeCatalog.Shapes.Count - 1; i++)
        {
            if (shapeCatalog.IsInscriable(shapeCatalog.Shapes[i], shapeCatalog.Shapes[i + 1]))
            {
                Console.WriteLine("Фигура " + shapeCatalog.Shapes[i] + " описанная по отношению к фигуре " +
                                  shapeCatalog.Shapes[i + 1]);
            }
            else if (shapeCatalog.IsCircumscribed(shapeCatalog.Shapes[i], shapeCatalog.Shapes[i + 1]))
            {
                Console.WriteLine("Фигура " + shapeCatalog.Shapes[i] + " вписанная по отношению к фигуре " +
                                  shapeCatalog.Shapes[i + 1]);
            }
            else
            {
                Console.WriteLine("Фигура " + shapeCatalog.Shapes[i] +
                                  " не описанная и не вписанная по отношению к фигуре " + shapeCatalog.Shapes[i + 1]);
            }
        }
        
        // Десериализация, с помощью созданного объекта типа MyJsonSerializer,
        // объектов типа ShapeCatalog из файлов raw_data.json и data.json и
        // вывод фигур из десериализованных объектов на экран
        ShapeCatalog rawDataShapeCatalog = myJsonSerializer.Read(filename1);
        Console.WriteLine("raw_data.json");
        foreach (var shape in rawDataShapeCatalog.Shapes)
        {
            Console.WriteLine(shape);
        }
        ShapeCatalog dataShapeCatalog = myJsonSerializer.Read(filename2);
        Console.WriteLine("data.json");
        foreach (var shape in dataShapeCatalog.Shapes)
        {
            Console.WriteLine(shape);
        }
        
        
        string filename3 = "/Users/arinchik/Projects/ConsoleApp1/ConsoleApp1/resources/sort_data.json";
        string filename4 = "/Users/arinchik/Projects/ConsoleApp1/ConsoleApp1/resources/last_data.json";
        // Сортируем каталог фигур по периметру, с помощью метода SortedByArea() из класса ShapeCatalog
        shapeCatalog.SortedByPerimeter();
        // Сериализуем измененный объект класса ShapeCatalog в файл sort_data.json
        myJsonSerializer.Write(shapeCatalog, filename3);

        // Сортируем каталог фигур по площади, с помощью метода SortedByPerimeter() из класса ShapeCatalog
        shapeCatalog.SortedByArea();
        // Сериализуем измененный объект класса ShapeCatalog в файл last_data.json
        myJsonSerializer.Write(shapeCatalog, filename4);

        // Выводим количество, среднюю площадь и средний периметр каждого типа фигур на экран,
        // с помощью методов класса ShapeCatalog: ShapesInfoTriangle(), ShapesInfoRectangle() и ShapesInfoCircle() 
        shapeCatalog.ShapesInfo();

        // Десериализация, с помощью созданного объекта типа MyJsonSerializer, объектов типа ShapeCatalog
        // из файлов sort_data.json и last_data.json и вывод фигур из десериализованных объектов на экран
        ShapeCatalog shapeCatalogSortData = myJsonSerializer.Read(filename3);
        Console.WriteLine("sort_data.json");
        foreach (var shape in shapeCatalogSortData.Shapes)
        {
            Console.WriteLine(shape);
        }
        ShapeCatalog shapeCatalogLastData = myJsonSerializer.Read(filename4);
        Console.WriteLine("last_data.json");
        foreach (var shape in shapeCatalogLastData.Shapes)
        {
            Console.WriteLine(shape);
        }
    }
}