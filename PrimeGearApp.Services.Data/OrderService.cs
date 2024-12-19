using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.OrdersViewModels;

namespace PrimeGearApp.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, Guid> orderRepository;
        private readonly IRepository<Product, int> productRepository;
        private readonly IRepository<ShoppingCart, int> shoppingCartRepository;

        public OrderService(IRepository<Order, Guid> ordersRepository, IRepository<Product, int> productRepository, IRepository<ShoppingCart, int> shoppingCartRepository)
        {
            this.orderRepository = ordersRepository;
            this.productRepository = productRepository;
            this.shoppingCartRepository = shoppingCartRepository;
        }


        public async Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(string userId)
        {
            bool isUserIdValid = Guid.TryParse(userId, out Guid guidUserId);
            if (!isUserIdValid)
            {
                return null;
            }

            IEnumerable<Order> userOrders = await this.orderRepository
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
        public async Task<bool> AddOrder(CheckOutOrderViewModel order)
        {
            Guid.TryParse(order.UserId, out Guid guidUserId);

            foreach (CheckOutOrdersCartItemViewModel item in order.ShoppingCartItems)
            {
                Order currentOrder = new Order()
                {
                    City = order.City,
                    PurchasedQuantity = item.Quantity,
                    OrderToAddress = order.Address,
                    PlacedOn = DateTime.Now,
                    ProductId = item.ProductId,
                    TotalPrice = item.TotalPrice,
                    UserId = guidUserId,
                };
                await this.orderRepository // temp patch
                    .AddAsync(currentOrder);
            }
            await this.orderRepository.SaveChangesAsync();

            await this.shoppingCartRepository
                .DeleteAsync(order.CartId);
            await this.shoppingCartRepository
                .SaveChangesAsync();

            return true;
        }
    }
}
