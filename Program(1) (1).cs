using С_1.People;
using С_1.Serializers;

namespace C_1
{
    internal class Program
    {

        public static void PrintData(Group[] gp)
        {
            foreach (var group in gp)
            {
                Console.WriteLine(group.Name);
                int index = 1;
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"{index}.{student.Surname} {student.Name}. Средний балл:{student.AverageMark}");
                    index++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int[,] CreateMarks()
        {
            int[,] marks = new int[2, 10];
            Random rd = new Random();
            for (int j = 0; j < 2; ++j)
            {

                for (int k = 0; k < 10; ++k)
                {
                    marks[j, k] = rd.Next(2, 6);
                }

            }
            return marks;
        }

        public static void ShuffleStudents(Student[] students)
        {
            Random rd = new Random();
            for (int i = 0; i < students.Length; i++)
            {
                int randomIndex = rd.Next(i, students.Length);
                Student temp = students[randomIndex];
                students[randomIndex] = students[i];
                students[i] = temp;
            }
        }

        public static void SortStudents(Student[] students)
        {

            for (int i = 0; i < students.Length; ++i)
            {

                for (int j = i + 1; j < students.Length; ++j)
                {
                    if (students[i].CompareTo(students[j]) > 0)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }


            }
        }
        

        static void Main(string[] args)
        {

            Random rd = new Random();
            Student[] students = new Student[100];
            students[0] = new Student("Дорофеева", "Регина", 22, CreateMarks(), rd.Next(0, 51));
            students[1] = new Student("Позднякова", "Валентина", 22, CreateMarks(), rd.Next(0, 51));
            students[2] = new Student("Курочкина", "Оксана", 21, CreateMarks(), rd.Next(0, 51));
            students[3] = new Student("Герасимова", "Марьям", 19, CreateMarks(), rd.Next(0, 51));
            students[4] = new Student("Маркина", "Эдита", 21, CreateMarks(), rd.Next(0, 51));
            students[5] = new Student("Трофимов", "Платон", 23, CreateMarks(), rd.Next(0, 51));
            students[6] = new Student("Сергеева", "Анжела", 18, CreateMarks(), rd.Next(0, 51));
            students[7] = new Student("Евдокимов", "Марк", 20, CreateMarks(), rd.Next(0, 51));
            students[8] = new Student("Токарев", "Максим", 21, CreateMarks(), rd.Next(0, 51));
            students[9] = new Student("Куликова", "Мила", 22, CreateMarks(), rd.Next(0, 51));
            students[10] = new Student("Костина", "Люция", 23, CreateMarks(), rd.Next(0, 51));
            students[11] = new Student("Малышев", "Георгий", 21, CreateMarks(), rd.Next(0, 51));
            students[12] = new Student("Шилов", "Платон", 24, CreateMarks(), rd.Next(0, 51));
            students[13] = new Student("Воробьев", "Фёдор", 25, CreateMarks(), rd.Next(0, 51));
            students[14] = new Student("Борисова", "Василиса", 19, CreateMarks(), rd.Next(0, 51));
            students[15] = new Student("Тимофеева", "Екатерина", 19, CreateMarks(), rd.Next(0, 51));
            students[16] = new Student("Поздняков", "Олег", 18, CreateMarks(), rd.Next(0, 51));
            students[17] = new Student("Белоусов", "Мансур", 20, CreateMarks(), rd.Next(0, 51));
            students[18] = new Student("Селиванова", "Лада", 21, CreateMarks(), rd.Next(0, 51));
            students[19] = new Student("Дубровин", "Тихон", 22, CreateMarks(), rd.Next(0, 51));
            students[20] = new Student("Моисеев", "Лазарь", 23, CreateMarks(), rd.Next(0, 51));
            students[21] = new Student("Еремин", "Денис", 21, CreateMarks(), rd.Next(0, 51));
            students[22] = new Student("Белов", "Тихон", 20, CreateMarks(), rd.Next(0, 51));
            students[23] = new Student("Бирюков", "Валерий", 23, CreateMarks(), rd.Next(0, 51));
            students[24] = new Student("Карасева", "Валерия ", 22, CreateMarks(), rd.Next(0, 51));
            students[25] = new Student("Парфенова", "Валерия", 21, CreateMarks(), rd.Next(0, 51));
            students[26] = new Student("Гаврилова", "Мила", 23, CreateMarks(), rd.Next(0, 51));
            students[27] = new Student("Филатова", "Аида", 21, CreateMarks(), rd.Next(0, 51));
            students[28] = new Student("Львова", "Зульфия", 20, CreateMarks(), rd.Next(0, 51));
            students[29] = new Student("Королев", "Иван", 19, CreateMarks(), rd.Next(0, 51));
            students[30] = new Student("Михеева", "Есения", 21, CreateMarks(), rd.Next(0, 51));
            students[31] = new Student("Муравьев", "Святослав", 22, CreateMarks(), rd.Next(0, 51));
            students[32] = new Student("Терехова", "Алена", 19, CreateMarks(), rd.Next(0, 51));
            students[33] = new Student("Серебряков", "Марсель", 20, CreateMarks(), rd.Next(0, 51));
            students[34] = new Student("Чернова", "Елена", 20, CreateMarks(), rd.Next(0, 51));
            students[35] = new Student("Трофимова", "Люция", 22, CreateMarks(), rd.Next(0, 51));
            students[36] = new Student("Колесова", "Пелагея", 23, CreateMarks(), rd.Next(0, 51));
            students[37] = new Student("Гуляева", "Анжела", 24, CreateMarks(), rd.Next(0, 51));
            students[38] = new Student("Колосов", "Михаил", 23, CreateMarks(), rd.Next(0, 51));
            students[39] = new Student("Цветкова", "Владислава", 19, CreateMarks(), rd.Next(0, 51));
            students[40] = new Student("Некрасов", "Иннокентий", 19, CreateMarks(), rd.Next(0, 51));
            students[41] = new Student("Макарова", "Валерия", 25, CreateMarks(), rd.Next(0, 51));
            students[42] = new Student("Леонова", "Тина", 21, CreateMarks(), rd.Next(0, 51));
            students[43] = new Student("Фролов", "Эльдар", 18, CreateMarks(), rd.Next(0, 51));
            students[44] = new Student("Царева", "Джулия", 22, CreateMarks(), rd.Next(0, 51));
            students[45] = new Student("Селиванова", "Александра", 21, CreateMarks(), rd.Next(0, 51));
            students[46] = new Student("Архипов", "Николай", 22, CreateMarks(), rd.Next(0, 51));
            students[47] = new Student("Голованов", "Денис", 21, CreateMarks(), rd.Next(0, 51));
            students[48] = new Student("Шилова", "Кристина", 24, CreateMarks(), rd.Next(0, 51));
            students[49] = new Student("Никитина", "Зоя", 23, CreateMarks(), rd.Next(0, 51));
            students[50] = new Student("Константинова", "Лариса", 22, CreateMarks(), rd.Next(0, 51));
            students[51] = new Student("Родина", "Аврора", 21, CreateMarks(), rd.Next(0, 51));
            students[52] = new Student("Назарова", "Лина", 24, CreateMarks(), rd.Next(0, 51));
            students[53] = new Student("Грачев", "Леонид", 21, CreateMarks(), rd.Next(0, 51));
            students[54] = new Student("Алешин", "Геннадий", 23, CreateMarks(), rd.Next(0, 51));
            students[55] = new Student("Щукин", "Ярослав", 20, CreateMarks(), rd.Next(0, 51));
            students[56] = new Student("Кузьмина", "Руслана", 20, CreateMarks(), rd.Next(0, 51));
            students[57] = new Student("Петровский", "Роман", 19, CreateMarks(), rd.Next(0, 51));
            students[58] = new Student("Горбачева", "Мария", 22, CreateMarks(), rd.Next(0, 51));
            students[59] = new Student("Соколова", "Мелания", 21, CreateMarks(), rd.Next(0, 51));
            students[60] = new Student("Пименова", "Виталия", 19, CreateMarks(), rd.Next(0, 51));
            students[61] = new Student("Алексеева", "Эльза", 23, CreateMarks(), rd.Next(0, 51));
            students[62] = new Student("Яковлева", "Гульнара", 22, CreateMarks(), rd.Next(0, 51));
            students[63] = new Student("Плотникова", "Жанна", 22, CreateMarks(), rd.Next(0, 51));
            students[64] = new Student("Лопатина", "Айгуль", 19, CreateMarks(), rd.Next(0, 51));
            students[65] = new Student("Давыдов", "Герасим", 21, CreateMarks(), rd.Next(0, 51));
            students[66] = new Student("Горячева", "Мелания", 21, CreateMarks(), rd.Next(0, 51));
            students[67] = new Student("Гордеева", "Марина", 24, CreateMarks(), rd.Next(0, 51));
            students[68] = new Student("Петровская", "Мила", 18, CreateMarks(), rd.Next(0, 51));
            students[69] = new Student("Краснова", "Гузель", 22, CreateMarks(), rd.Next(0, 51));
            students[70] = new Student("Кудряшова", "Сабина", 21, CreateMarks(), rd.Next(0, 51));
            students[71] = new Student("Попова", "Римма", 19, CreateMarks(), rd.Next(0, 51));
            students[72] = new Student("Маслова", "Ольга", 20, CreateMarks(), rd.Next(0, 51));
            students[73] = new Student("Львова", "Полина", 18, CreateMarks(), rd.Next(0, 51));
            students[74] = new Student("Тимофеева", "Майя", 23, CreateMarks(), rd.Next(0, 51));
            students[75] = new Student("Седова", "Эвелина", 19, CreateMarks(), rd.Next(0, 51));
            students[76] = new Student("Тарасова", "Анастасия", 21, CreateMarks(), rd.Next(0, 51));
            students[77] = new Student("Афанасьева", "Дина", 22, CreateMarks(), rd.Next(0, 51));
            students[78] = new Student("Хохлов", "Ефим", 23, CreateMarks(), rd.Next(0, 51));
            students[79] = new Student("Игнатьев", "Евгений", 18, CreateMarks(), rd.Next(0, 51));
            students[80] = new Student("Елисеев", "Муслим", 20, CreateMarks(), rd.Next(0, 51));
            students[81] = new Student("Панфилов", "Дмитрий", 18, CreateMarks(), rd.Next(0, 51));
            students[82] = new Student("Исаева", "Эдита", 22, CreateMarks(), rd.Next(0, 51));
            students[83] = new Student("Рябова", "Люция", 21, CreateMarks(), rd.Next(0, 51));
            students[84] = new Student("Литвинов", "Рустам", 24, CreateMarks(), rd.Next(0, 51));
            students[85] = new Student("Степанов", "Артур", 21, CreateMarks(), rd.Next(0, 51));
            students[86] = new Student("Аксенова", "Зоя", 21, CreateMarks(), rd.Next(0, 51));
            students[87] = new Student("Ефимов", "Святослав", 22, CreateMarks(), rd.Next(0, 51));
            students[88] = new Student("Столяров", "Григорий", 20, CreateMarks(), rd.Next(0, 51));
            students[89] = new Student("Хомяков", "Моисей", 23, CreateMarks(), rd.Next(0, 51));
            students[90] = new Student("Седов", "Яков", 21, CreateMarks(), rd.Next(0, 51));
            students[91] = new Student("Цветкова", "Элла", 22, CreateMarks(), rd.Next(0, 51));
            students[92] = new Student("Ильин", "Алексей", 19, CreateMarks(), rd.Next(0, 51));
            students[93] = new Student("Маслова", "Лилиана", 20, CreateMarks(), rd.Next(0, 51));
            students[94] = new Student("Никитин", "Эдуард", 21, CreateMarks(), rd.Next(0, 51));
            students[95] = new Student("Завьялов", "Филипп", 18, CreateMarks(), rd.Next(0, 51));
            students[96] = new Student("Чернов", "Прохор", 19, CreateMarks(), rd.Next(0, 51));
            students[97] = new Student("Зуев", "Алексей", 22, CreateMarks(), rd.Next(0, 51));
            students[98] = new Student("Нефедова", "Северина", 23, CreateMarks(), rd.Next(0, 51));
            students[99] = new Student("Березин", "Лазарь", 21, CreateMarks(), rd.Next(0, 51));


            ShuffleStudents(students);

            Student[] studentsArray1 = new Student[50];
            Console.WriteLine("Array 1:");
            for (int i = 0; i < 50; i++)
            {
                studentsArray1[i] = students[i];
                Console.WriteLine($"{students[i].Name} {students[i].Surname} {students[i].Age}");
            }
            Console.WriteLine();
            SortStudents(studentsArray1);

            ShuffleStudents(students);
            Group[] groups = new Group[5];
            int index = 0;
            for (int i = 0; i < 5; ++i)
            {
                groups[i] = new Group($"ББИ-23-{i + 1}");
                Console.WriteLine($"Group {groups[i].Name}:");                                
                for (int j = 0; j < 20; ++j)
                {
                    groups[i].AddStudent(students[index]);
                    Console.WriteLine($"{students[index].Name} {students[index].Surname} {students[index].Age}");
                    index++;
                }
                Console.WriteLine();
                Group.SortStudent(groups[i].Students);
            }


            ShuffleStudents(students);

            Group[] gp = new Group[3];
            int[] num = new int[3] { 10, 12, 14 };
            index = 0;
            for (int i = 0; i < 3; ++i)
            {

                gp[i] = new Group($"ББИ-23-{i + 1}");
                Console.WriteLine($"Group {gp[i].Name}:");
                for (int j = 0; j < num[i]; ++j)
                {
                    gp[i].AddStudent(students[index]);
                    Console.WriteLine($"{students[index].Name} {students[index].Surname} {students[index].Age}");
                    index++;
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            MyJsonSerializer js = new MyJsonSerializer();
            MyXmlSerializer xm = new MyXmlSerializer();
            MyBinarySerializer bn = new MyBinarySerializer();



            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path = Path.Combine(path, "Sample1");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }


            js.WriteGroups(gp, Path.Combine(path, "raw_data.json"));
            xm.WriteGroups(gp, Path.Combine(path, "raw_data.xml"));
            bn.WriteGroups(gp, Path.Combine(path, "raw_data.bin"));


            for (int i = 0; i < 3; ++i)
            {
                gp[i].SortAvgMarkDecreasing();
            }

            js.WriteGroups(gp, Path.Combine(path, "data.json"));

            for (int i = 0; i < 3; ++i)
            {
                gp[i].SortAvgMark();
            }

            xm.WriteGroups(gp, Path.Combine(path, "data.xml"));

            Group[] ggg = xm.ReadGroups(Path.Combine(path, "raw_data.xml"));
            PrintData(ggg);

            ggg = js.ReadGroups(Path.Combine(path, "data.json"));
            PrintData(ggg);

            ggg = xm.ReadGroups(Path.Combine(path, "data.xml"));
            PrintData(ggg);

            for (int i = 0; i < 3; ++i)
            {
                gp[i].CalculateAvgMark();
            }

            int index1;
            if (gp[0].AvgMark <= gp[1].AvgMark && gp[0].AvgMark <= gp[2].AvgMark)
            {
                index1 = 0;
            }
            else if (gp[1].AvgMark <= gp[0].AvgMark && gp[1].AvgMark <= gp[2].AvgMark)
            {
                index1 = 1;
            }
            else
            {
                index1 = 2;
            }

            Console.WriteLine("Группа с худшей успеваемостью:");
            Console.WriteLine(gp[index1].GenerateReport());
            Console.WriteLine();
            index = 1;
            foreach (var student in gp[index1].Students)
            {
                Console.WriteLine($"{index}. " + student.GenerateReport());
                Console.WriteLine();
                index++;
            }

            for (int i = 0; i < 3; ++i)
            {
                Group.SortStudent(gp[i].Students);
            }

            bn.WriteGroups(gp, Path.Combine(path, "data.bin"));

            Teacher tc = new Teacher("Филатов", "Иван", 48, 20, "Математика", js.ReadGroups(Path.Combine(path, "raw_data.json")).ToList());
            Console.WriteLine(tc.GenerateReport());

            Console.WriteLine("Плохие студенты:");
            index = 1;
            for (int i = 0; i < students.Length; ++i)
            {
                if (students[i].BadStudent)
                {
                    Console.WriteLine($"{index}. " + students[i].ToString());
                    Console.WriteLine();
                    index++;
                }
            }

        }
    }
}


