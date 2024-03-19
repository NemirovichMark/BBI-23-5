using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Практика_6_2_семестр.Program.Group3;

namespace Практика_6_2_семестр
{
    internal class Program
    {


        static void Main(string[] args)
        {

            Group1[] group1 = new Group1[5];
            group1[0] = new Group1("Анкунин", "1)", 5, 2, 3, 4, 5);
            group1[1] = new Group1("Грэм", "1)", 2, 3, 3, 3, 4);
            group1[2] = new Group1("Клиффгейт", "1)", 3, 3, 5, 5, 5);
            group1[3] = new Group1("Артон", "1)", 2, 4, 4, 4, 4);
            group1[4] = new Group1("Минхо", "1)", 5, 5, 2, 2, 3);

            Group2[] group2 = new Group2[5];
            group2[0] = new Group2("Лэнгдон", "2)", 4, 2, 3, 2, 5);
            group2[1] = new Group2("Леонидова", "2)", 5, 3, 5, 3, 4);
            group2[2] = new Group2("Ньюбон", "2)", 3, 2, 5, 4, 5);
            group2[3] = new Group2("Гитьянки", "2)", 2, 4, 2, 4, 5);
            group2[4] = new Group2("Крош", "2)", 2, 2, 2, 3, 3);

            Group3[] group3 = new Group3[5];
            group3[0] = new Group3("Сигоен", "3)", 4, 2, 3, 2, 5);
            group3[1] = new Group3("Карина", "3)", 5, 3, 5, 3, 2);
            group3[2] = new Group3("Куплинов", "3)", 3, 2, 5, 4, 5);
            group3[3] = new Group3("Днд", "3)", 2, 4, 2, 4, 5);
            group3[4] = new Group3("Киросан", "3)", 2, 2, 2, 2, 2);

            Group4[] group4 = new Group4[group1.Length];

            Console.WriteLine("");
            for (int i = 0; i < group1.Length; i++)
            {
                int c = group1[i].Ex1 + group1[i].Ex2 + group1[i].Ex3 + group1[i].Ex4 + group1[i].Ex5;
                group4[i] = new Group4(group1[i].Surname, group1[i].GroupName, c);

                //Console.WriteLine("{0} {1} {2}", group4[i].Surname, group1[i].GroupName, group4[i].Ex1);
            }

            Console.WriteLine();

            Group5[] group5 = new Group5[group2.Length];
            for (int i = 0; i < group2.Length; i++)
            {
                int c = group2[i].Ex1 + group2[i].Ex2 + group2[i].Ex3 + group2[i].Ex4 + group2[i].Ex5;
                group5[i] = new Group5(group2[i].Surname, group2[i].GroupName, c);
                //Console.WriteLine("{0} {1} {2}", group5[i].Surname, group2[i].GroupName, group5[i].Ex1);
            }
            Console.WriteLine();

            Group6[] group6 = new Group6[group3.Length];
            for (int i = 0; i < group3.Length; i++)
            {
                int c = group3[i].Ex1 + group3[i].Ex2 + group3[i].Ex3 + group3[i].Ex4 + group3[i].Ex5;
                group6[i] = new Group6(group3[i].Surname, group3[i].GroupName, c);
                //Console.WriteLine("{0} {1} {2}", group6[i].Surname, group3[i].GroupName, group6[i].Ex1);
            }
            Console.WriteLine();

            double j = 0;
            double l = 0;
            double u = 0;

            // 

            for (int i = 0; i < group4.Length; i++)
            {
                j = j + group4[i].Ex1;

                l = l + group5[i].Ex1;
                u = u + group6[i].Ex1;
            }


            j = j / (5 * group1.Length);
            l = l / (5 * group2.Length);
            u = u / (5 * group3.Length);

            Group7[] group7 = new Group7[3];
            group7[0] = new Group7(group4[group4.Length - 1].GroupName, j);
            group7[1] = new Group7(group5[group5.Length - 1].GroupName, l);
            group7[2] = new Group7(group6[group6.Length - 1].GroupName, u);

            //Console.WriteLine("{0} {1}", group7[0].GroupName, j);
            //Console.WriteLine("{0} {1}", group7[1].GroupName, l);
            //Console.WriteLine("{0} {1}", group7[2].GroupName, u);

            Console.WriteLine();
            Console.WriteLine("Список групп в порядке убывания среднего балла");

            Group7 h;
            for (int i = 0; i < 3; i++)
            {
                for (int r = 1; r < 3; r++)
                {
                    if (group7[r - 1].Ex1 < group7[r].Ex1)
                    {
                        h = group7[r - 1];
                        group7[r - 1] = group7[r];
                        group7[r] = h;

                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                //Console.WriteLine ("{0} {1}", group7[i].GroupName, group7[i].Ex1);
                group7[i].Print();
            }



            //int sum = 0;
            //Array.ForEach(group4, delegate (int i) { sum += i; });
            //Console.WriteLine(sum);

            //for (int i = 0; i < group3.Length; i)
            //{
            //    int t += group4[i];
            //    Console.WriteLine(t);
            //}
            Console.ReadKey();


        }

        internal struct Group1
        {
            public string Surname { get; private set; }
            public string GroupName { get; private set; }
            public int Ex1 { get; private set; }
            public int Ex2 { get; private set; }
            public int Ex3 { get; private set; }
            public int Ex4 { get; private set; }
            public int Ex5 { get; private set; }

            public Group1(string surname, string groupname, int ex1, int ex2, int ex3, int ex4, int ex5)
            {
                Surname = surname;
                GroupName = groupname;
                Ex1 = ex1;
                Ex2 = ex2;
                Ex3 = ex3;
                Ex4 = ex4;
                Ex5 = ex5;
            }

        }

        internal struct Group2
        {
            public string Surname { get; private set; }
            public string GroupName { get; private set; }
            public int Ex1 { get; private set; }
            public int Ex2 { get; private set; }
            public int Ex3 { get; private set; }
            public int Ex4 { get; private set; }
            public int Ex5 { get; private set; }

            public Group2(string surname, string groupname, int ex1, int ex2, int ex3, int ex4, int ex5)
            {
                Surname = surname;
                GroupName = groupname;
                Ex1 = ex1;
                Ex2 = ex2;
                Ex3 = ex3;
                Ex4 = ex4;
                Ex5 = ex5;
            }

        }

        internal struct Group3
        {
            public string Surname { get; private set; }
            public string GroupName { get; private set; }
            public int Ex1 { get; private set; }
            public int Ex2 { get; private set; }
            public int Ex3 { get; private set; }
            public int Ex4 { get; private set; }
            public int Ex5 { get; private set; }

            public Group3(string surname, string groupname, int ex1, int ex2, int ex3, int ex4, int ex5)
            {
                Surname = surname;
                GroupName = groupname;
                Ex1 = ex1;
                Ex2 = ex2;
                Ex3 = ex3;
                Ex4 = ex4;
                Ex5 = ex5;
            }

            internal struct Group4
            {
                public string Surname { get; private set; }
                public string GroupName { get; private set; }
                public int Ex1 { get; private set; }


                public Group4(string surname, string groupname, int ex1)
                {
                    Surname = surname;
                    Ex1 = ex1;
                    GroupName = groupname;

                }

            }

            internal struct Group5
            {
                public string Surname { get; private set; }
                public string GroupName { get; private set; }
                public int Ex1 { get; private set; }


                public Group5(string surname, string groupname, int ex1)
                {
                    Surname = surname;
                    Ex1 = ex1;
                    GroupName = groupname;

                }

            }

            internal struct Group6
            {
                public string Surname { get; private set; }
                public string GroupName { get; private set; }
                public int Ex1 { get; private set; }


                public Group6(string surname, string groupname, int ex1)
                {
                    Surname = surname;
                    Ex1 = ex1;
                    GroupName = groupname;

                }

            }

            internal struct Group7
            {

                public string GroupName { get; private set; }
                public double Ex1 { get; private set; }


                public Group7(string groupname, double ex1)
                {

                    Ex1 = ex1;
                    GroupName = groupname;

                }

                public void Print()
                {
                    Console.WriteLine("{0} {1}", GroupName, Ex1);
                }
            }
        }
    }
}
