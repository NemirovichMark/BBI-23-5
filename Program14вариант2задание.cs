
using System;

abstract class Game
{
    protected int _TargetNumber;
    protected bool _isGuessed;
    protected int _popitka;
    protected int _record;

    public abstract void StartGame(int min, int max);
}

class GuessGame : Game
{
    public bool IsGuessed => _isGuessed;

    public GuessGame(int targetNumber)
    {
        _TargetNumber = targetNumber;
        _isGuessed = false;
        _popitka = 0;
        _record = Int32.MaxValue;
    }

    public override void StartGame(int min, int max)
    {
        if (max - min < 2 || min < 0 || max < 0)
        {
            Console.WriteLine("Неверно задан диапазон чисел.");
            return;
        }

        if (min >= 0 && max >= 0)
        {
            Random random = new Random();
            _TargetNumber = random.Next(min, max + 1);
            _isGuessed = false;
            _popitka = 0;
            _record = Int32.MaxValue;

            Console.WriteLine("Загадано число от {0} до {1}.", min, max);
        }

    }

    public void GuessNumber(int number)
    {
        _popitka++;

        if (number == _TargetNumber)
        {
            _isGuessed = true;
            if (_popitka < _record)
            {
                _record = _popitka;
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
        Console.WriteLine("Вы угадали число.\nЗагаданное число: {0}\nКоличество попыток: {1}\nРекорд: {2}", _TargetNumber, _popitka, _record);
    }
}

class Program
{
    static void Main()
    {
        GuessGame game = new GuessGame(0); 

        game.StartGame(0, 10);

        while (!game.IsGuessed)
        {
            Console.Write("Введите ваше предположение: ");

            if (int.TryParse(Console.ReadLine(), out int userGuess) && userGuess > 0)
            {
                game.GuessNumber(userGuess);
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
            }
        }

        game.Print();
    }
}