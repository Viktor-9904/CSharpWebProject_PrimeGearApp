using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Web.Models;
using System.Diagnostics;

namespace PrimeGearApp.Web.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            // TODO: Add other pages
            if (!statusCode.HasValue)
            {
                return this.View();
            }

            switch (statusCode) // TODO: Add more custom error messeages
            {
                case 404:
                    return this.View("Error404");

                default:
                    return this.View("Error500");
            }
        }
    }
}
