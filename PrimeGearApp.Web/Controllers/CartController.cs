using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
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

            IEnumerable<ShoppingCartItemViewModel> shoppingCartItems = await this.userCartSerivce
                .GetUserShoppingCartItems(userId!);

            return View(shoppingCartItems);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            return View("TestingView");
        }
    }
}