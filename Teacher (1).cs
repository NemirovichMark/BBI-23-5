using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace С_1.People
{
    public class Teacher : Person, IReportable
    {
        protected int seniority;
        protected string subject;
        protected List<Group> groups;



        public int Seniority
        {
            get => seniority;
            set => seniority = value;
        }

        public string Subject
        {
            get => subject;
            set => subject = value ?? string.Empty;
        }

        public string Groups
        {
            get => subject;
            set
            {
                if (groups is null)
                {
                    groups = new List<Group>();
                }
            }
        }

        public Teacher() : base()
        {

        }

        public Teacher(string surname, string name, int age, int seniority, string subject, List<Group> groups) : base(surname, name, age)
        {
            this.seniority = seniority;
            this.subject = subject;
            this.groups = groups;
        }

        public string GenerateReport()
        {
            string data = $"Преподаватель: Фамилия:{surname}, Имя:{name}, Возраст:{age}\nПредмет:{subject}, Стаж работы:{seniority}\n" +
                          $"Количество групп:{groups.Count}\n";
            List<Student> students = new List<Student>();
            for (int i = 0; i < groups.Count; ++i)
            {
                students.AddRange(groups[i].Students);
            }
            Group.SortStudent(students);

            int index = 0;
            foreach (var stud in students)
            {
                index++;
                data += $"{index}.{stud.PrintShortInfo()}\n";
            }

            return data;
        }


        public override string ToString()
        {
            string allGroupName = "";
            for (int i = 0; i < groups.Count; ++i)
            {
                allGroupName += (groups[i].Name + "\n");
            }
            return $"Учитель:{surname} {name}. Предмет:{subject}\nСписок групп:\n{allGroupName}";
        }
    }
}
