using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProtoBuf;

namespace С_1.People
{
    public partial class Student : IReportable
    {
        protected bool badStudent;
        private bool isCheckBadStudent = false;


        public bool BadStudent
        {
            get => badStudent;
            set
            {
                if (!isCheckBadStudent)
                {
                    badStudent = value;
                }
            }
        }
        protected void IsBadStudent()
        {
            int countTwo = 0;
            bool isSubjectAllFail = false;
            for (int i = 0; i < 10; ++i)
            {
                int currentTwo = 0;
                if (marks[0, i] == 2)
                {
                    currentTwo++;
                }
                if (marks[1, i] == 2)
                {
                    currentTwo++;
                }
                if (currentTwo == 2)
                {
                    isSubjectAllFail = true;
                }
                countTwo += currentTwo;
            }
            if (isSubjectAllFail && countTwo > 5)
            {
                badStudent = true;
            }
            else
            {
                badStudent = false;
            }

            isCheckBadStudent = true;
        }

        public string GenerateReport()
        {
            string[] matrixMark = new string[2] { "", "" };
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    matrixMark[i] += marks[i, j].ToString() + " ";
                }
            }
            string isBadStudent = badStudent ? "Да" : "Нет";
            return $"Студент:{surname + " " + name}\nВозраст:{age}\nID:{ID}\nСредний балл:{averageMark}\n" +
                   $"Количество пропусков:{misses}\nОценки за первую сессию:\n{matrixMark[0]}\nОценки за вторую сессию:\n{matrixMark[1]}\n" +
                   $"Студент является должником:{isBadStudent}";
        }

        public string PrintShortInfo()
        {
            return $"{surname + " " + name}. Возраст:{age}. Средний балл:{averageMark}\n";
        }
    }
}
