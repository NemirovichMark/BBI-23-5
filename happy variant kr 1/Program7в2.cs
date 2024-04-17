using System.Xml.Linq;


abstract class Goods
{
    protected string _name;
    protected string _artic;
    protected int _cost;
    public int Cost => _cost;
    protected int _kolvo;
    public Goods(string name, string artic, int cost, int kolvo)
    {
        _name = name;
        _artic = artic;
        _cost = cost;
        _kolvo = kolvo;
    }
    public virtual void Print()
    {
        Console.WriteLine("Товар   {0}\t Количество {1}\t Информация {2}\t",
                        _name, _kolvo, _artic);
    }
    protected virtual double GetCost()
    {
        return _cost;
    }

}
class Product : Goods
{
    private int _SrokGodnosti;
    // вызов конструктора родительского класса
    public Product(string name, string artic, int cost,int kolvo, int srokgodnosti) : base(name, artic, cost,kolvo)
    {
        _SrokGodnosti = srokgodnosti;
    }
    public override void Print()
    {
        Console.WriteLine("Товар: {0}\tКоличество: {1}\tИнформация: {2}\tСрок годности: {3} дней", _name, _kolvo, _artic, _SrokGodnosti);
    }
    protected override double GetCost()
    {
        double extraCost =  _cost * 0.1 * _SrokGodnosti;
        return _cost + extraCost;
    }
}
class Equipment : Goods
{
    private int _SrokGarant;
    public Equipment(string name, string artic, int cost, int kolvo, int srokgarant) : base(name, artic, cost, kolvo)
    {
        _SrokGarant = srokgarant;
    }
    public override void Print()
    {
        Console.WriteLine("Товар: {0}\tКоличество: {1}\tИнформация: {2}\tСрок гарантии: {3} дней", _name, _kolvo, _artic, _SrokGarant);
    }
    protected override double GetCost()
    {
        double extraCost = _cost * 0.1 * _SrokGarant;
        return _cost + extraCost;
    }
}
class Tool : Goods
{
    private string _Class;
    public Tool(string name, string artic, int cost, int kolvo, string classkac) : base(name, artic, cost, kolvo)
    {
        _Class = classkac;
    }
    public override void Print()
    {
        Console.WriteLine("Товар: {0}\tКоличество: {1}\tИнформация: {2}\tКласс качества: {3}", _name, _kolvo, _artic, _Class);
    }
    protected override double GetCost()
    {
        double extraCost = 1;
        if (_Class == "A")
        {
             extraCost = _cost * 5;
        }
        else if (_Class == "B")
        {
             extraCost = _cost * 3;
        }
        return _cost + extraCost;
    }
}
class Program
{
    static void Main()
    {
        Goods[] products = new Goods[]
        {
            new Product("мыло","хозяйственное",100,5,100),
            new Product("вода","минеральная",25,100,30),
            new Product("каша","перловая",38,145,60),
            new Product("крупа","манная",300,4,100),
            new Product("семга","слабосоленая",1500,10,3)
        };
        Goods[] equipments = new Goods[]
        {
            new Equipment("Телевизор", "LED", 15000, 2, 24),
            new Equipment("Холодильник", "No Frost", 30000, 1, 36),
            new Equipment("Умный дом", "Яндекс", 5000, 3, 12),
            new Equipment("Микроволновка", "С грилем", 8000, 2, 18),
            new Equipment("Кофеварка", "Капельная", 4000, 5, 12)
        };
        Goods[] tools = new Goods[]
        {
            new Tool("Отвертка", "Крестообразная", 300, 10, "A"),
            new Tool("Молоток", "Стальной", 500, 8, "B"),
            new Tool("Пила", "Дисковая", 800, 5, "A"),
            new Tool("Ножницы", "Для ткани", 200, 15, "C"),
            new Tool("Дрель", "Беспроводная", 1000, 3, "A")
        };
        Sorting(products);
        Sorting(equipments);
        Sorting(tools);
        Console.WriteLine();
        foreach (Goods good in products)
        {
            good.Print();
        }
        Console.WriteLine();
        foreach (Goods good in equipments)
        {
            good.Print();
        }
        Console.WriteLine();
        foreach (Goods good in tools)
        {
            good.Print();
        }
        Goods[] allGoods = new Goods[products.Length + equipments.Length + tools.Length];
        obedinenie(allGoods, products, equipments, tools);
        static void obedinenie(Goods [] allGoods,Goods [] products,Goods [] equipments,Goods [] tools)
        {
            int index = 0;
            foreach (Goods good in products)
            {
                allGoods[index++] = good;
            }
            foreach (Goods good in equipments)
            {
                allGoods[index++] = good;
            }
            foreach (Goods good in tools)
            {
                allGoods[index++] = good;
            }
        }
        Console.WriteLine();
        Sorting(allGoods);
        foreach (Goods good in allGoods)
        {
            good.Print();
        }
        static void Sorting(Goods[] c1)
        {
            int n = c1.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (c1[j].Cost > c1[j + 1].Cost)
                    {
                        Goods temp = c1[j];
                        c1[j] = c1[j + 1];
                        c1[j + 1] = temp;
                    }
                }
            }
        }

    }
}
