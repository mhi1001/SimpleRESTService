using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClassLibrary;

namespace SimpleRESTService.Manager
{
    public class BooksManager
    {
        private static readonly List<Book> bookList = new List<Book>()
        {
            new Book(){Author = "Pedro", Isbn = "01010101", PageNumber = 800, Title = "Nice"},
            new Book(){Author = "John", Isbn = "91919191", PageNumber = 800, Title = "IT Essentials"},
            new Book(){Author = "Jane", Isbn = "30303003", PageNumber = 800, Title = "I have no imagination"}
        };

        

        public List<Book> GetAll(string substring)
        {
            // Callers should not get a reference to the Data object, but rather get a copy
            List<Book> result = new List<Book>(bookList);
            if (substring != null)
            {
                result = result.FindAll(book =>
                    book.Title.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Book GetByIsbn(string isbn)
        {
            return bookList.Find(book => book.Isbn == isbn);
        }

        public Book Add(Book newBook)
        {
            bookList.Add(newBook);
            return newBook;
        }

        public Book Delete(string isbn)
        {
            Book book = bookList.Find(book => book.Isbn == isbn);
            if (book == null) return null;
            bookList.Remove(book);
            return book;
        }

        public Book Update(string isbn, Book update)
        {
            Book book = bookList.Find(book => book.Isbn == isbn);
            if (book == null) return null;
            book.Author = update.Author;
            book.Title = update.Title;
            book.PageNumber = update.PageNumber;
            return book;

        }

    }
}
