using System;

struct GuessGame
{
    private int _TargetNumber;
    private bool _isGuessed;
    private int _attempts;
    private int _record;

    public bool IsGuessed => _isGuessed;

    public GuessGame(int targetNumber)
    {
        _TargetNumber = targetNumber;
        _isGuessed = false;
        _attempts = 0;
        _record = Int32.MaxValue;
    }

    public void GuessNumber(int number)
    {
        _attempts++;

        if (number == _TargetNumber)
        {
            _isGuessed = true;
            if (_attempts < _record)
            {
                _record = _attempts;
            }
        }
        else
        {
            if (number < _TargetNumber)
            {
                Console.WriteLine("Загаданное число больше.");
            }
            else
            {
                Console.WriteLine("Загаданное число меньше.");
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("Вы угадали число.\nЗагаданное число: {0}\nКоличество попыток: {1}\nРекорд: {2}", _TargetNumber, _attempts, _record);
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        int targetNumber = random.Next(0, 11);
        GuessGame[] games = new GuessGame[]
        {
            new GuessGame(targetNumber)
        };

        while (!games[0].IsGuessed)
        {
            Console.Write("Введите ваше предположение: ");
            if (int.TryParse(Console.ReadLine(), out int userGuess))
            {
                games[0].GuessNumber(userGuess);
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
            }
        }

        games[0].Print();
    }
}
