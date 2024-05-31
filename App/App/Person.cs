using System.Xml.Serialization;
using Newtonsoft.Json;

namespace App
{
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
}
