using ConsoleApp1.catalog;

namespace ConsoleApp1.serialize;

public abstract class MySerializer
{
    public abstract ShapeCatalog Read(string filename);

    public abstract void Write(ShapeCatalog shapeCatalog, string filename);
}