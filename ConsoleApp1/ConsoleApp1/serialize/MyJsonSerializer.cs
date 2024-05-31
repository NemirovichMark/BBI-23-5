using System.Text.Json;
using ConsoleApp1.catalog;

namespace ConsoleApp1.serialize;

public class MyJsonSerializer : MySerializer
{
    public override void Write(ShapeCatalog shapeCatalog, string filename)
    {
        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            // Обработка ошибок
            try
            {
                JsonSerializer.Serialize(fs, shapeCatalog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    public override ShapeCatalog Read(string filename)
    {
        using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
        {
            try
            {
                return JsonSerializer.Deserialize<ShapeCatalog>(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null; // если не получилось десериализовать, то вернем null
            }
        }
    }
}