using PrimeGearApp.Web.ViewModels.ShoppingCartViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IUserCartSerivce
    {
        Task<IEnumerable<ShoppingCartItemViewModel>> GetUserShoppingCartItems(string userId);
    }
}
