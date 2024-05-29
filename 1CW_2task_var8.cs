using System;

abstract class Goods
{
    private static int NextId = 1;

    protected readonly int id;
    protected string name;
    protected string article;
    protected double price;
    protected string description;
    protected int quantity;

    public Goods(string name, string article, double price, int quantity)
    {
        this.id = NextId++;
        this.name = name;
        this.article = article;
        this.price = price;
        this.description = $"Для товара {name} описание не задано";
        this.quantity = quantity;
    }

    public abstract void PrintInfo();

    public void ChangeDescription(string newDescription)
    {
        if (newDescription.Length >= 20 && newDescription.Length <= 200)
        {
            description = newDescription;
        }
        else
        {
            Console.WriteLine("Описание должно содержать от 20 до 200 символов");
        }
    }

    //public static void PrintTableHeader()
    //{
    //    Console.WriteLine($"{"Название",10} {"Артикул",10} {"Цена",10} {"Описание",10} {"Количество",45}");
    //}

    //public static void PrintTableRow(Goods item)
    //{
    //    Console.WriteLine($"{item.name,10} {item.article,10} {item.price,10} {item.description,15} {item.quantity,20}");
    //}

    public static void SortByPriceBeverage(Beverage[] beverages)
    {
        for (int i = 0; i < beverages.Length - 1; i++)
        {
            for (int j = 0; j < beverages.Length - 1 - i; j++)
            {
                if (beverages[j].price > beverages[j + 1].price)
                {
                    SwapBeverage(ref beverages[j], ref beverages[j + 1]);
                }
            }
        }
    }
    public static void SortByPriceFood(Food[] foods)
    {
        for (int i = 0; i < foods.Length - 1; i++)
        {
            for (int j = 0; j < foods.Length - 1 - i; j++)
            {
                if (foods[j].price > foods[j + 1].price)
                {
                    SwapFood(ref foods[j], ref foods[j + 1]);
                }
            }
        }
    }

    private static void SwapBeverage(ref Beverage a, ref Beverage b)
    {
        Beverage temp = a;
        a = b;
        b = temp;
    }
    private static void SwapFood(ref Food a, ref Food b)
    {
        Food temp = a;
        a = b;
        b = temp;
    }
}

class Beverage : Goods
{
    public double SugarConcentration { get; set; }

    public Beverage(string name, string article, double price, int quantity, double sugarConcentration) : base(name, article, price, quantity)
    {
        SugarConcentration = sugarConcentration;
        if (SugarConcentration > 5)
        {
            price *= 1.1; 
        }
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Напиток: {name}\tАртикул: {article}\tЦена: {price}\tОписание: {description}\tКоличество: {quantity}\tКонцентрация сахара: {SugarConcentration}%");
    }
}

class Food : Goods
{
    public int ExpiryDays { get; set; }

    public Food(string name, string article, double price, int quantity, int expiryDays) : base(name, article, price, quantity)
    {
        ExpiryDays = expiryDays;
        if (ExpiryDays < 30)
        {
            price *= 1.05; 
        }
        else if (ExpiryDays > 365)
        {
            price *= 0.95; 
        }
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Продукт: {name}\tАртикул: {article}\tЦена: {price}\tОписание: {description}\tКоличество: {quantity}\tСрок годности: {ExpiryDays} дней");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Beverage[] beverages = new Beverage[]
        {
            new Beverage("Кола", "C001", 2.5, 100, 7),
            new Beverage("Чай", "T123", 1.8, 50, 3),
            new Beverage("Кофе", "C456", 3.0, 70, 4),
            new Beverage("Сок", "J789", 1.2, 120, 8),
            new Beverage("Лимонад", "L246", 1.5, 80, 6)
        };
        Beverage.SortByPriceBeverage(beverages);
       
        foreach (var beverage in beverages)
        {
            beverage.PrintInfo();
        }

        Food[] foods = new Food[]
        {
            new Food("Яблоко", "A433", 1.0, 50, 10),
            new Food("Дыня", "C555", 0.8, 70, 60),
            new Food("Апельсин", "M777", 2.2, 30, 25),
            new Food("Виноград", "B111", 0.5, 100, 365),
            new Food("Гранат", "M999", 5.0, 20, 400)
        };
        Food.SortByPriceFood(foods);

        foreach (var food in foods)
        {
            food.PrintInfo();
        }
    }
}
