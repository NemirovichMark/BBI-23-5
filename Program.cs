//         //задача 1

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.ConstrainedExecution; //using System.Text;
//using System.Threading.Tasks;


//namespace labaaaaa6
//{
//    struct Member
//    {
//        private string _firstName;
//        private string _secondName;
//        private float _res1;
//        private float _res2;

//        // Исправлено: изменено на public и переименовано в FIO
//        public string FIO { get { return _firstName + " " + _secondName; } }
//        public float BestResult { get { return _res1 > _res2 ? _res1 : _res2; } }

//        public Member(string firstName, string secondName, float res1, float res2)
//        {
//            _firstName = firstName;
//            _secondName = secondName;
//            _res1 = res1;
//            _res2 = res2;
//        }

//        public void Print() => Console.WriteLine($"Name: {FIO}\nResult1: {_res1}\nResult2: {_res2}\nBestResult: {BestResult}");
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Member[] members = new Member[4];
//            members[0] = new Member("дима", "димааа", 2.4f, 1.0f);
//            members[1] = new Member("валерий", "валериииий", 2.6f, 1.4f);
//            members[2] = new Member("леша", "лешаааа", 1.5f, 1.3f);
//            members[3] = new Member("рик", "морти", 2.3f, 1.4f);
//            Sort(members);
//            foreach (Member member in members)
//            {
//                // Изменено: вывод информации перемещен внутрь структуры
//                Console.WriteLine(member.FIO + " " + member.BestResult);
//            }
//            Console.ReadLine();
//        }

//        static void Sort(Member[] members)
//        {
//            for (int i = 0; i < members.Length - 1; i++)
//            {
//                for (int j = i; j < members.Length; j++)
//                {
//                    if (members[j].BestResult > members[i].BestResult)
//                    {
//                        Member temp = members[i];
//                        members[i] = members[j];
//                        members[j] = temp;
//                    }
//                }
//            }
//        }
//    }
//}








////задача 2


//using System;
//using System.Collections.Generic; //using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace labaaaaa62
//{
//    class Program
//    {
//        private struct Student
//        {
//            private string _name; //  добавил модификатор private
//            private int[] _grades;

//            // добавлен модификатор public и удален set
//            public string FIO { get { return _name; } }

//            public Student(string name, int[] grades)
//            {
//                _name = name;
//                _grades = grades;
//            }

//            public float AverageGrade()
//            {
//                float res = 0;
//                for (int i = 0; i < _grades.Length; i++)
//                {
//                    if (_grades[i] == 2)
//                    {
//                        return 0;
//                    }
//                    res += _grades[i];
//                }
//                res = res / _grades.Length;
//                return res;
//            }

//            public void Print()
//            {
//                if (AverageGrade() != 0)
//                {
//                    Console.WriteLine($"{FIO} {AverageGrade()}"); //  вывод информации перетащил внутрь структуры
//                }
//                else
//                {
//                    Console.WriteLine($"{FIO} отчислен"); //вывод информации перемещен внутрь структуры
//                }
//            }
//        }

//        static void Main()
//        {
//            Student[] students = new Student[5];
//            students[0] = new Student("сергей сергеййййй", new int[] { 3, 4, 5 });
//            students[1] = new Student("джэк джэкккк", new int[] { 3, 3, 3 });
//            students[2] = new Student("лера лераааа", new int[] { 4, 3, 4 });
//            students[3] = new Student("рик рииикк", new int[] { 4, 4, 5 });
//            students[4] = new Student("мартин мартинннн", new int[] { 3, 2, 5 });
//            Sort(students);
//            foreach (Student student in students)
//            {
//                student.Print();
//            }
//            Console.ReadLine();
//        }

//        static void Sort(Student[] students)
//        {
//            if (students == null || students.Length <= 0) { return; } //Сделал валидацию на пропуск к сортировке
//            for (int i = 0; i < students.Length - 1; i++)
//            {
//                for (int j = i; j < students.Length; j++)
//                {
//                    if (students[j].AverageGrade() > students[i].AverageGrade())
//                    {
//                        Student temp = students[i];
//                        students[i] = students[j];
//                        students[j] = temp;
//                    }
//                }
//            }
//        }
//    }
//}








////задача 3


//using System;
//using System.Collections.Generic; //using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace laaaabaaa63
//{
//    public struct Person
//    {
//        private string _name;
//        private int _pos;

//        // Исправлено: добавлен модификатор public и удален set
//        public string Name { get { return _name; } }

//        public int Pos { get { return _pos; } }

//        public Person(string name, int pos)
//        {
//            _name = name;
//            _pos = pos;
//        }
//    }

//    class Program
//    {
//        private struct Team
//        {
//            private string _name;
//            private Person[] _persons;

//            public string Name { get { return _name; } }

//            public Person[] Persons { get { return _persons; } }

//            public Team(string name, Person[] persons)
//            {
//                _name = name;
//                _persons = persons;
//            }

//            public int TeamPoints()
//            {
//                int points = 0;
//                foreach (Person person in _persons)
//                {
//                    switch (person.Pos)
//                    {
//                        case (1):
//                            points += 5;
//                            break;
//                        case (2):
//                            points += 4;
//                            break;
//                        case (3):
//                            points += 3;
//                            break;
//                        case (4):
//                            points += 2;
//                            break;
//                        case (5):
//                            points += 1;
//                            break;
//                        default:
//                            break;
//                    }
//                }
//                return points;
//            }

//            public void Print() => Console.WriteLine($"Team: {Name} Points: {TeamPoints()}");//Вывод информации осуществляется внутри структуры
//        }

//        static void Main()
//        {
//            Person[] teamgood = new Person[6];
//            teamgood[0] = new Person("бобр", 3);
//            teamgood[1] = new Person("киров", 6);
//            teamgood[2] = new Person("щевченко", 8);
//            teamgood[3] = new Person("марина", 14);
//            teamgood[4] = new Person("ира", 16);
//            teamgood[5] = new Person("саша", 15);
//            Person[] teambad = new Person[6];
//            teambad[0] = new Person("рэй", 1);
//            teambad[1] = new Person("гослинг", 7);
//            teambad[2] = new Person("дима", 5);
//            teambad[3] = new Person("билан", 10);
//            teambad[4] = new Person("апрель", 11);
//            teambad[5] = new Person("гудгейм", 12);
//            Person[] teamsun = new Person[6];
//            teamsun[0] = new Person("кот", 2);
//            teamsun[1] = new Person("грим", 4);
//            teamsun[2] = new Person("гарри", 9);
//            teamsun[3] = new Person("поттер", 4);
//            teamsun[4] = new Person("рич", 17);
//            teamsun[5] = new Person("стич", 13);
//            Team[] teams = new Team[3];
//            teams[0] = new Team("good", teamgood);
//            teams[1] = new Team("bad", teambad);
//            teams[2] = new Team("sun", teamsun);
//            Sort(teams);
//            foreach (Team team in teams)
//            {
//                team.Print();
//            }
//            Console.ReadLine();
//        }

//        static void Sort(Team[] teams)
//        {
//            for (int i = 0; i < teams.Length - 1; i++)
//            {
//                for (int j = i; j < teams.Length; j++)
//                {
//                    if (teams[j].TeamPoints() > teams[i].TeamPoints())
//                    {
//                        Team temp = teams[i];
//                        teams[i] = teams[j];
//                        teams[j] = temp;
//                    }
//                    else if (teams[j].TeamPoints() == teams[i].TeamPoints())
//                    {
//                        if (Favorite(teams[j]))
//                        {
//                            Team temp = teams[i];
//                            teams[i] = teams[j];
//                            teams[j] = temp;
//                        }
//                        else { continue; }
//                    }
//                }
//            }
//        }

//        static bool Favorite(Team team)
//        {
//            foreach (Person person in team.Persons)
//            {
//                if (person.Pos == 1)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//    }
//}


