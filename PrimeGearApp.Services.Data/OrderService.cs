using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.Orders;

namespace PrimeGearApp.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, Guid> ordersRepository;
        private readonly IRepository<Product, int> productRepository;

        public OrderService(IRepository<Order, Guid> ordersRepository, IRepository<Product, int> productRepository)
        {
            this.ordersRepository = ordersRepository;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(string userId)
        {
            bool isUserIdValid = Guid.TryParse(userId, out Guid guidUserId);
            if (!isUserIdValid)
            {
                return null;
            }

            IEnumerable<Order> userOrders = await this.ordersRepository
                .GetAllAttached()
                .Where(o => o.UserId == guidUserId)
                .OrderBy(o => o.PlacedOn)
                .ToListAsync();

            List<OrderViewModel> orderedItems = new List<OrderViewModel>();

            if (userOrders.Any())
            {
                foreach (var order in userOrders)
                {
                    Product orderedProduct = await this.productRepository
                        .GetByIdAsync(order.ProductId);
                    if (orderedProduct == null)
                    {
                        continue;
                    }
                    OrderViewModel orderViewModel = new OrderViewModel()
                    {
                        ProductName = orderedProduct.Name,
                        PlacedOn = order.PlacedOn,
                        TotalPrice = order.TotalPrice,
                        OrderedQuantity = order.PurchasedQuantity,
                        City = order.City,
                        OrderToAddress = order.OrderToAddress
                    };
                    orderedItems.Add(orderViewModel);
                }
            }
            return orderedItems;
        }
    }
}
