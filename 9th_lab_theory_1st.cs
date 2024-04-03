using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Получаем путь к рабочему столу текущего пользователя
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Создаем путь к новому файлу на рабочем столе
        string path = Path.Combine(desktopPath, "example.txt");
        string textToAdd = "Hello, world!";

        // Запись строки в файл, перезаписывая его содержимое
        File.WriteAllText(path, textToAdd);

        // Добавление строки в файл
        using (StreamWriter writer = File.AppendText(path))
        {
            writer.WriteLine("Additional line");
        }


        // Чтение всего файла в строку
        string content = File.ReadAllText(path);
        Console.WriteLine(content);

        // Построчное чтение файла
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
