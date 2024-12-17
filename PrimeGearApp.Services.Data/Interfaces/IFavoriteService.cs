using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> IsCurrentProductAddedToFavorite(int productId, string userId);
    }
}
