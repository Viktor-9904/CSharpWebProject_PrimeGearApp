using PrimeGearApp.Web.ViewModels.OrdersViewModels;
using PrimeGearApp.Web.ViewModels.ShoppingCartViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IUserCartSerivce
    {
        Task<UserShoppingCartViewModel> GetUserShoppingCartItems(string userId);
        Task<bool> AddProductToShoppingCartByIdAsync(int id, string? userId);
        Task<bool> UpdateCartItemQuantity(string id, int quantity);
        Task RemoveCartItemById(int id);
        Task<CheckOutOrderViewModel> LoadCheckOutOrderViewModel(int cartId);
    }
}
