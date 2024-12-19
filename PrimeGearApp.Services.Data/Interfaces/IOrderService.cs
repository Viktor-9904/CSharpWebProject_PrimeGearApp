using PrimeGearApp.Web.ViewModels.OrdersViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(string userId);
        Task<bool> AddOrder(CheckOutOrderViewModel order);
    }
}
