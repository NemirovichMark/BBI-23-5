using System;
using System.ComponentModel.Design;

struct GuessGame
{
    private int secretNumber;
    private bool isGuessed;
    private int attemptCount;
    private int bestRecord;
    public GuessGame(int number)
    {
        secretNumber = number;
        isGuessed = false;
        attemptCount = 0;
        bestRecord = Int32.MaxValue;
    }
    public void Play(int guess)
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

    public void DisplayResults()
    {
        Console.WriteLine($"Загаданное число: {secretNumber}");
        Console.WriteLine($"Количество попыток: {attemptCount}");
        Console.WriteLine($"Уникальный рекорд: {bestRecord}");
    }
    public bool IsGuessed
    {
        get { return isGuessed; }
    }
}
    
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int secretNumber = random.Next(0, 11);

        GuessGame game = new GuessGame(secretNumber);
        Console.WriteLine("Угадайте число от 0 до 10.");

        while (!game.IsGuessed)
        {
            
            Console.WriteLine("Введите догадку:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int guess))
            {
                game.Play(guess);
                if (game.IsGuessed)
                {
                    game.DisplayResults();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }
        }
    }
}