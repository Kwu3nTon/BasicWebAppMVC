using Microsoft.AspNetCore.Mvc;
using BasicWebAppMVC.Models;
using BasicWebAppMVC.Services;

namespace BasicWebAppMVC.Controllers;

public class BooksController : Controller
{
    private readonly IBooksLibrary _booksLibrary;
    public BooksController(IBooksLibrary booksLibrary)
    {
        this._booksLibrary = booksLibrary;
    }
    public IActionResult Index()
    {
        return View(this._booksLibrary.GetAllBooks());
    }

    public IActionResult Details(int id)
    {
        return View(this._booksLibrary.GetBookById(id));
    }
}