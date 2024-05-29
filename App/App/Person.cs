using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App
{
    [Serializable]
    [XmlRoot("Order")]
    public class Order : IOrder
    {
        [XmlIgnore]
        private List<MenuItemXml> items = new List<MenuItemXml>();

        [XmlIgnore]
        public List<MenuItemXml> Items
        {
            get => items;
            set => items = value;
        }

        [XmlElement("Items")]
        public MenuItemXml[] XmlItems
        {
            get => items.ToArray();
            set => items = new List<MenuItemXml>(value);
        }

        private double totalCost; // Стоимость заказа

        public double TotalCost
        {
            get => totalCost;
            set => totalCost = value;
        }

        public Order()
        {
            menuItems = new List<Menu>();
        }

        public class MenuItemXml
        {
            private string menuName;
            private int quantity;

            public string MenuName
            {
                get => menuName;
                set => menuName = value;
            }

            public int Quantity
            {
                get => quantity;
                set => quantity = value;
            }
        }

        public void Add(Menu item)
        {
            Add(item, 1);
        }

        public void Add(Menu item, int quantity)
        {
            string itemName = item.Name;
            var menuItem = items.Find(i => i.MenuName == itemName);
            if (menuItem == null)
            {
                items.Add(new MenuItemXml { MenuName = itemName, Quantity = quantity });
            }
            else
            {
                menuItem.Quantity += quantity;
            }
        }

        public void Remove(Menu item)
        {
            Remove(item, items.Find(i => i.MenuName == item.Name)?.Quantity ?? 0);
        }

        public void Remove(Menu item, int quantity)
        {
            string itemName = item.Name;
            var menuItem = items.Find(i => i.MenuName == itemName);
            if (menuItem != null)
            {
                if (menuItem.Quantity <= quantity)
                {
                    items.Remove(menuItem);
                }
                else
                {
                    menuItem.Quantity -= quantity;
                }
            }
        }
        public Order(List<Menu> menuItems)
        {
            this.menuItems = menuItems ?? new List<Menu>(); // Инициализация списком или пустым списком

        }


        public double MakeOrder(List<Menu> menuItems)
        {
            totalCost = 0; // Обнуляем стоимость перед пересчетом
            foreach (var item in items)
            {
                var menuItem = menuItems.Find(menu => menu.Name == item.MenuName);
                if (menuItem != null)
                {
                    totalCost += menuItem.Price * item.Quantity; // Обновляем TotalCost
                }
            }
            return totalCost;
        }


        public List<MenuItemXml> GetItems()
        {
            return items;
        }

        private List<Menu> menuItems;

        public override string ToString()
        {
            string result = "Your Order:\n";
            foreach (var item in items)
            {
                result += $"{item.MenuName} - Quantity: {item.Quantity}\n";
            }

            return $"{result}Total Cost: {TotalCost}";
        }
    }

    public interface IOrder
    {
        void Add(Menu item);
        void Add(Menu item, int quantity);
        void Remove(Menu item);
        void Remove(Menu item, int quantity);
    }

    public class Person
    {
        protected string surname;
        protected string name;
        protected int age;

        [XmlElement("Surname")]
        [JsonProperty("Surname")]
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        [XmlElement("Name")]
        [JsonProperty("Name")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [XmlElement("Age")]
        [JsonProperty("Age")]
        public int Age
        {
            get => age;
            set => age = value;
        }

        public Person(string surname, string name, int age)
        {
            Surname = surname;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Surname: {Surname}, Name: {Name}, Age: {Age}";
        }
    }

    [XmlInclude(typeof(Dessert))]
    [XmlInclude(typeof(Appetizer))]
    [XmlInclude(typeof(MainCourse))]
    [XmlInclude(typeof(Beverage))]
    public abstract class Menu
    {
        protected string name;
        protected string description;
        protected double price;

        [XmlElement("Name")]
        [JsonProperty("Name")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [XmlElement("Description")]
        [JsonProperty("Description")]
        public string Description
        {
            get => description;
            set => description = value;
        }

        [XmlElement("Price")]
        [JsonProperty("Price")]
        public double Price
        {
            get => price;
            set => price = value;
        }

        protected Menu(string name, string description, double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public Menu() { }

        public override string ToString()
        {
            return $"Name: {Name}\nDescription: {Description}\nPrice: {Price}";
        }
    }

    public class Appetizer : Menu
    {
        protected string ingredient;

        [XmlElement("Ingredient")]
        [JsonProperty("Ingredient")]
        public string Ingredient
        {
            get => ingredient;
            set => ingredient = value;
        }

        public Appetizer() : base("", "", 0)
        {
            ingredient = "";
        }

        public Appetizer(string name, string description, double price, string ingredient)
            : base(name, description, price)
        {
            Ingredient = ingredient;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nIngredient: {Ingredient}";
        }
    }

    public class MainCourse : Menu
    {
        protected int cookingTime;

        [XmlElement("CookingTime")]
        [JsonProperty("CookingTime")]
        public int CookingTime
        {
            get => cookingTime;
            set => cookingTime = value;
        }

        public MainCourse() : base("", "", 0)
        {
            cookingTime = 0;
        }

        public MainCourse(string name, string description, double price, int cookingTime)
            : base(name, description, price)
        {
            CookingTime = cookingTime;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nCooking Time: {CookingTime}";
        }
    }

    public class Dessert : Menu
    {
        protected string flavor;

        [XmlElement("Flavor")]
        [JsonProperty("Flavor")]
        public string Flavor
        {
            get => flavor;
            set => flavor = value;
        }

        public Dessert() : base("", "", 0)
        {
            flavor = "";
        }

        public Dessert(string name, string description, double price, string flavor)
            : base(name, description, price)
        {
            Flavor = flavor;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nFlavor: {Flavor}";
        }
    }

    public class Beverage : Menu
    {
        protected int volume;

        [XmlElement("Volume")]
        [JsonProperty("Volume")]
        public int Volume
        {
            get => volume;
            set => volume = value;
        }

        public Beverage() : base("", "", 0)
        {
            volume = 0;
        }

        public Beverage(string name, string description, double price, int volume)
            : base(name, description, price)
        {
            Volume = volume;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nVolume: {Volume} ml";
        }
    }
}