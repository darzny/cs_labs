using System;

namespace BooksStorage
{
    public class Book : IComparable
    {
        private string author;
        private string title;
        private int year;
        private int pages;

        public void SetBook(string author, string title, int pages, int year)
        {
            this.author = author;
            this.title = title;
            this.pages = pages;
            this.year = year;
        }

        public void Show()
        {
            Console.WriteLine("\nКнига:\n Автор: {0}\n Название: {1}\n Год издания: {2}\n {3} стр.\n", author, title, year, pages);
        }

        int IComparable.CompareTo(object obj)
        {
            Book otherBook = obj as Book;

            if (otherBook != null)
            {
                return this.year.CompareTo(otherBook.year);
            }

            throw new ArgumentException("Object is not a Book");
            
        }
    }

    class Program
    {
        static void Main1(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book(),
                new Book(),
            };

            books[0].SetBook("Автор1", "Название1", 100, 2000);
            books[1].SetBook("Автор2", "Название2", 150, 1990);

            Array.Sort(books);

            foreach (Book book in books)
            {
                book.Show();
            }
        }
    }
}
