using PrimeGearApp.Web.ViewModels.Orders;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(string userId);
        Task<bool> AddOrder(CheckOutOrderViewModel order);
    }
}
