using System;
using System.Linq;

namespace BookLibrary
{
    
    abstract class Book : IComparable<Book>
    {
        public string Title;   
        public int ISBN;      
        public string Author;  
        public int Year;       
        public double Price;   

       
        public abstract double CalculatePrice();

       
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"| {Title,-30} | {ISBN,-10} | {Author,-20} | {Year,-10} | {Price,-10} |");
        }

       
        public int CompareTo(Book other)
        {
            return other.Price.CompareTo(Price);
        }
    }

    
    class PaperBook : Book
    {
        public bool Hardcover;

       
        public override double CalculatePrice()
        {
            return Price;
        }
    }

   
    class ElectronicBook : Book
    {
        public string Format; 

       
        public override double CalculatePrice()
        {
            return Price * 0.7; 
    }

   
    class AudioBook : Book
    {
        public bool StudioRecording; 
       
        public override double CalculatePrice()
        {
            return Price * 1.5; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            PaperBook[] paperBooks = new PaperBook[5];
            ElectronicBook[] electronicBooks = new ElectronicBook[5];
            AudioBook[] audioBooks = new AudioBook[5];

          
            for (int i = 0; i < 5; i++)
            {
                paperBooks[i] = new PaperBook { Title = $"Бумажная книга {i + 1}", ISBN = 1000 + i, Author = "Автор бумажной книги", Year = 2000 + i, Price = 10.0 + i, Hardcover = true };
                electronicBooks[i] = new ElectronicBook { Title = $"Электронная книга {i + 1}", ISBN = 2000 + i, Author = "Автор электронной книги", Year = 2010 + i, Price = 15.0 + i, Format = "pdf" };
                audioBooks[i] = new AudioBook { Title = $"Аудиокнига {i + 1}", ISBN = 3000 + i, Author = "Автор аудиокниги", Year = 2020 + i, Price = 20.0 + i, StudioRecording = true };
            }

          
            