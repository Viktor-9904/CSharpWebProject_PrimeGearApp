using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrimeGearApp.Data.Models;
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
        [Authorize]
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
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            IEnumerable<ProductTypeViewModel> productTypes = await
                this.productService.GetAllProductTypesAsync();


            if (!ModelState.IsValid) //TODO: fix displaying the viewmodel after invalid input
            {
                viewModel.ProductTypes = productTypes;
                return View(viewModel);
            }
            if (!await this.productService.AddProductAsync(viewModel))
            {
                viewModel.ProductTypes = productTypes;
                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCreateProductTypeFields(int productTypeId)
        {
            IEnumerable<ProductTypePropertyViewModel> productTypeProperties = await productService
                .GetAllProductTypePropertiesByProductTypeIdAsync(productTypeId);

            var model = new CreateProductViewModel
            {
                ProductTypeProperties = productTypeProperties,
                ProductProperties = productTypeProperties.ToDictionary(
            prop => prop.Id,
            prop => string.Empty
            )
            };

            // Return the partial view with the dynamic fields
            return PartialView("_CreateProductTypePropertyFields", model);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEditProductTypeFields(int productTypeId, int productId)
        {
            EditProductViewModel editViewModel = await this.productService.GetEditProductByIdAsync(productId);

            // Return the partial view with the dynamic fields
            return PartialView("_EditProductTypePropertyFields", editViewModel);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<ProductTypeViewModel> productTypes = await
                this.productService.GetAllProductTypesAsync();

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            EditProductViewModel viewModel = await this.productService.GetEditProductByIdAsync(id);

            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction(nameof(Index));
            }

            bool isUpdated = await this.productService
                .UpdateEditedProductAsync(viewModel);

            if (!isUpdated)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occured while updating the product.");
                return View(viewModel);
            }

            return RedirectToAction(nameof(Details), new { productId = viewModel.ProductId });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SoftDeleteConfirmed(int productId)
        {
            bool result = await this.productService
                .SoftDeleteProductByIdAsync(productId);

            if (!result)
            {
                return RedirectToAction(nameof(Details), new { productId });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
