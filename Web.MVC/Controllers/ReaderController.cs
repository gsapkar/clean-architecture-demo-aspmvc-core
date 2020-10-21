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
        private readonly SessionContext _sessionContext;

        public ReaderController(IReaderService readerService, SessionContext sessionContext)
        {
            _readerService = readerService;
            _sessionContext = sessionContext;
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
    }
}
