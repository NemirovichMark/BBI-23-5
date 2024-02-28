using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    struct Antw_rat
    {
        public string antw;
        public double rating;
    }

    struct Opros
    {
        private string _frage;
        private string[] _antwort;
        public Antw_rat[] antwort_rating;
        private int _num_rats;

        public void Opros_(string s1, string[] antw)
        {
            _frage = s1;
            _antwort = antw;
        }
        public void PrintData()
        {
            Console.WriteLine("Вопрос: {0}", _frage);
            for (int i = 0; i < _antwort.Length; i++)
            {
                Console.WriteLine($"{_antwort[i],-20}");

            }
        }
        public void PrintRating()
        {
            Antw_rat[] antwort_rating = new Antw_rat[20];
            int _num_rats = 1;
            for (int i=0; i < _antwort.Length;i++)
                antwort_rating[i] = new Antw_rat();
            antwort_rating[0].antw = _antwort[0];
            antwort_rating[0].rating = 0;
            bool fnd;
            for (int i=1; i < _antwort.Length; i++)     //отбор уникальных значений
            {
                  fnd = false;
                for (int j=0;j < _num_rats; j++)
                {
                    if (_antwort[i] == antwort_rating[j].antw)
                    {
                        fnd = true;
                        break;
                    }

                }
                if (! fnd)
                {
                    antwort_rating[_num_rats].antw = _antwort[i];
                    antwort_rating[_num_rats].rating = 0;
                    _num_rats++;
                }
            }

            for (int i = 0; i < _antwort.Length; i++)     //составление рейтинга
            {
                for (int j = 0; j < _num_rats; j++)
                {
                    if (_antwort[i] == antwort_rating[j].antw)
                    {
                        antwort_rating[j].rating = antwort_rating[j].rating + 1;
                        break;
                    }
                }
             }

            int imax; Antw_rat max;
            for (int i = 0; i < _num_rats-1; i++)     //сортировка
            {
                imax = i; 
                for (int j = i+1; j < _num_rats; j++)
                {
                    if (antwort_rating[i].rating < antwort_rating[j].rating)
                        {
                            imax = j;
                        }
                   
                }
                max = antwort_rating[i];
                antwort_rating[i] = antwort_rating[imax];
                antwort_rating[imax] = max;
            }

            if (_num_rats > 5) { _num_rats = 5; }

            Console.WriteLine("-----------Рейтинг----------");
            for (int i = 0; i < _num_rats; i++)
            {
                Console.Write($"{antwort_rating[i].antw,-20}");
                Console.WriteLine("{0,6:f2} %", antwort_rating[i].rating*100/_antwort.Length);

            }
            Console.WriteLine("===========================");
        }
       
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String[,] data = new string[20, 3]
                    {{ "журавль","исполнительность","остров" },
                    { "тигр","исполнительность","икебана" },
                    { "фазан","миролюбие","икебана" },
                    { "фазан","миролюбие","остров" },
                    { "кошка","исполнительность","остров" },
                    { "журавль","трудолюбие","остров" },
                    { "дракон","исполнительность","остров" },
                    { "тануки","","икебана" },
                    { "тануки","трудолюбие","икебана" },
                    { "журавль","исполнительность","икебана" },
                    { "тануки","миролюбие","катана" },
                    { "тигр","исполнительность","" },
                    { "фазан","вежливость","сакура" },
                    { "фазан","вежливость","катана" },
                    { "кошка","вежливость","сакура" },
                    { "журавль","исполнительность","" },
                    { "дракон","миролюбие","сакура" },
                    { "тануки","исполнительность","саке" },
                    { "тануки","вежливость","саке" },
                    { "тануки","вежливость","катана" }
                    };
            Opros vopr1 = new Opros();
            string[] masOtv = new string[20];
            for (int i = 0; i < masOtv.Length; i++)
                masOtv[i] = data[i, 0];
         
            vopr1.Opros_("Какое животное вы связываете с Японией и японцами?", masOtv);
            vopr1.PrintData();
            vopr1.PrintRating();

            Opros vopr2 = new Opros();
            
            for (int i = 0; i < masOtv.Length; i++)
                masOtv[i] = data[i, 1];

            vopr2.Opros_("Какая черта характера присуща японцам больше всего?", masOtv);
            vopr2.PrintData();
            vopr2.PrintRating();

            Opros vopr3 = new Opros();
            for (int i = 0; i < masOtv.Length; i++)
                masOtv[i] = data[i,2 ];

            vopr3.Opros_("Какой неодушевленный предмет или понятия вы связываете с Японией?", masOtv);
            vopr3.PrintData();
            vopr3.PrintRating();
        }
    }
}
