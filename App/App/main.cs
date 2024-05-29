using System;
using System.Collections.Generic;
using System.IO;
using Serializers;
using App;

class Program
{
    static void Main()
    {
        Random random = new Random();

        // Создание элементов меню
        List<Menu> menuItems = new List<Menu>
        {
            new Dessert("Тирамису", "Итальянский десерт с маскарпоне и кофе", 250, "Итальянский десерт"),
            new Dessert("Чизкейк", "Сырный торт с фруктовой подливкой", 260, "Сырный десерт"),
            new Dessert("Пирожное", "Нежное пирожное с заварным кремом", 200, "Французский десерт"),
            new Dessert("Маффин", "Воздушный маффин с изюмом", 180, "Выпечка"),
            new Dessert("Шоколадный фондан", "Тает во рту шоколадный десерт", 280, "Десерт с шоколадом"),
            new Dessert("Фруктовый салат", "Свежие фрукты с мятным сиропом", 150, "Легкий десерт"),

            new MainCourse("Паста Болоньезе", "Макароны с мясным соусом и пармезаном", 170, 4),
            new MainCourse("Карри с курицей", "Традиционное индийское блюдо с куриной грудкой и овощами", 160, 2),
            new MainCourse("Ризотто с грибами", "Рис с ароматными грибами и пармезаном", 180, 5),
            new MainCourse("Стейк", "Поджаренный сочный стейк", 300, 3),
            new MainCourse("Куриные крылышки BBQ", "Жареные крылышки в соусе BBQ", 220, 2),
            new MainCourse("Фаршированная картошка", "Картофель, фаршированный сыром и зеленью", 200, 3),

            new Appetizer("Гуакамоле", "Авокадо, помидоры, лук, специи", 50, "Мексиканская закуска"),
            new Appetizer("Кальмары по-корейски", "Хрустящие кальмары в соусе", 60, "Острый и хрустящий"),
            new Appetizer("Креветки в кляре", "Сочные креветки в хрустящем кляре", 80, "Закуска с морепродуктами"),
            new Appetizer("Салат Цезарь", "Салат с курицей, сыром, и гренками", 120, "Классический салат"),
            new Appetizer("Брускетта", "Хрустящий хлеб с помидорами и базиликом", 70, "Итальянская закуска"),
            new Appetizer("Сырные палочки", "Хрустящие палочки из сырного теста", 90, "Закуска с сыром"),

            new Beverage("Яблочный сок", "Описание яблочного сока", 100, random.Next(250, 500)),
            new Beverage("Апельсиновый сок", "Описание апельсинового сока", 120, random.Next(250, 500)),
            new Beverage("Горячий шоколад", "Ароматный горячий шоколад с маршмеллоу", 150, random.Next(200, 400)),
            new Beverage("Кофе", "Ароматный кофе из сортовых зерен", 80, random.Next(150, 300)),
            new Beverage("Чай", "Черный чай с лимоном и мятой", 70, random.Next(150, 250)),
            new Beverage("Смузи", "Освежающий смузи с ягодами и бананом", 200, random.Next(300, 500))
        };

        // Создание списков для каждой категории блюд
        List<Dessert> desserts = new List<Dessert>();
        List<MainCourse> mainCourses = new List<MainCourse>();
        List<Appetizer> appetizers = new List<Appetizer>();
        List<Beverage> beverages = new List<Beverage>();

        foreach (var item in menuItems)
        {
            if (item is Dessert)
                desserts.Add(item as Dessert);
            else if (item is MainCourse)
                mainCourses.Add(item as MainCourse);
            else if (item is Appetizer)
                appetizers.Add(item as Appetizer);
            else if (item is Beverage)
                beverages.Add(item as Beverage);
        }

        // Выбор половины блюд рандомно из каждой категории
        List<Menu> halfOrderItems = new List<Menu>();

        // Выбираем случайные элементы из каждой категории
        halfOrderItems.AddRange(GetRandomItems(desserts, random));
        halfOrderItems.AddRange(GetRandomItems(mainCourses, random));
        halfOrderItems.AddRange(GetRandomItems(appetizers, random));
        halfOrderItems.AddRange(GetRandomItems(beverages, random));

        // Метод для выбора половины элементов из списка
        static List<Menu> GetRandomItems<T>(List<T> items, Random random) where T : Menu
        {
            int halfCount = items.Count / 2;
            List<Menu> randomItems = new List<Menu>();

            for (int i = 0; i < halfCount; i++)
            {
                Menu randomItem = items[random.Next(items.Count)] as Menu;
                if (randomItem != null)
                {
                    randomItems.Add(randomItem);
                }
            }

            return randomItems;
        }

        // Создание клиентов с случайным бюджетом
        Customer[] customers = new Customer[3];
        for (int i = 0; i < customers.Length; i++)
        {
            customers[i] = new Customer($"Surname{i + 1}", $"Customer{i + 1}", random.Next(18, 50), random.Next(10000, 20000));
            foreach (var item in halfOrderItems)
            {
                customers[i].AddToOrder(item, customers[i].Money, menuItems);
            }
        }

        // Создание сериализаторов
        MySerializer jsonSerializer = new MyJsonSerializer();
        MySerializer xmlSerializer = new MyXmlSerializer();

        // Определение путей файлов
        string rawJsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "raw_data.json");
        string rawXmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "raw_data.xml");
        string dataJsonPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "data.json");
        string sortedXmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "sorted_data.xml");

        // Сериализация начальных данных
        jsonSerializer.Write(customers, rawJsonPath);
        xmlSerializer.Write(customers, rawXmlPath);

        // Добавление дополнительных элементов в заказы
        for (int i = 0; i < customers.Length; i++)
        {
            for (int j = menuItems.Count / 2; j < menuItems.Count; j++)
            {
                customers[i].AddToOrder(menuItems[j], customers[i].Money, menuItems);
            }
            customers[i].AddToOrder(menuItems[0], customers[i].Money, menuItems);
            customers[i].AddToOrder(menuItems[0], customers[i].Money, menuItems);
            // Добавляем случайное блюдо из изначального списка три раза
            Menu randomMenuItem = menuItems[random.Next(menuItems.Count)];
            customers[i].AddToOrder(randomMenuItem, customers[i].Money, menuItems);
            customers[i].AddToOrder(randomMenuItem, customers[i].Money, menuItems);
            customers[i].AddToOrder(randomMenuItem, customers[i].Money, menuItems);
        }

        // Сериализация измененных данных
        jsonSerializer.Write(customers, dataJsonPath);

        // Сортировка заказов по цене (пузырьковая сортировка)
        foreach (var customer in customers)
        {
            var itemList = customer.Order.GetItems();
            for (int i = 0; i < itemList.Count - 1; i++)
            {
                for (int j = 0; j < itemList.Count - i - 1; j++)
                {
                    var menuItem1 = FindMenuItemByName(menuItems, itemList[j].MenuName);
                    var menuItem2 = FindMenuItemByName(menuItems, itemList[j + 1].MenuName);

                    if (menuItem1 != null && menuItem2 != null)
                    {
                        if (menuItem1.Price > menuItem2.Price)
                        {
                            var temp = itemList[j];
                            itemList[j] = itemList[j + 1];
                            itemList[j + 1] = temp;
                        }
                    }
                    else
                    {
                        Console.WriteLine("One of the items is not found in the menu.");
                    }
                }
            }
            customer.Order.XmlItems = itemList.ToArray();
        }

        // Сортировка клиентов по общей стоимости заказа
        for (int i = 0; i < customers.Length - 1; i++)
        {
            for (int j = 0; j < customers.Length - i - 1; j++)
            {
                if (customers[j].Order.TotalCost > customers[j + 1].Order.TotalCost)
                {
                    var temp = customers[j];
                    customers[j] = customers[j + 1];
                    customers[j + 1] = temp;
                }
            }
        }

        // Сериализация сортированных данных
        xmlSerializer.Write(customers, sortedXmlPath);


        string[] allFiles = { rawJsonPath, rawXmlPath, dataJsonPath, sortedXmlPath };
        foreach (string file in allFiles)
        {
            MySerializer serializer = file.EndsWith(".json") ? jsonSerializer : xmlSerializer;
            Customer[] deserializedCustomers = serializer.Read<Customer[]>(file);
            Console.WriteLine($"Data from {Path.GetFileName(file)}:");
            foreach (var customer in deserializedCustomers)
            {

                Console.WriteLine(customer.ToString()); // Вывод информации о клиенте и его заказе
                Console.WriteLine();
            }
        }

        // Метод для поиска элемента меню по имени
        static Menu FindMenuItemByName(List<Menu> menuItems, string name)
        {
            foreach (var menuItem in menuItems)
            {
                if (menuItem.Name == name)
                {
                    return menuItem;
                }
            }
            return null;
        }
        //Console.ReadLine();
       

    }
}

