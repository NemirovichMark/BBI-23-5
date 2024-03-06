class Program
{
    /*
    Составить программу для обработки результатов кросса на 500 м для женщин. 
    Для каждой участницы ввести фамилию, группу, фамилию преподавателя, результат. 
    Получить результирующую таблицу, упорядоченную по результатам, в которой содержится также информация 
    о выполнении норматива. 
    Определить суммарное количество участниц, выполнивших норматив.
    */

    struct StudentCrossData 
    {
        private string surname;
        private string group;
        private string mentorSurname;
        public double deltaTime { get; }
        public const int require_second = 180; //статическая конст
        public static int cnt;

        public StudentCrossData(string _surname, string _group, string _mentorSurname, double _deltaTime)
        {
            surname = _surname;
            group = _group;
            mentorSurname = _mentorSurname;
            deltaTime = _deltaTime;
            if (deltaTime < require_second)
            {
                cnt++;
            }
        }

        public void Print()
        {
            Console.WriteLine("Teacher {2, -10}: {1, 3} group, {0, -10} | {3}m {4, 2:f0}s", surname, group, mentorSurname, Math.Floor(deltaTime / 60), 60 * (deltaTime / 60 - Math.Floor(deltaTime / 60)));
        }
    }

    static void Sort(StudentCrossData[] data, int n) //измененная сортировку гномией
    {
        int i = 0, j = 1;
        while (i < n)
        {
            if (i == 0 || data[i].deltaTime >= data[i - 1].deltaTime)
            {
                i = j;
                j++;
            }
            else
            {
                StudentCrossData temp = data[i];
                data[i] = data[i - 1];
                data[i - 1] = temp;
                i--;
            }
        }
    }

    static void Main(string[] args)
    {
        int N = 10;

        Random rand = new Random();
        StudentCrossData[] data = new StudentCrossData[N];
        string[] surnames =
        {
            "Ivanova",
            "Petrova",
            "Rudenko",
            "Klochay",
            "Vasnecova",
            "Kan",
            "Romanova",
            "Smolina",
            "Darmograi",
        };
        string[] groups =
        {
            "IU",
            "IBM",
            "SGN",
            "MT",
            "SM",
        };
        for (int i = 0; i < N; i++)
        {
            int surnameIndex = rand.Next(surnames.Length);
            int groupsIndex = rand.Next(groups.Length);
            int surnameTeacherIndex = rand.Next(surnames.Length);
            double deltaTime = (150 + rand.Next(50));
            StudentCrossData student_data = new StudentCrossData(surnames[surnameIndex], groups[groupsIndex], surnames[surnameTeacherIndex], deltaTime);
            data[i] = student_data;
        }

        Sort(data, N);
        bool flag = true;
        int cnt = 0;
        Console.WriteLine("Passed standard\n------------");
        foreach (StudentCrossData student in data)
        {
            if (flag && student.deltaTime > StudentCrossData.require_second)
            {
                Console.WriteLine("\nNot passed standard\n------------");
                flag = false;
            }
            
            student.Print();
        }
        Console.WriteLine("\nTotal passed: {0}", StudentCrossData.cnt);
    }
}

