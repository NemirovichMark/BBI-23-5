using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProtoBuf;

namespace С_1.People
{
    [ProtoBuf.ProtoContract]
    public partial class Student : Person
    {

        protected static int maxID = 0;

        public readonly int ID;
        protected int[,] marks = new int[2, 10];
        protected decimal averageMark;
        protected int misses;
        private bool isCalculateAverage = false;


        [ProtoIgnore]
        [JsonIgnore]
        [XmlIgnore]
        public int[,] Marks
        {
            get
            {
                int[,] copyMarks = new int[2, 10];
                for (int i = 0; i < 2; ++i)
                {
                    for (int j = 0; j < 10; ++j)
                    {
                        copyMarks[i, j] = marks[i, j];
                    }
                }
                return copyMarks;
            }
            set
            {
                if (value.GetLength(0) == 2 && value.GetLength(1) == 10)
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        for (int j = 0; j < 10; ++j)
                        {
                            marks[i, j] = value[i, j];
                        }
                    }
                    CalculateAverageMark();
                    IsBadStudent();
                }
            }
        }

        [ProtoBuf.ProtoMember(1)]
        public int[] AllMark 
        {
            get
            {
                int[] arrayMarks = new int[20];
                for (int i = 0; i < 2; ++i)
                {
                    for (int j = 0; j < 10; ++j)
                    {
                        arrayMarks[i * 10 + j] = marks[i, j];
                    }
                }
                return arrayMarks;
            }
            set
            {
                for (int i = 0; i < 2; ++i)
                {
                    for (int j = 0; j < 10; ++j)
                    {
                        marks[i, j] = value[i * 10 + j];
                    }
                }
            }
        }

        [ProtoBuf.ProtoMember(2)]
        public int Misses
        {
            get => misses;
            set => misses = value;
        }

        [ProtoBuf.ProtoMember(3)]
        public decimal AverageMark
        {
            get => averageMark;
            set
            {
                if (!isCalculateAverage)
                {
                    averageMark = value;
                }
            }

        }

        public Student() : base()
        {

        }

        public Student(string surname, string name, int age, int[,] marks, int misses) : base(surname, name, age)
        {
            maxID++;
            ID = maxID;
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    this.marks[i, j] = marks[i, j];
                }
            }
            CalculateAverageMark();
            IsBadStudent();
            this.misses = misses;
        }




        protected void CalculateAverageMark()
        {
            decimal sum = 0;

            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    sum += marks[i, j];
                }
            }

            averageMark = sum / 20;
            isCalculateAverage = true;
        }

        public override string ToString()
        {
            return $"Студент:{surname} {name}. Возраст:{age}, ID:{ID}, Средний балл:{averageMark}, Количество пропусков:{misses}";
        }


    }
}
