
/* создайте структуру goods с полями для названия, артикула (уникальное свойство), 
цены и количества. реализуйте метод для вывода информации о товаре и его количестве. 
в основной программе сделайте массив из 5 товаров, отсортируйте по стоимости
и выведите в виде таблицы.  */


/* Переделайте структуру в абстрактный класс Goods. Создайте классы-наследники Product, Equipment и Tool. 
У Product добавьте поле срок годности, у Equipment срок гарантии, у Tool класс качества. 
Переопределите метод для расчета стоимости товара в зависимости от дополнительного поля класса-наследника. 
Переопределите метод для вывода информации о товаре с учетом дополнительного поля класса-наследника. 
В основной программе сделайте массив из 5 экземпляров каждого класса, отсортируйте по возрастанию стоимости 
и выведите в виде 3х таблиц. Объедините их в один массив, отсортированный по возрастанию стоимости и выведите в виде таблицы. */

/*

struct Goods
{
    private string _name;
    public int _ID { get; private set; }
    private int _price; private int _quantity;
    private int _cost;
    public int cost => _cost;
    public Goods(string name, int id, int price, int quantity)
    {
        _name = name; _ID = id;
        _price = price; _quantity = quantity; _cost = price * quantity;
    }
    public void Print()
    {
        Console.WriteLine($"Название {_name}\t Артикул {_ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }
    public void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j].cost < a[imin].cost)
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
                new Goods ("Паровоз", 1, 24, 3),
                new Goods ("Самолет", 2, 34, 7),        
                new Goods ("Автомобиль", 3, 56, 2),
                new Goods ("Вертолет", 4, 45, 4),        
                new Goods ("Грузовик", 5, 32, 5)
        };
            foreach (Goods good in goods) { good.Sort(goods); }

            foreach (Goods good in goods) { good.Print(); }
        }
    }
}

*/

/*

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Xml.Schema;

abstract class Goods
{

    protected string _name;
    protected int _ID { get; private set; }
    protected int _cost;
    protected int _price;
    protected int _quantity;
    protected int _quality;
    protected int _guaranteeperiod;
    protected int _storagelife;

    public int cost => _cost;

    public Goods(string name, int id, int price, int quantity)
    {
        _name = name; _ID = id;
        _price = price; _quantity = quantity; _cost =  price * quantity;
    }
    public virtual void Cost()
    {
        _cost = _price * _quantity;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Название {_name} \t Артикул {_ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2} Стоимость {_cost}");
        
    }


    public virtual void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j].cost < a[imin].cost)
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

    public Tools(int quality, string name, int id, int price, int quantity) : base(name, id, price, quantity)
    {
        _quality = quality;
        _cost = _cost * quality;
    }
    public override void Print()
    {
        Console.WriteLine($"Класс качества {_quality}\t Название {_name}\t Артикул {_ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }

    public override void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j].cost < a[imin].cost)
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

class Product : Goods
{
    public Product(int guaranteeperiod, string name, int id, int price, int quantity) : base(name, id, price, quantity)
    {
        _guaranteeperiod = guaranteeperiod;
        _cost = _cost * guaranteeperiod / 15;
    }
    public override void Print()
    {
        Console.WriteLine($"Срок гарантии {_guaranteeperiod}\t Название {_name}\t Артикул {_ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }
    public override void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j].cost < a[imin].cost)
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

class Equipment : Goods
{
    public Equipment(int storagelife, string name, int id, int price, int quantity) : base(name, id, price, quantity)
    {
        _storagelife = storagelife;
        _cost = _cost * storagelife;
    }
    public override void Print()
    {
        Console.WriteLine($"Срок  хранения {_storagelife}\t Название {_name}\t Артикул {_ID:f2}\t Цена {_price:f2}\t Количество {_quantity:f2}\t Стоимость {_cost}");
    }
    public override void Sort(Goods[] a)
    {
        int imin;
        for (int i = 0; i < a.Length - 1; i++)
        {
            imin = i;

            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j].cost < a[imin].cost)
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
            Tools[] tools =
            {
            new Tools(5, "Перфоратор", 1, 24, 3),
            new Tools(4, "Шлифмашина", 2, 34, 7),
            new Tools(3, "Отвертка", 3, 56, 2),
            new Tools(2, "Молоток", 4, 45, 4),
            new Tools(5, "Болгарка", 5, 32, 5)
        };
            Console.WriteLine("Три отдельные таблицы:");
            Console.WriteLine();

            foreach (Tools tool in tools) { tool.Sort(tools); }

            foreach (var tool in tools) { tool.Print(); }
            Console.WriteLine();

            Product[] products =
            {
            new Product(12, "Печенье", 6, 45, 6),
            new Product(34, "Мармелад", 7, 17, 8),
            new Product(11, "Конфеты", 8, 29, 6),
            new Product(14, "Гранат", 9, 15, 9),
            new Product(20, "Газировка", 10, 56, 3)
        };

            foreach (Product product in products) { product.Sort(products); }

            foreach (Product product in products) { product.Print(); }
            Console.WriteLine();

            Equipment[] equipment =
            {
            new Equipment(3, "Ворота", 11, 22, 2),
            new Equipment(3, "Перчатки", 12, 43, 7),
            new Equipment(2, "Скейтборд", 13, 76, 2),
            new Equipment(5, "Ботинки", 14, 56, 4),
            new Equipment(3, "Клюшка", 15, 21, 5)
        };

            foreach (Equipment equip in equipment) { equip.Sort(equipment); }

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

            foreach (Goods goods in total) { goods.Sort(total); }

            foreach (Goods goods in total) { goods.Print(); }
        }
    }
}


*/ 