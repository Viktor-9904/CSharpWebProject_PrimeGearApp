using Azure.Core.Pipeline;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Services.Data
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<Manager, int> favoriteService;
        public FavoriteService(IRepository<Manager, int> favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        public Task<bool> IsCurrentProductAddedToFavorite(int productId, string userId)
        {
            
        }
    }
}