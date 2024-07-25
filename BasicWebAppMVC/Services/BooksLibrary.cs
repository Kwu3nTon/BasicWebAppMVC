using BasicWebAppMVC.Models;

namespace BasicWebAppMVC.Services;

public class BooksLibrary: IBooksLibrary
{
    private List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
        new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
    };
    public List<Book> GetAllBooks()
    {
        return this._books;
    }

    public Book GetBookById(int id)
    {
        Book book = this._books.Find(book => book.Id == id);
        if (book == null)
        {
            Book newBook = new Book { Id = id, Title = $"Book {id}", Author = $"Author {id}" };
            this._books.Add(newBook);
            return newBook;
        }
        return book;
    }
}