using PrimeGearApp.Web.ViewModels.ShoppingCartViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IUserCartSerivce
    {
        Task<IEnumerable<ShoppingCartItemViewModel>> GetUserShoppingCartItems(string userId);
        Task<bool> AddProductToShoppingCartByIdAsync(int id, string? userId);
        Task<bool> UpdateCartItemQuantity(string id, int quantity);
        Task RemoveCartItemById(int id);
    }
}
