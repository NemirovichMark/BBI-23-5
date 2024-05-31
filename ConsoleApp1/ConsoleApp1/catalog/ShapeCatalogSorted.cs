using ConsoleApp1.shapes;

namespace ConsoleApp1.catalog;

public partial class ShapeCatalog
{
    public void SortedByArea()
    {
        Shape temp;
        string tempName;
        for (int i = 0; i < shapes.Count; i++)
        {
            for (int j = i + 1; j < shapes.Count; j++)
            {
                if (shapes[i].CalculateArea() > shapes[j].CalculateArea())
                {
                    temp = shapes[i];
                    shapes[i] = shapes[j];
                    shapes[j] = temp;
                }                   
            }            
        }
    }

    public void SortedByPerimeter()
    {
        Shape temp;
        string tempName;
        for (int i = 0; i < shapes.Count; i++)
        {
            for (int j = i + 1; j < shapes.Count; j++)
            {
                if (shapes[i].CalculatePerimeter() > shapes[j].CalculatePerimeter())
                {
                    temp = shapes[i];
                    shapes[i] = shapes[j];
                    shapes[j] = temp;
                }                   
            }            
        }
    }
}