using System;

class Goods
{
    private string name;
    private string description;
    private double price;
    private string article;

    public Goods(string name, double price)
    {
        this.name = name;
        this.price = price;
        this.description = $"Для товара {name} описание не задано";
        this.article = Guid.NewGuid().ToString();
    }

    public string GetInfo()
    {
        return $"Название: {name}\nОписание: {description}\nЦена: {price}\nАртикул: {article}";
    }

    public void ChangeDescription(string newDescription)
    {
        if (newDescription.Length >= 20 && newDescription.Length <= 200)
        {
            description = newDescription;
        }
        else
        {
            Console.WriteLine("Описание должно быть от 20 до 200 символов!");
        }
    }

    public double GetPrice()
    {
        return price;
    }
}

class Program
{
    static void Main()
    {
        Goods[] goods = new Goods[]
        {
        new Goods("Товар 1", 100),
        new Goods("Товар 2", 150),
        new Goods("Товар 3", 120),
        new Goods("Товар 4", 80),
        new Goods("Товар 5", 200)
        };

        goods[1].ChangeDescription("Новое описание для товара 2");
        goods[2].ChangeDescription("Новое длинное описание для товара 3, чтобы проверить ограничение по символам");

        Console.WriteLine("Товары:");

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

        foreach (var item in goods)
        {
            Console.WriteLine(item.GetInfo());
            Console.WriteLine();
        }
    }
}


















































