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
