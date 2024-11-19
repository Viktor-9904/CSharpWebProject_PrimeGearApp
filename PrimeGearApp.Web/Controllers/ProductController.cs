using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels;
using PrimeGearApp.Web.ViewModels.EquipmentViewModels;

namespace PrimeGearApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductIndexViewModel> allProducts =
                await this.productService.GetAllProductsAsync();

            return View(allProducts);
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetail(string? productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return RedirectToAction(nameof(Index));
            }
            bool isIdValid = int.TryParse(productId, out int id);
            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
