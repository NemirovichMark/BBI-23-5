
struct Goods
{
    private string _name;
    private static int id;
    public int _ID { get; private set; }
    private int _price; private int _quantity;
    private int _cost;
    public Goods(string name, int price, int quantity)
    {
        _name = name; id++; _ID = id;
        _price = price; _quantity = quantity; _cost = price * quantity;
    }
    public void Print()
    {        Console.WriteLine($"Название {_name}\t Артикул {_ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }
     static void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j]._cost > a[imin]._cost)
                {
                    imin = j;
                }
            }
            Goods Temp = a[i];
            a[i] = a[imin];
            a[imin] = Temp;
        }
    }
    class Program
    {
        static void Main()
        {
            Goods[] goods =
            {
                new Goods ("Паровоз", 24, 3),
                new Goods ("Самолет", 34, 7),
                new Goods ("Автомобиль", 56, 2),
                new Goods ("Вертолет", 45, 4),
                new Goods ("Грузовик", 32, 5)
        };
            Sort(goods);

            foreach (Goods good in goods) { good.Print(); }
        }
    }
}


