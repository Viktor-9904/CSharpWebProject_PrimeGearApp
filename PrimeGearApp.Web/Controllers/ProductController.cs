using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels;
using PrimeGearApp.Web.ViewModels.ProductViewModels;

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
        public async Task<IActionResult> Details(string? productId)
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

            ProductDetailViewModel viewModel =
                await this.productService.GetProductDetailByIdAsync(id);

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Create() //TODO: Add option to add a Custom(non-existing) productType 
        {
            IEnumerable<ProductTypeViewModel> productTypes = await
                this.productService.GetAllProductTypesAsync();

            CreateProductViewModel viewModel = new CreateProductViewModel()
            {
                ProductTypes = productTypes
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductTypeFields(int productTypeId)
        {
            IEnumerable<ProductTypePropertyViewModel> productTypeProperties = await productService
                .GetAllProductTypePropertiesByProductTypeIdAsync(productTypeId);

            var model = new CreateProductViewModel
            {
                ProductTypeProperties = productTypeProperties,
                ProductProperties = productTypeProperties.ToDictionary(
            prop => prop.Id,
            prop => string.Empty
            )};

            // Return the partial view with the dynamic fields
            return PartialView("_ProductTypeFields", model);
        }

    }
}
