using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._6
{
    struct Antw_rat
    {
        public string antw;
        public double rating;
    }

    abstract class Strana
    {
        protected string _nameCountry;
        private string _frage;
        private string[] _antwort;
        public Antw_rat[] antwort_rating;
        private int _num_rats;

        public  Strana(string nC,string s1, string[] antw)
        {
            _nameCountry = nC;
            _frage = s1;
            _antwort = antw;
        }
        public void PrintData()
        {
            Console.WriteLine("Вопрос: {0} {1}?", _frage,_nameCountry);
            for (int i = 0; i < _antwort.Length; i++)
            {
                Console.WriteLine($"{_antwort[i],-20}");

            }
        }
        public void PrintRating()
        {
            Antw_rat[] antwort_rating = new Antw_rat[40];
            int _num_rats = 1;
            for (int i = 0; i < _antwort.Length; i++)
                antwort_rating[i] = new Antw_rat();
            antwort_rating[0].antw = _antwort[0];
            antwort_rating[0].rating = 0;
            bool fnd;
            for (int i = 1; i < _antwort.Length; i++)     //отбор уникальных значений
            {
                fnd = false;
                for (int j = 0; j < _num_rats; j++)
                {
                    if (_antwort[i] == antwort_rating[j].antw)
                    {
                        fnd = true;
                        break;
                    }

                }
                if (!fnd)
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
            for (int i = 0; i < _num_rats - 1; i++)     //сортировка
            {
                imax = i;
                for (int j = i + 1; j < _num_rats; j++)
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
                Console.WriteLine("{0,6:f2} %", antwort_rating[i].rating * 100 / _antwort.Length);

            }
            Console.WriteLine("===========================");
        }

    }
    class Russia : Strana
    {

        new private const string _nameCountry = "Россия";

        public Russia(string s1, string[] len) : base(_nameCountry, s1, len)
        {


        }

    }
    class Japan : Strana
    {
       new private const string _nameCountry = "Япония";
        public Japan(string s1, string[] len) : base(_nameCountry, s1, len)
        {
        }
    }
    class  CommonL: Strana
    {

        new private const string _nameCountry = "Россия + Япония";

        public CommonL(string s1, string[] len) : base(_nameCountry, s1, len)
        {
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            String[,] dataY = new string[20, 3]
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
            String[,] dataR = new string[20, 3]
                    {{ "медведь","находчивость","водка" },
                    { "заяц","смелость","самовар" },
                    { "лиса","щедрость","матрешка" },
                    { "бобр","находчивость","ушанка" },
                    { "бобр","находчивость","зима" },
                    { "медведь","находчивость","матрешка" },
                    { "орел","смелость","ушанка" },
                    { "медведь","","матрешка" },
                    { "олень","находчивость","зима" },
                    { "медведь","смелость","матрешка" },
                    { "медведь","","катана" },
                    { "олень","смелость","" },
                    { "медведь","отвага","водка" },
                    { "фазан","отвага","зима" },
                    { "олень","вежливость","водка" },
                    { "бобр","","" },
                    { "медведь","щедрость","матрешка" },
                    { "заяц","трудолюбие","самовар" },
                    { "заяц","честность","матрешка" },
                    { "лиса","отвага","самовар" }
                    };

            string[] masOtvY = new string[20];
            for (int i = 0; i < masOtvY.Length; i++)
                masOtvY[i] = dataY[i, 0];

            Japan vopr1Y = new Japan("Какое животное вы связываете со страной ", masOtvY);
            vopr1Y.PrintData();
            vopr1Y.PrintRating();

            string[] masOtvR = new string[20];
            for (int i = 0; i < masOtvR.Length; i++)
                masOtvR[i] = dataR[i, 0];

            Russia vopr1R = new Russia("Какое животное вы связываете со страной ", masOtvR);
            vopr1R.PrintData();
            vopr1R.PrintRating();
            string[] masOtvC = new string[40];
            CommonArray(masOtvY, masOtvR, masOtvC);


            CommonL vopr1C = new CommonL("Какое животное вы связываете со страной ", masOtvC);
            vopr1C.PrintData();
            vopr1C.PrintRating();

            for (int i = 0; i < masOtvY.Length; i++)
                masOtvY[i] = dataY[i, 1];

            Japan vopr2Y = new Japan("Какая черта характера присуща больше всего жителям страны ", masOtvY);
            vopr2Y.PrintData();
            vopr2Y.PrintRating();

            for (int i = 0; i < masOtvR.Length; i++)
                masOtvR[i] = dataR[i, 1];

            Russia vopr2R = new Russia("Какая черта характера присуща больше всего жителям страны ", masOtvR);
            vopr2R.PrintData();
            vopr2R.PrintRating();

            CommonArray(masOtvY, masOtvR, masOtvC);
            CommonL vopr2C = new CommonL("Какая черта характера присуща больше всего жителям страны ", masOtvC);
            vopr2C.PrintData();
            vopr2C.PrintRating();

            for (int i = 0; i < masOtvY.Length; i++)
            masOtvY[i] = dataY[i, 2];

            Japan vopr3Y = new Japan("Какой неодушевленный предмет или понятия вы связываете со страной ", masOtvY);
            vopr3Y.PrintData();
            vopr3Y.PrintRating();

            for (int i = 0; i < masOtvR.Length; i++)
                masOtvR[i] = dataR[i, 2];

            Russia vopr3R = new Russia("Какой неодушевленный предмет или понятия вы связываете со страной ", masOtvR);
            vopr3R.PrintData();
            vopr3R.PrintRating();

            CommonArray(masOtvY, masOtvR, masOtvC);
            CommonL vopr3C = new CommonL("Какой неодушевленный предмет или понятия вы связываете со страной ", masOtvC);
            vopr3C.PrintData();
            vopr3C.PrintRating();
        } 
        static void CommonArray(string[] mas1, string[] mas2,string[] masCommon)
        {
            for (int i = 0; i<mas1.Length; i++)
                masCommon[i] = mas1[i];
            int n = mas1.Length;
            for (int i = n; i<n+ mas2.Length; i++)
                masCommon[i] = mas2[i - n];
        }
    }
   
         
}

