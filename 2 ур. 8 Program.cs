/*
Для формирования сборной по хоккею предварительно отобрано 30 игроков. На
основании протоколов игр составлена таблица, в которой содержится штрафное
время каждого игрока по каждой игре (2, 5 или 10 мин). Написать программу,
которая составляет список кандидатов в сборную в порядке возрастания
суммарного штрафного времени. Игрок, оштрафованный на 10 мин, из списка
кандидатов исключается.*/

struct Sportsmen
{
    public string name;
    private int _penaltytime1;
    private int _penaltytime2;
    private int _rezz;

    public int penaltytime1 => _penaltytime1;
    public int penaltytime2 => _penaltytime2;

    public int rezz => _rezz;

    public Sportsmen(string names, int q1, int q2)
    {

        name = names;
        _penaltytime1 = q1;
        _penaltytime2 = q2;
        _rezz = _penaltytime1 + _penaltytime2;

    }

}

internal class Program
{
    static void Main(string[] args)
    {
        Sportsmen[] sportsmens = new Sportsmen[30];
        sportsmens[0] = new Sportsmen("Катя", 2, 5);
        sportsmens[1] = new Sportsmen("Инга", 5, 5);
        sportsmens[2] = new Sportsmen("Маша", 10, 10);
        sportsmens[3] = new Sportsmen("Вадим", 5, 10);
        sportsmens[4] = new Sportsmen("Саша", 2, 10);
        sportsmens[5] = new Sportsmen("Лёша", 5, 2);
        sportsmens[6] = new Sportsmen("Вова", 10, 2);
        sportsmens[7] = new Sportsmen("Влад", 10, 10);
        sportsmens[8] = new Sportsmen("Серёжа", 2, 2);
        sportsmens[9] = new Sportsmen("Яна", 5, 2);
        sportsmens[10] = new Sportsmen("Петя", 2, 10);
        sportsmens[11] = new Sportsmen("Аня", 10, 2);
        sportsmens[12] = new Sportsmen("Игорь", 10, 5);
        sportsmens[13] = new Sportsmen("Богдан", 5, 5);
        sportsmens[14] = new Sportsmen("Макс", 10, 2);
        sportsmens[15] = new Sportsmen("Настя", 2, 10);
        sportsmens[16] = new Sportsmen("Варя", 5, 5);
        sportsmens[17] = new Sportsmen("Ева", 10, 10);
        sportsmens[18] = new Sportsmen("Олеся", 2, 5);
        sportsmens[19] = new Sportsmen("Люба", 10, 5);
        sportsmens[20] = new Sportsmen("Кира", 5, 5);
        sportsmens[21] = new Sportsmen("Лиза", 5, 10);
        sportsmens[22] = new Sportsmen("Влада", 10, 5);
        sportsmens[23] = new Sportsmen("Женя", 10, 10);
        sportsmens[24] = new Sportsmen("Полина", 2, 10);
        sportsmens[25] = new Sportsmen("Семён", 2, 2);
        sportsmens[26] = new Sportsmen("Витя", 5, 2);
        sportsmens[27] = new Sportsmen("Коля", 2, 10);
        sportsmens[28] = new Sportsmen("Антон", 10, 2);
        sportsmens[29] = new Sportsmen("Юра", 2, 2);


        for (int i = 0; i < sportsmens.Length - 1; i++)
        {
            double amax = sportsmens[i].rezz;
            int imax = i;
            for (int j = i + 1; j < sportsmens.Length; j++)
            {
                if (sportsmens[j].rezz < amax)
                {
                    amax = sportsmens[j].rezz;
                    imax = j;
                }
            }
            Sportsmen temp;
            temp = sportsmens[imax];
            sportsmens[imax] = sportsmens[i];
            sportsmens[i] = temp;
        }


        for (int i = 0; i < sportsmens.Length; i++)
        {
            if (sportsmens[i].penaltytime1 != 10 & sportsmens[i].penaltytime2 != 10)
                Console.WriteLine("Фамилия {0}\t  Результат  {1:f2}",
                sportsmens[i].name, sportsmens[i].rezz);
        }

    }
}