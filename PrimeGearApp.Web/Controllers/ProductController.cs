using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
using PrimeGearApp.Web.ViewModels;
using PrimeGearApp.Web.ViewModels.ProductViewModels;

namespace PrimeGearApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IManagerService serviceManager;

        public ProductController(IProductService productService, IManagerService managerService)
        {
            this.productService = productService;
            this.serviceManager = managerService;
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
            bool isIdValid = int.TryParse(productId, out int id);
            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            ProductDetailViewModel viewModel =
                await this.productService.GetProductDetailByIdAsync(id);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create() //TODO: Add option to add a Custom(non-existing) productType 
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

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
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<ProductTypeViewModel> productTypes = await
                this.productService.GetAllProductTypesAsync();

            if (productTypes == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

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
        public async Task<IActionResult> GetCreateProductTypeFields(string? productTypeId)
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            bool isIdValid = int.TryParse(productTypeId, out int productTypeIntId);
            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            IEnumerable<ProductTypePropertyViewModel> productTypeProperties = await productService
                .GetAllProductTypePropertiesByProductTypeIdAsync(productTypeIntId);

            if (productTypeProperties == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            var model = new CreateProductViewModel // TODO: Remove dictionary
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
        public async Task<IActionResult> GetEditProductTypeFields(string? productId)
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            if (!isUserManager)
            {
                return RedirectToAction(nameof(Index));
            }

            bool isIdValid = int.TryParse(productId, out int productIntId);
            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            EditProductViewModel editViewModel = await this.productService.GetEditProductByIdAsync(productIntId);

            if (editViewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            // Return the partial view with the dynamic fields
            return PartialView("_EditProductTypePropertyFields", editViewModel);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string? id)
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            bool isIdValid = int.TryParse(id, out int intId);

            if (!ModelState.IsValid || !isUserManager || !isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            EditProductViewModel viewModel = await this.productService.GetEditProductByIdAsync(intId);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProductViewModel viewModel)
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            if (!ModelState.IsValid || !isUserManager)
            {
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> SoftDeleteConfirmed(string productId)
        {
            string? userId = this.User.GetUserId();
            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            bool isIdValid = int.TryParse(productId, out int productIntId);

            if (!isUserManager || !isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            bool isDeleted = await this.productService
                .SoftDeleteProductByIdAsync(productIntId);

            if (!isDeleted)
            {
                return RedirectToAction(nameof(Details), new { productId });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
