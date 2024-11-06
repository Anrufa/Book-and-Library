using System;
using System.Collections.Generic;

namespace LibraryApp
{
    // Класс Book
    public class Book
    {
        // Свойства
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Pages { get; private set; }

        public Book(string title, string author, int pages)
        {
            Title = title;
            Author = author;
            Pages = pages;
        }

        public string GetInfo()
        {
            return $"Название: {Title}, Автор: {Author}, Страниц: {Pages}";
        }
    }

    public class Library
    {
        private Dictionary<string, Book> books;

        public Library()
        {
            books = new Dictionary<string, Book>(StringComparer.OrdinalIgnoreCase); // Игнорируем регистр
        }

        public void AddBook(Book book)
        {
            if (!books.ContainsKey(book.Title))
            {
                books[book.Title] = book;
                Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
            }
            else
            {
                Console.WriteLine($"Книга '{book.Title}' уже существует в библиотеке.");
            }
        }

        public void ShowBooks()
        {
            Console.WriteLine("Список книг в библиотеке:");
            if (books.Count == 0)
            {
                Console.WriteLine("В библиотеке нет книг.");
            }
            else
            {
                foreach (var book in books.Values)
                {
                    Console.WriteLine(book.GetInfo());
                }
            }
        }

        public Book FindBook(string title)
        {
            books.TryGetValue(title, out Book foundBook);
            return foundBook;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Гарри Поттер и философский камень", "Джоан Роулинг", 223);
            Book book2 = new Book("Убить пересмешника", "Харпер Ли", 281);
            Book book3 = new Book("1984", "Джордж Оруэлл", 328);

            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Console.WriteLine();
            library.ShowBooks();

            Console.WriteLine("\nВведите название книги для поиска:");
            string titleToFind = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(titleToFind))
            {
                Console.WriteLine("Ошибка: Пустой ввод. Попробуйте еще раз.");
                return;
            }

            Book foundBook = library.FindBook(titleToFind);

            if (foundBook != null)
            {
                Console.WriteLine($"Книга найдена: {foundBook.GetInfo()}");
            }
            else
            {
                Console.WriteLine("Книга не найдена.");
            }
        }
    }
}

