using PrimeGearApp.Web.ViewModels.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> AddProductToFavoritesAsync(string productId, string userId);
        Task<bool> RemoveProductFromFavoritesAsync(string productId, string userId);
        Task<IEnumerable<FavoriteProductViewModel>> GetAllFavoritedProductsByUserIdAsync(string userId);
    }
}
