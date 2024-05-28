using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace С_1.People
{
    [ProtoBuf.ProtoContract]
    public class Group : ICountable, IReportable
    {

        protected string name;
        protected decimal avgMark;
        protected List<Student> students;

        [ProtoBuf.ProtoMember(1)]
        public string Name
        {
            get => name;
            set => name = value ?? string.Empty;
        }
        [ProtoBuf.ProtoMember(2)]
        [XmlElement("Student")]
        public List<Student> Students
        {
            get => students;
            set
            {
                if (students is null)
                {
                    students = new List<Student>();
                }
                AddStudents(value);
            }

        }

        public decimal AvgMark
        {
            get => avgMark;
        }

        public Group()
        {

        }

        [JsonConstructor]

        public Group(List<Student> Students)
        {
            students = Students;
        }

        public Group(string name)
        {
            this.name = name;
            students = new List<Student>();
        }



        public void AddStudent(Student student)
        {
            if (students.Count + 1 > 30)
            {
                Console.WriteLine("В группе уже максимальное количество студентов");
                return;
            }
            students.Add(student);
        }
        public void AddStudents(Student[] students)
        {
            if (this.students.Count + students.Length >= 30)
            {
                Console.WriteLine("В группе уже максимальное количество студентов");
                return;
            }
            this.students.AddRange(students);
        }
        public void AddStudents(List<Student> students)
        {
            if (this.students.Count + students.Count >= 30)
            {
                Console.WriteLine("В группе уже максимальное количество студентов");
                return;
            }
            this.students.AddRange(students);
        }
        public override string ToString()
        {
            if (students.Count < 10)
            {
                return $"Группа:{name}\nПредупреждение: В группе меньше 10 человек(Текущее количество человек:{students.Count}). Группа не может быть сформирована";
            }
            else if (students.Count > 30)
            {
                return $"Группа:{name}\nПредупреждение: В группе больше 30 человек(Текущее количество человек:{students.Count}). Группа не может быть сформирована";
            }
            else
            {
                return $"Группа:{name} Текущее количество человек:{students.Count}";
            }

        }

        public void SortAvgMarkDecreasing()
        {
            for (int i = 0; i < students.Count; ++i)
            {
                for (int j = i + 1; j < students.Count; ++j)
                {
                    if (students[i].AverageMark < students[j].AverageMark)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        public void SortAvgMark()
        {
            for (int i = 0; i < students.Count; ++i)
            {
                for (int j = i + 1; j < students.Count; ++j)
                {
                    if (students[i].AverageMark > students[j].AverageMark)
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        public int Count()
        {
            return students.Count;
        }

        public int Count(double mark)
        {
            int rightStudents = 0;
            decimal dMark = (decimal)mark;
            for (int i = 0; i < students.Count; ++i)
            {
                if (students[i].AverageMark == dMark)
                {
                    rightStudents++;
                }
            }
            return rightStudents;
        }

        public int Percentage(double partialValue, double totalValue)
        {
            decimal dPartialValue = (decimal)partialValue,
                    dTotalValue = (decimal)totalValue;
            int rightStudents = 0;
            for (int i = 0; i < students.Count; ++i)
            {
                if (students[i].AverageMark >= dPartialValue && students[i].AverageMark <= dTotalValue)
                {
                    rightStudents++;
                }
            }
            return rightStudents;
        }

        public void CalculateAvgMark()
        {
            avgMark = 0;
            for (int i = 0; i < students.Count; ++i)
            {
                avgMark += students[i].AverageMark;
            }
            avgMark /= students.Count;
            avgMark = Math.Round(avgMark, 2);
        }

        public static void SortStudent(List<Student> stud)
        {
            for (int i = 0; i < stud.Count; ++i)
            {

                for (int j = i + 1; j < stud.Count; ++j)
                {
                    if (stud[i].CompareTo(stud[j]) > 0)
                    {
                        Student temp = stud[i];
                        stud[i] = stud[j];
                        stud[j] = temp;
                    }
                }


            }
        }

        public string GenerateReport()
        {
            
            int averageMisses = 0,
                countBadStudent = 0;

            for (int i = 0; i < students.Count; ++i)
            {
                averageMisses += students[i].Misses;
                
                if (students[i].BadStudent)
                {
                    countBadStudent++;
                }
            }

            averageMisses /= students.Count;

            return $"Название:{name}\nКоличество человек:{students.Count}\nСредний балл по группе:{avgMark}\n" +
                $"Среднее количество пропусков на одного студента:{averageMisses}\nКоличество неуспевающих студентов:{countBadStudent}\n" +
                $"% неуспевающих студентов:{Math.Round((decimal)countBadStudent / students.Count * 100, 2)}";
        }
    }
}
