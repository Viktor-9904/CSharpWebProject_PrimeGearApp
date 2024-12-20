using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
using PrimeGearApp.Web.ViewModels.FavoritesViewModels;
using System.ComponentModel.DataAnnotations;

namespace PrimeGearApp.Web.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string? userId = this.User.GetUserId();

            IEnumerable<FavoriteProductViewModel> allFavoritedItems = await this.favoriteService
                .GetAllFavoritedProductsByUserIdAsync(userId);

            return View(allFavoritedItems);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddProductToFavorites(string id)
        {
            string? userId = this.User.GetUserId();

            bool wasProductAddedToFavorites = await this.favoriteService
                .AddProductToFavoritesAsync(id, userId);

            if (wasProductAddedToFavorites)
            {
                int.TryParse(id, out int productIntId);
                return RedirectToAction("Details","Product", new { productId = productIntId });
            }

            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveProductFromFavorites(string id)
        {
            string? userId = this.User.GetUserId();
            bool wasProductRemoveFromFavorites = await this.favoriteService
                .RemoveProductFromFavoritesAsync(id, userId);

            if (wasProductRemoveFromFavorites)
            {
                int.TryParse(id, out int productIntId);
                return RedirectToAction("Details", "Product", new { productId = productIntId });
            }

            return RedirectToAction("Index", "Product");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveProductFromFavoritesIndex(string id)
        {
            string? userId = this.User.GetUserId();
            bool wasProductRemoveFromFavorites = await this.favoriteService
                .RemoveProductFromFavoritesAsync(id, userId);

            if (wasProductRemoveFromFavorites)
            {
                int.TryParse(id, out int productIntId);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
