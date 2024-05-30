using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace App
{
    public partial class Customer : Person
    {
        [XmlElement("Money")]
        [JsonProperty("Money")]
        protected double money;

        public double Money
        {
            get => money;
            set => money = value;
        }

        public Customer(string name, string surname, int age, double money) : base(name, surname, age)
        {
            Money = money;
        }
        public void SortOrderItemsByPrice(List<Menu> menuItems)
        {
            var itemList = Order.GetItems();
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
            Order.XmlItems = itemList.ToArray();
        }
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

        void IPayable.Pay(List<Menu> menuItems)
        {
            double totalCost = order.MakeOrder(menuItems);
            if (money >= totalCost)
            {
                Console.WriteLine($"Payment successful! Total cost: {totalCost}");
                money -= totalCost;
            }
            else
            {
                Console.WriteLine("Insufficient funds to pay for the order!");
            }
        }
    }
}
