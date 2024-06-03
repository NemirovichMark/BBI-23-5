using ConsoleApp1.shapes;

namespace ConsoleApp1.catalog;

public interface IAnalyzer
{
    public bool IsInscriable(Shape shape1, Shape shape2);
    public bool IsCircumscribed(Shape shape1, Shape shape2);
}