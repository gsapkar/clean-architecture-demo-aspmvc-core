using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Reader;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.MVC.Controllers
{
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        public IActionResult Index()
        {
            ReaderListViewModel model = _readerService.GetReaders();

            return View(model);
        }

        public IActionResult AddOrEdit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View();
            }

            var readerViewModel = _readerService.GetReaderById(id);

            return View(readerViewModel);

        }

        [HttpPost]
        public IActionResult AddOrEdit(ReaderViewModel readerViewModel)
        { 
            if (readerViewModel.Id == Guid.Empty)
            {
               
                _readerService.AddReader(readerViewModel);

            }
            else
            {
               
                _readerService.EditReader(readerViewModel);

            }

            return RedirectToAction("Index");

        }

        public IActionResult SearchByFullName(string searchTerm)
        {
            ReaderListViewModel model = _readerService.SearchByFullName(searchTerm);

            return Json(model.Readers);
        }

        public IActionResult LoanBook(Guid id)
        {
            LoanBookViewModel model = _readerService.GetReaderWithLoanedBooks(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult LoanBook(Guid readerId, Guid bookId)
        {
            _readerService.LoanBook(readerId, bookId);

            LoanBookViewModel model = _readerService.GetReaderWithLoanedBooks(readerId);

            return View(model);
        }

        [HttpPost]
        public IActionResult ReturnBook(Guid readerId, Guid bookId)
        {
            _readerService.ReturnBook(readerId, bookId);

            return RedirectToAction("LoanBook", new { id = readerId});
        }
    }
}
