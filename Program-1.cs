using System;

struct Student // создаем структуру с полями "оценка" и "количество пропусков"
{
    private string surname;
    private int mark;
    private int misses;
    public Student(string surname, int mark, int misses) // конструктор структуры 
    {
        this.surname = surname;
        this.mark = mark;
        this.misses = misses;
    }
    public int Mark { get { return mark; } } // публичный геттер для получения значения поля "оценка" вне структуры
    public int Misses { get { return misses; } } // такой же геттер для количества пропусков
    public void Print() // метод для вывода информации
    {
        Console.WriteLine(surname + ", пропусков: " + misses);
    }
}
class Program
{
    struct Team
    {
        private string name;
        private int score;
        private int diff;
        public string Name { get { return name; } }
        public int Score { get { return score; } set { score = value; } }
        public int Difference { get { return diff; } set { diff = value; } }

        public Team(string name)
        {
            this.name = name;
            score = 0;
            diff = 0;
        }
        public void Print()
        {
            Console.WriteLine(name + ", очков: " + score);
        }
        public void Win(int difference)
        {
            score += 3;
            diff += difference;
        }
        public void Lose(int difference)
        {
            diff -= difference;
        }
        public void Draw()
        {
            score += 1;
        }
    }

    struct Player
    {
        private string surname;
        private double score;
        public string Surname { get { return surname; } }
        public double Score { get { return score; } }
        public Player(string surname)
        {
            this.surname = surname;
            score = 0;
        }
        public void Print()
        {
            Console.WriteLine(surname + " " + score);
        }
        public void Win()
        {
            score += 1;
        }
        public void Draw()
        {
            score += 0.5;
        }
    }

    static void Main(string[] args)
    {
        #region 1
        //Console.WriteLine("Введите количество студентов:");
        //int n = int.Parse(Console.ReadLine());
        //Student[] students = new Student[n]; // создание массива из n переменных типа Student
        //Console.WriteLine();
        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine("Фамилия:");
        //    string surname = Console.ReadLine();
        //    Console.WriteLine("Оценка:");
        //    int mark = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Количество пропущенных занятий:");
        //    int misses = int.Parse(Console.ReadLine());
        //    students[i] = new Student(surname, mark, misses); // вызов конструктора для заполнения полей каждого элемента
        //    Console.WriteLine();
        //}
        //// сортировка массива студентов по количеству пропусков
        //for (int i = 0; i < n; i++) 
        //{
        //    for (int j = 0; j < n - 1; j++)
        //    {
        //        if (students[j].Misses < students[j + 1].Misses)
        //        {
        //            Student t = students[j];
        //            students[j] = students[j + 1];
        //            students[j + 1] = t;
        //        }
        //    }
        //}
        //Console.WriteLine();
        //Console.WriteLine("Неуспевающие студенты:");
        //for (int i = 0; i < n; i++)
        //{
        //    if (students[i].Mark == 2)
        //    {
        //        students[i].Print();
        //    }
        //}
        #endregion

        #region 2
        //Console.WriteLine("Введите количество участников:");
        //int n = int.Parse(Console.ReadLine());
        //Random random = new Random();
        //Player[] players = new Player[n];
        //for (int i = 0; i < n; i++)
        //{
        //    players[i] = new Player("Player " + (i + 1));
        //}

        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = i + 1; j < n; j++)
        //    {
        //        int result = random.Next(1, 4);
        //        Console.WriteLine(players[i].Surname + " - " + players[j].Surname);
        //        if (result == 1)
        //        {
        //            Console.WriteLine("Победитель - " + players[i].Surname);
        //            players[i].Win();
        //        }
        //        if (result == 2)
        //        {
        //            Console.WriteLine("Победитель - " + players[j].Surname);
        //            players[j].Win();
        //        }
        //        if (result == 3)
        //        {
        //            Console.WriteLine("Ничья");
        //            players[i].Draw();
        //            players[j].Draw();
        //        }
        //        Console.WriteLine();
        //    }
        //}
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n - 1; j++)
        //    {
        //        if (players[j].Score < players[j + 1].Score)
        //        {
        //            Player t = players[j];
        //            players[j] = players[j + 1];
        //            players[j + 1] = t;
        //        }
        //    }
        //}
        //Console.WriteLine();
        //for (int i = 0; i < n; i++)
        //{
        //    players[i].Print();
        //}
        #endregion

        #region 3
        //Console.WriteLine("Введите количество команд:");
        //int n = int.Parse(Console.ReadLine());
        //Random random = new Random();
        //Team[] teams = new Team[n];
        //for (int i = 0; i < n; i++)
        //{
        //    teams[i] = new Team("Team " + (i + 1));
        //}

        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = i + 1; j < n; j++)
        //    {
        //        int score_i = random.Next(0, 10);
        //        int score_j = random.Next(0, 10);
        //        Console.WriteLine(teams[i].Name + " - " + teams[j].Name + " " + score_i + ":" + score_j);
        //        int diff = Math.Abs(score_i - score_j);
        //        if (score_i > score_j)
        //        {
        //            teams[i].Win(diff);
        //            teams[j].Lose(diff);
        //        }
        //        if (score_i < score_j)
        //        {
        //            teams[j].Win(diff);
        //            teams[i].Lose(diff);
        //        }
        //        if (score_i == score_j)
        //        {
        //            teams[i].Draw();
        //            teams[j].Draw();
        //        }
        //    }
        //}
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n - 1; j++)
        //    {
        //        if ((teams[j].Score < teams[j + 1].Score) || (teams[j].Score == teams[j + 1].Score && teams[j].Difference < teams[j + 1].Difference))
        //        {
        //            Team t = teams[j];
        //            teams[j] = teams[j + 1];
        //            teams[j + 1] = t;
        //        }
        //    }
        //}
        //Console.WriteLine();
        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine((i + 1) + " место:");
        //    teams[i].Print();
        //}
        #endregion
        Console.ReadKey();
    }
}

