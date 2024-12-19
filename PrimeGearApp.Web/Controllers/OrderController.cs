using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
using PrimeGearApp.Web.ViewModels.OrdersViewModels;

namespace PrimeGearApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string? userId = this.User.GetUserId();

            IEnumerable<OrderViewModel> userOrders = await this.orderService
                .GetAllOrdersByUserIdAsync(userId!);

            return View(userOrders);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmOrder(CheckOutOrderViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("CheckOut", "Cart");
            }

            bool wasOrderAdded = await this.orderService
                .AddOrder(viewModel);

            if (!wasOrderAdded)
            {
                return RedirectToAction("CheckOut", "Cart");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}