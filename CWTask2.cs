using System;
public abstract class Game
{
    public abstract void StartGame(int from, int to);
}

public class GuessGame : Game
{
    private int secretNumber;
    private bool isGuessed;
    private int attemptCount;
    private int bestRecord;
    private Random random;

    public GuessGame()
    {
        random = new Random();
    }

    public override void StartGame(int from, int to)
    {
        if (from < 0 & to < 2 & to <= from)
        {
            Console.WriteLine("Неправильный диапазон чисел.");
            return;
        }

        secretNumber = random.Next(from, to);
        isGuessed = false;
        attemptCount = 0;
        bestRecord = Int32.MaxValue;

        Console.WriteLine($"Угадайте число от {from} до {to - 1}.");

        while (!isGuessed)
        {
            Console.WriteLine("Введите догадку:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int guess))
            {
                Play(guess);
                if (isGuessed)
                {
                    DisplayResults();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }
        }
    }

    private void Play(int guess)
    {
        attemptCount++;
        if (guess == secretNumber)
        {
            isGuessed = true;
            if (attemptCount < bestRecord)
            {
                bestRecord = attemptCount;
            }
        }
        else
        {
            if (guess < secretNumber)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else
            {
                Console.WriteLine("Загаданное число меньше.");
            }
        }
    }

    private void DisplayResults()
    {
        Console.WriteLine($"Загаданное число: {secretNumber}");
        Console.WriteLine($"Количество попыток: {attemptCount}");
        Console.WriteLine($"Уникальный рекорд: {bestRecord}");
    }
}

class Program
{
    static void Main (string[] args)
    {
        GuessGame game = new GuessGame();
        game.StartGame(0, 20);
    }
}