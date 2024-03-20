using System;

abstract class Goods
{
    protected string name;
    protected double price;
    protected string article;

    public Goods(string name, double price)
    {
        this.name = name;
        this.price = price;
        this.article = Guid.NewGuid().ToString();
    }

    public abstract double GetPrice();

    public string GetName()
    {
        return name;
    }
}
class Beverage : Goods
{
    private double sugarConcentration;

    public Beverage(string name, double price, double sugarConcentration) : base(name, price)
    {
        this.sugarConcentration = sugarConcentration;
    }

    public override double GetPrice()
    {
        if (sugarConcentration > 5)
        {
            return price * 1.1;
        }
        else
        {
            return price;
        }
    }
}

class Food : Goods
{
    private int shelfLife; 

    public Food(string name, double price, int shelfLife) : base(name, price)
    {
        this.shelfLife = shelfLife;
    }

    public override double GetPrice()
    {
        if (shelfLife < 30)
        {
            return price * 1.05;
        }
        else if (shelfLife > 365)
        {
            return price * 0.95;
        }
        else
        {
            return price;
        }
    }
}

class Program
{
    static void Main()
    {
        Goods[] beverages = new Goods[]
        {
            new Beverage("Напиток 1", 100, 2),
            new Beverage("Напиток 2", 150, 7),
            new Beverage("Напиток 3", 120, 3),
            new Beverage("Напиток 4", 80, 6),
            new Beverage("Напиток 5", 200, 4)
        };

        Goods[] foods = new Goods[]
        {
            new Food("Продукт 1", 50, 15),
            new Food("Продукт 2", 80, 200),
            new Food("Продукт 3", 120, 20),
            new Food("Продукт 4", 70, 400),
            new Food("Продукт 5", 100, 10)
        };

        Console.WriteLine("Напитки:");

        BubbleSort(beverages);

        foreach (var item in beverages)
        {
            Console.WriteLine($"{item.GetName()} - Цена: {item.GetPrice():0.##}");
        }

        Console.WriteLine("\nПродукты:");

        BubbleSort(foods);

        foreach (var item in foods)
        {
            Console.WriteLine($"{item.GetName()} - Цена: {item.GetPrice():0.##}");
        }
    }

    static void BubbleSort(Goods[] goods)
    {
        for (int i = 0; i < goods.Length; i++)
        {
            for (int j = i + 1; j < goods.Length; j++)
            {
                if (goods[i].GetPrice() > goods[j].GetPrice())
                {
                    var temp = goods[i];
                    goods[i] = goods[j];
                    goods[j] = temp;
                }
            }
        }
    }
}