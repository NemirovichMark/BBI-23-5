using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using static App.Customer;

namespace App
{
    public partial class Customer : Person, IPayable
    {
        [XmlElement("Order")]
        [JsonProperty("Order")]
        protected Order order;

        [XmlIgnore]
        private List<Menu> menuItems;
        public Customer() : base("", "", 0)
        {
            
        }

        [XmlElement("CustomerOrder")]
        public Order Order
        {
            get => order;
            set => order = value;
        }

        public Customer(string name, string surname, int age, List<Menu> menuItems) : base(name, surname, age)
        {
            this.menuItems = menuItems;
            order = new Order(menuItems);
        }

        public void AddToOrder(Menu item, double budget, List<Menu> menuItems)
        {
            if (order == null)
            {
                order = new Order(menuItems);
            }

            if (order.MakeOrder(menuItems) + item.Price <= budget)
            {
                order.Add(item);
            }
            else
            {
                Console.WriteLine("The cost of the order exceeds your budget!");
            }
        }

        public List<Order.MenuItemXml> GetOrderItems()
        {
            return order.GetItems();
        }

        public void SetOrder(Order newOrder)
        {
            order = newOrder;
        }

        public void Pay(List<Menu> menuItems)
        {
            double totalCost = order.MakeOrder(menuItems);
            Console.WriteLine($"Total cost of the order: {totalCost}");
            Console.WriteLine("Payment successful!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{Order.ToString()}";
        }

        
    }
}
