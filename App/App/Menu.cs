using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace App
{
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
