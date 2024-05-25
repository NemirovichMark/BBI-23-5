using System;

abstract class Embrasure
{
    public string Name { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Thickness { get; set; }

    public Embrasure(string name, double width, double height, double thickness)
    {
        Name = name;
        Width = width;
        Height = height;
        Thickness = thickness;
    }

    public abstract double CalculateInstallationCost();

    public override string ToString()
    {
        return $"{Name}\t\t{Width}\t\t{Height}\t\t{Thickness}\t\t{CalculateInstallationCost():0.00}";
    }
}

class Window : Embrasure
{
    public int LayerCount { get; set; }

    public Window(string name, double width, double height, double thickness, int layerCount)
        : base(name, width, height, thickness)
    {
        LayerCount = layerCount;
    }

    public override double CalculateInstallationCost()
    {
        return Width * Height * 10 + LayerCount * 20;
    }
}

class Door : Embrasure
{
    public bool HasPattern { get; set; }
    public bool HasGlass { get; set; }

    public Door(string name, double width, double height, double thickness, bool hasPattern, bool hasGlass)
        : base(name, width, height, thickness)
    {
        HasPattern = hasPattern;
        HasGlass = hasGlass;
    }

    public override double CalculateInstallationCost()
    {
        double baseCost = Width * Height * 15;
        if (HasPattern) baseCost += 50;
        if (HasGlass) baseCost += 100;
        return baseCost;
    }
}

class Program
{
    static void Main()
    {
        Window[] windows = new Window[5]
        {
            new Window("Window1", 1.2, 1.5, 0.1, 2),
            new Window("Window2", 1.0, 1.2, 0.1, 3),
            new Window("Window3", 1.5, 1.5, 0.15, 1),
            new Window("Window4", 1.0, 1.5, 0.1, 2),
            new Window("Window5", 1.2, 1.2, 0.1, 3)
        };

        Door[] doors = new Door[5]
        {
            new Door("Door1", 0.9, 2.0, 0.2, true, false),
            new Door("Door2", 1.0, 2.1, 0.2, false, true),
            new Door("Door3", 0.8, 2.0, 0.18, true, true),
            new Door("Door4", 1.0, 2.2, 0.2, false, false),
            new Door("Door5", 0.9, 2.0, 0.2, true, false)
        };

        SortEmbrasures(windows);
        SortEmbrasures(doors);

        Console.WriteLine("Windows:");
        Console.WriteLine("Name\t\tWidth\t\tHeight\t\tThickness\tPrice");
        foreach (var window in windows)
        {
            Console.WriteLine(window);
        }

        Console.WriteLine("\nDoors:");
        Console.WriteLine("Name\t\tWidth\t\tHeight\t\tThickness\tPrice");
        foreach (var door in doors)
        {
            Console.WriteLine(door);
        }

        Embrasure[] embrasures = new Embrasure[windows.Length + doors.Length];
        CopyArray(windows, embrasures, 0);
        CopyArray(doors, embrasures, windows.Length);

        SortEmbrasures(embrasures);

        Console.WriteLine("\nAll Embrasures:");
        Console.WriteLine("Name\t\tWidth\t\tHeight\t\tThickness\tPrice");
        foreach (var embrasure in embrasures)
        {
            Console.WriteLine(embrasure);
        }
    }

    static void SortEmbrasures(Embrasure[] embrasures)
    {
        for (int i = 0; i < embrasures.Length - 1; i++)
        {
            for (int j = 0; j < embrasures.Length - i - 1; j++)
            {
                if (embrasures[j].CalculateInstallationCost() > embrasures[j + 1].CalculateInstallationCost())
                {
                    Embrasure temp = embrasures[j];
                    embrasures[j] = embrasures[j + 1];
                    embrasures[j + 1] = temp;
                }
            }
        }
    }
    static void CopyArray(Embrasure[] source, Embrasure[] destination, int startIndex)
    {
        for (int i = 0; i < source.Length; i++)
        {
            destination[startIndex + i] = source[i];
        }
    }
}