
abstract class Goods
{

    protected string _name;
    protected int _price;
    protected int _quantity;
    protected int _cost;

    public Goods(string name, int price, int quantity)
    {
        _name = name;
        _price = price; _quantity = quantity; 
    }
    public abstract int Calculate();
    public void Cost(int newcost)
    {
        _cost = newcost;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Название {_name} \t Артикул \t Цена {_price:f2}\t Количество {_quantity:f2} Стоимость {_cost}");

    }

    public static void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j]._cost < a[imin]._cost)
                {
                    imin = j;
                }
            }
            Goods Temp = a[i];
            a[i] = a[imin];
            a[imin] = Temp;
        }

    }
}


class Tools : Goods
{
    private static int _id;
    public readonly int ID;
    private int _quality;
    public Tools(int quality, string name, int price, int quantity) : base(name, price, quantity)
    {
        _quality = quality;
        _id++;
        ID = _id;
    }

    public override int Calculate()
    {
        return _price * _quantity * _quality;
    }

    public override void Print()
    {
        Console.WriteLine($"Класс качества {_quality}\t Название {_name}\t Артикул {ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }

}

class Product : Goods
{
    private static int _id = 5;
    public readonly int ID;
    private int _expirationdate;
    public Product(int expirationdate, string name, int price, int quantity) : base(name, price, quantity)
    {
        _expirationdate = expirationdate;
        _id++;
        ID = _id;
    }
    public override int Calculate()
    {
        return _price * _quantity * _expirationdate/ 7;
    }
    public override void Print()
    {
        Console.WriteLine($"Срок годности {_expirationdate}\t Название {_name}\t Артикул {ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }
   
}

class Equipment : Goods
{
    private static int _id = 10;
    public readonly int ID;
    private int _storagelife;
    public Equipment(int storagelife, string name, int price, int quantity) : base(name, price, quantity)
    {
        _storagelife = storagelife;
        ID = _id++;
    }
    public override int Calculate()
    {
        return _price * _quantity * _storagelife;
    }
    public override void Print()
    {
        Console.WriteLine($"Срок гарантии  {_storagelife}\t Название {_name}\t Артикул {ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }
}

    class Program
    {
        static void Main()
        {
            Tools[] tools =
            {
            new Tools(5, "Перфоратор", 24, 3),
            new Tools(4, "Шлифмашина", 34, 7),
            new Tools(3, "Отвертка", 56, 2),
            new Tools(2, "Молоток",  45, 4),
            new Tools(5, "Болгарка",  32, 5)
            };
            Console.WriteLine("Три отдельные таблицы:");
            Console.WriteLine();
            foreach (var tool in tools)
            {
            tool.Cost(tool.Calculate());
            }
            Goods.Sort(tools);

            foreach (var tool in tools) { tool.Print(); }
            Console.WriteLine();

            Product[] products =
            {
            new Product(12, "Печенье", 45, 6),
            new Product(34, "Мармелад", 17, 8),
            new Product(11, "Конфеты", 29, 6),
            new Product(14, "Гранат", 15, 9),
            new Product(20, "Газировка",  56, 3)
            };
            foreach (var product in products)
            {
            product.Cost(product.Calculate());
            }
        
            Goods.Sort(products);

            foreach (Product product in products) { product.Print(); }
            Console.WriteLine();

            Equipment[] equipment =
            {
            new Equipment(3, "Ворота", 22, 2),
            new Equipment(3, "Перчатки", 43, 7),
            new Equipment(2, "Скейтборд", 76, 2),
            new Equipment(5, "Ботинки", 56, 4),
            new Equipment(3, "Клюшка", 21, 5)
            };
            foreach (var equip in equipment)
            {
            equip.Cost(equip.Calculate());
            }
            Goods.Sort(equipment);

            foreach (Equipment equip in equipment) { equip.Print(); }
            Console.WriteLine();

            Goods[] total = new Goods[equipment.Length + products.Length + tools.Length];
            {
                for (int i = 0; i < equipment.Length; i++)
                    total[i] = equipment[i];
                for (int j = 0; j < products.Length; j++)
                    total[equipment.Length + j] = products[j];
                for (int u = 0; u < tools.Length; u++)
                    total[products.Length + equipment.Length + u] = tools[u];
            }
            Console.WriteLine("Общая таблица:");
            Console.WriteLine();

            Goods.Sort(total); 

            foreach (Goods goods in total) { goods.Print(); }
        }
    }



