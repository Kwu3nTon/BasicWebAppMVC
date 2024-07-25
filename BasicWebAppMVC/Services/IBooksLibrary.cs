using BasicWebAppMVC.Models;

namespace BasicWebAppMVC.Services;

public interface IBooksLibrary
{
    public List<Book> GetAllBooks();
    public Book GetBookById(int id);
}