using System;

struct GuessGame
{
    private int _targetNumber;
    private bool _isGuessed;
    private int _attempts;
    private int _record;

    public GuessGame(int targetNumber)
    {
        _targetNumber = targetNumber;
        _isGuessed = false;
        _attempts = 0;
        _record = Int32.MaxValue;
    }

    public void Play()
    {
        Console.WriteLine("Игра началась! Угадайте число от 0 до 10.");

        while (!_isGuessed)
        {
            Console.Write("Введите ваше предположение: ");
            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                _attempts++;

                if (guess == _targetNumber)
                {
                    Console.WriteLine("Поздравляем! Вы угадали число!");
                    _isGuessed = true;
                    if (_attempts < _record)
                    {
                        _record = _attempts;
                        Console.WriteLine($"Новый рекорд: {_record} попыток!");
                    }
                }
                else
                {
                    Console.WriteLine(guess < _targetNumber ? "Загаданное число больше." : "Загаданное число меньше.");
                }
            }
            else
            {
                Console.WriteLine("Введите корректное целое число от 0 до 10.");
            }
        }

        Console.WriteLine($"Загаданное число: {_targetNumber}");
        Console.WriteLine($"Количество попыток: {_attempts}");
        Console.WriteLine($"Рекорд: {_record}");
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        int targetNumber = random.Next(0, 11);

        GuessGame game = new GuessGame(targetNumber);
        game.Play();
    }
}