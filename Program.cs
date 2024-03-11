using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_4_2_семестр
{
    internal class Program


    {
        //struct Student
        //{
        //    private int _mark;
        //    public int GetMark()
        //    {
        //        return _mark;
        //    }
        //    public void SetMark(int value)
        //    {
        //        _mark = value;
        //    }

        //    private int _miss;
        //    public int GetMiss()
        //    {
        //        return _miss;
        //    }
        //    public void SetMiss(int miss)
        //    {
        //        _miss = miss;
        //    }

        //    private string _surname;
        //    public string GetSurname()
        //    {
        //        return _surname;
        //    }
        //    public void SetSurname(string surname)
        //    {
        //        _surname = surname;
        //    }
        //}

        //struct Student
        //{
        //    private double _mark;
        //    public int Mark 
        //    {
        //        get
        //        { return _mark; }
        //        set 
        //        { _mark = value; }
        //    }  

        //}

       struct Students
        {
            public int Mark { get; private set; }
            public int Miss { get; private set; }
            public string Surname { get; private set; }

            public Students(int mark, int miss, string surname)
            {
                Mark = mark;
                Miss = miss;
                Surname = surname;
            }


            static void Main(string[] args)
            {
                Students[] student = new Students[5];
                student[0] = new Students(2, 5, "Астарион");
                student[1] = new Students(2, 10, "Карлах");
                student[2] = new Students(5, 4, "Уилл");
                student[3] = new Students(4, 0, "Шэдоухарт");
                student[4] = new Students(3, 12, "Гитьянки");

                Students mis;
                Console.WriteLine("Список студентов:");
                Console.WriteLine();

                for (int i = 0; i < student.Length; i++)
                {
                    Console.WriteLine("Оценка: {0}\t Пропуски: {1}  Фамилия: {2}", student[i].Mark, student[i].Miss, student[i].Surname);
                }

                Console.WriteLine();

                for (int i =0; i<student.Length; i++)
                {
                    for (int j = 1; j < student.Length; j++)
                    {
                        if (student[j-1].Miss < student[j].Miss)
                        {
                            mis = student[j - 1];
                            student[j - 1] = student[j]; 
                            student[j] = mis;
                        }
                    }
                }//0=10
                 // 1=5;4;12;0
                 // j=2 i=0; j=3;;j=4
                 //i=1; j=1; j=2; j=3 10;5;12;4;0; j=4
                 //и т.д.
                Console.WriteLine("Список студентов по убыванию пропусков:");
                Console.WriteLine();
                for (int i = 0; i < student.Length; i++)
                {
                    Console.WriteLine("Оценка: {0}\t Пропуски: {1}  Фамилия: {2}", student[i].Mark, student[i].Miss, student[i].Surname);
                }
                Console.WriteLine();

                Console.WriteLine("Список студентов по убыванию пропусков с оценкой 2:");
                Console.WriteLine();
                for (int i=0; i<student.Length; i++)
                {
                    if (student[i].Mark == 2)
                    {
                        Console.WriteLine("Оценка: {0}\t Пропуски: {1}  Фамилия: {2}", student[i].Mark, student[i].Miss, student[i].Surname);
                    }
                }
                
                Console.ReadKey();
            }
        }
    }
}