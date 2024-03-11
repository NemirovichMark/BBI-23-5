using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_5_2_семестр
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chess[] chess = new Chess[5];
            chess[0] = new Chess("Грэм", 0.5, 1, 0);
            chess[1] = new Chess("Анкунин", 1, 1, 0.5);
            chess[2] = new Chess("Артон", 0, 0.5, 0.5);
            chess[3] = new Chess("Минхо", 0.5, 1, 1);
            chess[4] = new Chess("Лэнгдон", 1, 1, 1);

            Console.WriteLine("Турнир по шахматам. Список участников.");
            Console.WriteLine();
            Console.WriteLine("Фамилия Партия 1 Партия 2 Партия 3");
            for (int i = 0; i < chess.Length; i++)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t", chess[i].Surname, chess[i].Game1, chess[i].Game2, chess[i].Game3);
            }
            Console.WriteLine();
            Console.WriteLine("Фамилия Сумма баллов");
            Result[] result = new Result[chess.Length];
            for (int i = 0; i < chess.Length; i++)
            {
                double c = chess[i].Game1 + chess[i].Game2 + chess[i].Game3;
                result[i] = new Result(chess[i].Surname, c);
                Console.WriteLine("{0}\t {1}", result[i].Surname, result[i].Game123);
            }
            Console.WriteLine();
            Result temp;
            for (int i = 0; i < chess.Length; i++)
            {
                for (int j = 1; j < chess.Length; j++)
                {
                    if (result[j - 1].Game123 < result[j].Game123)
                    {
                        temp = result[j - 1];
                        result[j - 1] = result[j];
                        result[j] = temp;
                    }

                }
            }
            Console.WriteLine("Турнир по шахматам. Список участников по убыванию суммы баллов.");
            for (int i = 0; i < chess.Length; i++)
            {
                Console.WriteLine("{0}\t {1}", result[i].Surname, result[i].Game123);
            }
            Console.ReadKey();
        }
    }
}
