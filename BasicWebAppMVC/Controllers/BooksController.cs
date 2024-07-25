using Microsoft.AspNetCore.Mvc;
using BasicWebAppMVC.Models;

namespace BasicWebAppMVC.Controllers;

public class BooksController : Controller
{
    public IActionResult Index()
    {
        var books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2" }
        };
        return View(books);
    }

    public IActionResult Details(int id)
    {
        var book = new Book { Id = id, Title = "Book " + id, Author = "Author " + id };
        return View(book);
    }
}