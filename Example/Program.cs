struct Building
{
    private int _height;
    private int _width;
    private string _name;
    public int Height => _height; // свойство только для чтения
    public int Width
    {
        get => _width; // чтение
        set => _width = value; // запись
    }
    // public int Height {get {return _height;};} - то же самое

    //public int Width
    //{
    //    get { return _width; } // чтение
    //    set { _width = value; } // запись
    //}
    public Building(int h, int w, string n)
    {
        _height = h;
        _width = w;
        _name = n;
    }
    public void Rebuild(int newHeight)
    {
        _height += newHeight;
    }
    public void Print()
    {
        Console.WriteLine(_name + ": " + _height + " " + _width);
        Console.WriteLine(GetCost());
    }
    private double GetCost()
    {
        return _height * _width * 1.25;
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Building moscow_city = new Building(); // конструктор по умолчанию
        Building moscow_city2 = new Building(100, 20, "Federation Tower"); // конструктор по умолчанию
        //moscow_city.Print();
       // moscow_city2.Print();

        Building[] houses = new Building[]
        {
            new Building(100, 25, "Federation Tower"),
            new Building(185, 30, "Modern Tower"),
            new Building(70, 20, "Q Tower"),
            new Building(60, 40, "IT Tower")
        };

        foreach (Building house in houses)
        {
            house.Print();
        }

        Sort(houses);

        foreach (Building house in houses)
        {
            house.Print();
        }

        moscow_city = FindWidthest(houses);
        Console.WriteLine("Max:");
        moscow_city.Print();

    }
    static Building FindWidthest(Building[] houses)
    {
        if (houses != null && houses.Length < 1) // валидация - проверка на существование и наполненность данными
            return new Building();
        Building max = houses[0];
        for (int i = 1; i <  houses.Length; i++)
        {
            if (houses[i].Width > max.Width)
                max = houses[i];
        }
        return max;
    }
    // Gnome sort гномья сортировка
        static void Sort(Building[] houses)
    {
        int i = 0, j = 1;
        while (j < houses.Length-1)
        {
            if (i < 0 || houses[i].Height >= houses[i + 1].Height)
            {
                i = j;
                j++;
            }
            while (i >= 0 && houses[i].Height < houses[i+1].Height)
            {
                Building temp = houses[i];
                houses[i] = houses[i+1];
                houses[i+1] = temp;
                i--;
            }
        }
    }
}
