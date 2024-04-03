using System;

class Program
{
    static void Main(string[] args)
    {
        char letterA = 'A', digitFive = '5', symbol = '@';

        int codeA = (int)letterA; // Преобразование символа в соответствующий код ASCII/Unicode
        Console.WriteLine(codeA); // Выведет 65, поскольку это код символа 'A' в ASCII и Unicode

        char charFromCode = (char)65; // Преобразование числового кода обратно в символ
        Console.WriteLine(charFromCode); // Выведет ‘A’

        for (int i = 0; i < 128; i++)
            Console.WriteLine((char)i); // Выводит символы ASCII от 0 до 127

        char ch = 'a';
        bool isDigit = char.IsDigit(ch); // false
        bool isLetter = char.IsLetter(ch); // true

        char lowerCase = 'a', upperCase = 'A';

        // Проверка на равенство, игнорируя регистр
        bool isEqualIgnoreCase = char.ToLower(lowerCase) == char.ToLower(upperCase);
        Console.WriteLine(isEqualIgnoreCase); // Выведет true

        // Преобразование символа в верхний регистр
        char upper = char.ToUpper(lowerCase);
        Console.WriteLine(upper); // Выведет 'A'


        char a = 'a';
        char z = 'z';

        // Проверка, лежит ли символ в диапазоне от 'a' до 'z'
        if (a >= 'a' && z <= 'z')
        {
            Console.WriteLine("Оба символа - строчные латинские буквы.");
        }

        // Изменение регистра с использованием арифметики символов
        char upperA = (char)(a - 32); // Преобразование в верхний регистр
        Console.WriteLine(upperA); // Выведет 'A'

        // Получение следующего символа
        char next = (char)(a + 1);
        Console.WriteLine(next); // Выведет 'b'

        // Конкатенация
        string hello = "Hello";
        string world = "World";
        string result = hello + ", " + world + "!";
        // Или с использованием String.Concat
        string concatResult = String.Concat(hello, ", ", world, "!");

        // Форматирование
        string name = "John";
        int age = 30;
        string formattedString = String.Format("My name is {0} and I am {1} years old.", name, age);
        // Использование интерполяции строк
        string interpolatedString = $"My name is {name} and I am {age} years old.";

        // Разделение строк
        string data = "apple,orange,banana";
        string[] fruits = data.Split(',');
        // fruits = ["apple", "orange", "banana"]

        // Объединение массива строк
        string[] values = { "apple", "orange", "banana" };
        string combinedString = String.Join("; ", values);
        // combinedString = "apple; orange; banana"

        // Подстроки
        string greeting = "Hello, World!";
        string subString = greeting.Substring(7, 5); // "World"

        // Замена подстрок
        string original = "Hello, World!";
        string replaced = original.Replace("World", "C#");
        // replaced = "Hello, C#!"

        // Поиск в строке
        string text = "Hello, World!";
        int indexOfWorld = text.IndexOf("World"); // Возвращает 7
        bool containsHello = text.Contains("Hello"); // Возвращает true

        // Удаление символов
        string spaced = "  Hello World!  007";
        string trimmed = spaced.Trim(new char[] { ' ', '0', '7' }); // "Hello World!"

        // Проверка на пустоту или null
        string emptyString = "";
        bool isEmpty = String.IsNullOrEmpty(emptyString); // true
        string nullString = null;
        bool isNullOrWhiteSpace = String.IsNullOrWhiteSpace(nullString); // true

        // Сравнение строк
        string str1 = "hello";
        string str2 = "HELLO";
        bool areEqualIgnoreCase = String.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        // areEqualIgnoreCase = true

        // Работа с символами в строке
        string alphabet = "abcdefg";
        char firstLetter = alphabet[0]; // 'a'

        // Преобразование строки в массив символов
        string sample = "Hello";
        char[] characters = sample.ToCharArray();
        // characters = ['H', 'e', 'l', 'l', 'o']
    }
}