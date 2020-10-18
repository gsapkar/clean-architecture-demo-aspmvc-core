using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            BookListViewModel model = _bookService.GetBooks();

            return View(model);
        }

        public IActionResult AddOrEdit(Guid id)
        {
           if (id == Guid.Empty)
            {
                return View();
            }

            var editBookViewmodel = _bookService.GetBookById(id);

            return View(editBookViewmodel);
           
        }

        [HttpPost]
        public IActionResult AddOrEdit(BookViewModel bookViewModel)
        {
            if (bookViewModel.Id == Guid.Empty)
            {
                _bookService.AddBook(bookViewModel);
                
            }
            else
            {
                _bookService.EditBook(bookViewModel);

            }

            return RedirectToAction("Index");

        }
    }
}
