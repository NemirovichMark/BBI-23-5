namespace Попытка
{

    struct OneTeam
    {
        public string _name;
        public string _sex;
        public int _wins;
        public int _draws;
        public int _loses;
        public int _balls;

        public int wins => _wins;

    }

    abstract class FootballTeam
    {

        protected static OneTeam[] _teams;



        public FootballTeam(OneTeam[] Teams)
        {
            for (int i = 0; i < Teams.Length; i++)
            {
                Teams[i]._balls = Teams[i]._wins * 3 + Teams[i]._draws * 1;
            }
            _teams = Teams;
        }

        public void Print()
        {
            Console.WriteLine("Название команды    Вид команды  Баллы   В  Н  П");
            for (int i = 0; i < _teams.Length; i++)
            {
                Console.WriteLine("{0}\t {1}\t   {2:d2}   {3:d2}  {4:d2}  {5:d2}", _teams[i]._name, _teams[i]._sex,
                    _teams[i]._balls, _teams[i]._wins, _teams[i]._draws, _teams[i]._loses);
            }


        }

        public void SortC()
        {

            for (int i = 0; i < _teams.Length - 1; i++)
            {
                int imax = i;
                for (int j = i + 1; j < _teams.Length; j++)
                {
                    if (_teams[j]._balls > _teams[imax]._balls)
                    {
                        imax = j;
                    }
                }
                OneTeam temp;
                temp = _teams[imax];
                _teams[imax] = _teams[i];
                _teams[i] = temp;
            }
        }
        public static OneTeam GetTeam(int id)
        {
            return _teams[id];
        }


    }

    class Fteam : FootballTeam
    {
        private const string _sex = "женская команда";
        public Fteam(OneTeam[] Teams) : base(Teams)
        {
            for (var i = 0; i < Teams.Length; i++)
            {
                Teams[i]._sex = _sex;
            }
        }
    }

    class MTeam : FootballTeam
    {
        private const string _sex = "мужская команда";
        public MTeam(OneTeam[] Teams) : base(Teams)
        {
            for (var i = 0; i < Teams.Length; i++)
            {
                Teams[i]._sex = _sex;
            }
        }
    }
    class AllTeam : FootballTeam
    {
        public AllTeam(OneTeam[] Teams) : base(Teams)
        {
        }
    }




    internal class Program
    {
        static void Main(string[] args)


        {
            string[,] FdataS = new string[12, 4]
            {
            { "Панды", "5", "4", "2" },
             { "Звёзды", "5", "5", "1" },
             { "Молния", "8", "1", "2" },
             { "Волки", "2", "3", "6" },
             { "Тигры", "5", "2", "4" },
             { "Ястребы", "1", "5", "5" },
             { "Драконы", "8", "3", "0" },
             { "Друзья", "0", "3", "8" },
             { "Медведи", "6", "4", "1" },
             { "Орлы", "3", "7", "1" },
             { "Котики", "6", "5", "0" },
             { "Ягуары", "3", "7", "1" }
                };
            string[,] MdataS = new string[12, 4]
           {
            { "Львы", "6", "4", "1" },
             { "Буря", "4", "5", "2" },
             { "Ветер", "7", "2", "2" },
             { "Лисы", "2", "3", "6" },
             { "Банда", "5", "2", "4" },
             { "Ночь", "8", "0", "3" },
             { "Воля", "6", "3", "2" },
             { "Сокол", "9", "0", "2" },
             { "Стужа", "8", "3", "0" },
             { "Шторм", "10", "0", "1" },
             { "Комета", "0", "5", "6" },
             { "Феникс", "2", "1", "8" }
               };

            OneTeam[] Fdata = new OneTeam[12];

            SetOneTeam(FdataS, Fdata);
            Fteam fteams = new Fteam(Fdata);
            fteams.SortC();
            Console.WriteLine("Список женских команд ");
            Console.WriteLine();
            fteams.Print();

            OneTeam[] Mdata = new OneTeam[12];
            SetOneTeam(MdataS, Mdata);
            MTeam mteams = new MTeam(Mdata);  
            mteams.SortC();

            Console.WriteLine();
            Console.WriteLine("Список мужских команд ");
            Console.WriteLine();
            mteams.Print();


            OneTeam[] ALLdata = new OneTeam[12];
            int a, r, f;
            a = r = 0;
            for (f = 0; f < ALLdata.Length; f++)
            {
                if (a >= Fdata.Length / 2)
                {
                    ALLdata[f] = Mdata[r];
                    r++;
                }
                else if (r >= Mdata.Length / 2)
                {
                    ALLdata[f] = Fdata[a];
                    a++;
                }
                else
                            if (Fdata[a].wins > Mdata[r].wins)
                {
                    ALLdata[f] = Mdata[r];
                    r++;
                }
                else
                {
                    ALLdata[f] = Fdata[a];
                    a++;
                }
            }

            AllTeam allteams = new AllTeam(ALLdata);
            allteams.SortC();

            Console.WriteLine();
            Console.WriteLine("Список лучших команд");
            Console.WriteLine();


            allteams.Print();


        }
        static void SetOneTeam(string[,] sData, OneTeam[] teams)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                teams[i] = new OneTeam();
                teams[i]._name = sData[i, 0];
                teams[i]._wins = Convert.ToInt16(sData[i, 1]);
                teams[i]._loses = Convert.ToInt16(sData[i, 2]);
                teams[i]._draws = Convert.ToInt16(sData[i, 3]);
            }

        }
    }

}
