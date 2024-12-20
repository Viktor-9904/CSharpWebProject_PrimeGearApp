using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Models;
using PrimeGearApp.Web.ViewModels.HomeViewModels;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace PrimeGearApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IHomeService homeService)
        {
            _logger = logger;
            this.productService = productService;
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TopProductViewModel> topProducts = await this.homeService
                .GetTopProductsAsync();

            return View(topProducts);
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
