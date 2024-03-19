using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_5_2_семестр
{
    internal struct Chess
    {
        public string Surname {  get; private set; }
        public double Game1 { get; private set; }
        public double Game2 { get; private set;}
        public double Game3 { get; private set;}

        public Chess (string surname, double game1, double game2, double game3)
        {
            Surname = surname;
            Game1 = game1;
            Game2 = game2;
            Game3 = game3;
        }


    }
    internal struct Result
    {
        public string Surname { get; private set; }
        public double Game123 { get; private set;}

        public Result(string aurname, double game123)
        {
            Surname= aurname;
            Game123 = game123;
        }
    }

}
