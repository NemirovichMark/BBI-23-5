using System;

struct Goods
{
    private static int NextId = 1;

    private readonly int id;
    private string name;
    private string article;
    private double price;
    private string description;
    private int quantity;

    public Goods(string name, string article, double price, int quantity)
    {
        this.id = NextId++;
        this.name = name;
        this.article = article;
        this.price = price;
        this.description = $"Для товара {name} описание не задано";
        this.quantity = quantity;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {name}\tАртикул: {article}\tЦена: {price}\tОписание: {description}\tКоличество: {quantity}");
    }

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

    public static void PrintTableHeader()
    {
        Console.WriteLine($"{"Название",10} {"Артикул",10} {"Цена",10} {"Описание",10} {"Количество",45}");
    }

    public static void PrintTableRow(Goods item)
    {
        Console.WriteLine($"{item.name,10} {item.article,10} {item.price,10} {item.description,15} {item.quantity,20}");
    }

    public static void SortByPrice(Goods[] goods)
    {
        for (int i = 0; i < goods.Length - 1; i++)
        {
            for (int j = 0; j < goods.Length - 1 - i; j++)
            {
                if (goods[j].price > goods[j + 1].price)
                {
                    Swap(ref goods[j], ref goods[j + 1]);
                }
            }
        }
    }

    private static void Swap(ref Goods a, ref Goods b)
    {
        Goods temp = a;
        a = b;
        b = temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Goods[] goods = new Goods[]
        {
   new Goods("Яблоко", "A433", 39, 72),
   new Goods("Дыня", "S556", 79, 27),
   new Goods("Апельсин", "C911", 29, 95),
   new Goods("Виноград", "K228", 69, 56),
   new Goods("Гранат", "P007", 109, 30)
        };

        goods[0].ChangeDescription("очень сочное и очень вкусное свежее яблоко))");
        goods[2].ChangeDescription("очень сладкий апельсин очень круто");
        goods[3].ChangeDescription("вкусный виноград очень крутой без косточек");

        Goods.SortByPrice(goods);
        Goods.PrintTableHeader();
        foreach (var item in goods)
        {
            Goods.PrintTableRow(item);
        }
    }
}
