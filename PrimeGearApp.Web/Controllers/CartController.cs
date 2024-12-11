using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
using PrimeGearApp.Web.ViewModels.Orders;
using PrimeGearApp.Web.ViewModels.ShoppingCartViewModels;

namespace PrimeGearApp.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IUserCartSerivce userCartSerivce;
        public CartController(IUserCartSerivce userCartSerivce)
        {
            this.userCartSerivce = userCartSerivce;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            string? userId = this.User.GetUserId();

            UserShoppingCartViewModel shoppingCartItems = await this.userCartSerivce
                .GetUserShoppingCartItems(userId!);

            return View(shoppingCartItems);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(int productId)
        {
            string? userId = this.User.GetUserId();

            bool wasProductAddedToCart = await this.userCartSerivce
                .AddProductToShoppingCartByIdAsync(productId, userId);

            if (!wasProductAddedToCart)
            {
                return Json(new { success = false, message = "Failed to add the product to the cart." });
            }

            return Json(new { success = true, message = "Product added to the cart successfully." });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateQuantity(string id, int quantity)
        {
            bool result = await this.userCartSerivce.UpdateCartItemQuantity(id, quantity); // Update the item in the database

            if (result)
            {
                TempData["Success"] = "Cart updated successfully.";
            }
            else
            {
                TempData["Error"] = "Failed to update the cart.";
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await this.userCartSerivce
                .RemoveCartItemById(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CheckOut(int cartId)
        {
            CheckOutOrderViewModel viewModel = await this.userCartSerivce
                .LoadCheckOutOrderViewModel(cartId);

            if (viewModel == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
         }
    }
}