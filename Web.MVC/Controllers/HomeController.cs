using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.MVC.Models;

namespace Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //throw new Exception("From Home controller");

            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Requested the Privacy Page");

            try
            {
                throw new Exception("Privacy Exception");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
            }

            return View();
        }

        public IActionResult ThrowError()
        {
            throw new Exception("Throw Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
