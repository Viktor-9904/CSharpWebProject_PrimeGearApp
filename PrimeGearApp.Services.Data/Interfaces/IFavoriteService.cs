using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> AddProductToFavorites(string productId, string userId);
        Task<bool> RemoveProductFromFavorites(string productId, string userId);
    }
}
