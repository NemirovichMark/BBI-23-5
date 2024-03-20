
using System;

namespace BookLibrary
{
    
    struct Book
    {
        public string Title;  
        public int ISBN;      
        public string Author; 
        public int Year;     

        
        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Title}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Год издания: {Year}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Book[] library = new Book[10];

           
            library[0] = new Book { Title = "Война и мир", ISBN = 123436789, Author = "Лев Толстой", Year = 1869 };
            library[1] = new Book { Title = "Преступление и наказание", ISBN = 234563690, Author = "Фёдор Достоевский", Year = 1866 };
            library[2] = new Book { Title = "1984", ISBN = 345678901, Author = "Джордж Оруэлл", Year = 1949 };
            library[3] = new Book { Title = "Омон Ра", ISBN = 453689012, Author = "Виктор Пелевин", Year = 1991 };
            library[4] = new Book { Title = "Мастер и Маргарита", ISBN = 567450123, Author = "Михаил Булгаков", Year = 1967 };
            library[5] = new Book { Title = "Гарри Поттер и философский камень", ISBN = 678901234, Author = "Дж. К. Роулинг", Year = 1997 };
            library[6] = new Book { Title = "Великий Гэтсби", ISBN = 789012345, Author = "Фрэнсис Скотт Фицджеральд", Year = 1925 };
            library[7] = new Book { Title = "Маленький принц", ISBN = 890123456, Author = "Антуан де Сент-Экзюпери", Year = 1943 };
            library[8] = new Book { Title = "Собачие сердце", ISBN = 901134567, Author = "Михаил Булгаков", Year = 1925 };
            library[9] = new Book { Title = "Часодеи часовое сердце", ISBN = 123458980, Author = "Наталья Васильевна Щерба", Year = 2011 };

            
            Console.WriteLine("Вся библиотека:");
            foreach (Book book in library)
            {
                book.DisplayInfo();
            }

           
            Console.Write("Введите имя автора, Для получения информации о его книге: ");
            string authorName = Console.ReadLine();
            Console.WriteLine($"Книги автора {authorName}:");
            foreach (Book book in library)
            {
                if (book.Author == authorName)
                {
                    book.DisplayInfo();
                }
            }

          
            Console.Write("Введите век, чтобы получить информацию о книгах: ");
            int century = int.Parse(Console.ReadLine());
            Console.WriteLine($"Книги {century} века:");
            foreach (Book book in library)
            {
                if ((book.Year / 100 + 1) == century)
                {
                    book.DisplayInfo();
                }
            }
        }
    }
}