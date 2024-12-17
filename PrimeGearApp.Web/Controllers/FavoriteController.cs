using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Services.Data.Interfaces;

namespace PrimeGearApp.Web.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IProductService productService;

        public FavoriteController(IProductService productService, IManagerService managerService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddToFavorites(string? id)
        {
            
            return View("TestingView");
        }
    }
}
