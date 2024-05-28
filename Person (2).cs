using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_1.People
{
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(5, typeof(Student))]
    public class Person : IComparable<Person>
    {

        protected string surname;
        protected string name;
        protected int age;

        [ProtoBuf.ProtoMember(1)]
        public string Surname
        {
            get => surname;
            set => surname = value ?? string.Empty;
        }

        [ProtoBuf.ProtoMember(2)]
        public string Name
        {
            get => name;
            set => name = value ?? string.Empty;
        }

        [ProtoBuf.ProtoMember(3)]
        public int Age
        {
            get => age;
            set => age = value;
        }

        public Person()
        {
            name = "";
            surname = "";
        }

        public Person(string surname, string name, int age)
        {
            this.surname = surname;
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"Студент:{surname} {name}. Возраст:{age}";
        }

        public int CompareTo(Person other)
        {
            int lastNameComparison = string.Compare(this.surname, other.surname);
            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }
            return string.Compare(this.name, other.name);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Name == person2.Name && person1.Surname == person2.Surname;
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return person1.Name != person2.Name || person1.Surname != person2.Surname;
        }

        public static bool operator <(Person person1, Person person2)
        {
            return person1.CompareTo(person2) < 0;
        }

        public static bool operator >(Person person1, Person person2)
        {
            return person1.CompareTo(person2) > 0;
        }

        public static bool operator <=(Person person1, Person person2)
        {
            return person1.CompareTo(person2) <= 0;
        }

        public static bool operator >=(Person person1, Person person2)
        {
            return person1.CompareTo(person2) >= 0;
        }


    }


}
