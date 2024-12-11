using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
using PrimeGearApp.Web.ViewModels.Orders;

namespace PrimeGearApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
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
    }
}
