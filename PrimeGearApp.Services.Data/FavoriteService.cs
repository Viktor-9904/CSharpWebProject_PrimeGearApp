using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Services.Data
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IRepository<UserFavoriteProduct, int> favoriteService;
        private readonly IRepository<ApplicationUser, Guid> applicationUserService;
        private readonly IRepository<Product, int> productService;
        public FavoriteService(
            IRepository<UserFavoriteProduct, int> favoriteService,
            IRepository<ApplicationUser, Guid> applicationService,
            IRepository<Product, int> productService)
        {
            this.favoriteService = favoriteService;
            this.applicationUserService = applicationService;
            this.productService = productService;
        }
        public async Task<bool> AddProductToFavoritesAsync(string productId, string userId)
        {
            bool isUserIdGuid = Guid.TryParse(userId, out Guid guidUserId);
            bool isProductIdValid = int.TryParse(productId, out int productIntId);

            if (!isUserIdGuid || !isProductIdValid)
            {
                return false;
            }

            ApplicationUser user = await this.applicationUserService
                .GetByIdAsync(guidUserId);

            Product product = await this.productService
                .GetByIdAsync(productIntId);

            if (user == null || product == null)
            {
                return false;
            }

            UserFavoriteProduct userFavoriteProduct = new UserFavoriteProduct()
            {
                UserId = guidUserId,
                ProductId = productIntId
            };

            await this.favoriteService
                .AddAsync(userFavoriteProduct);

            await this.favoriteService
                .SaveChangesAsync();

            return true;
        }


        public async Task<bool> RemoveProductFromFavoritesAsync(string productId, string userId)
        {
            bool isUserIdValid = Guid.TryParse(userId, out Guid guidUserId);
            bool isProductIdValid = int.TryParse(productId, out int productIntId);

            if (!isUserIdValid || !isProductIdValid)
            {
                return false;
            }

            ApplicationUser user = await this.applicationUserService
                .GetByIdAsync(guidUserId);

            Product product = await this.productService
                .GetByIdAsync(productIntId);

            if (user == null || product == null)
            {
                return false;
            }

            UserFavoriteProduct? userFavoriteProduct = await this.favoriteService
                .GetAllAttached()
                .FirstOrDefaultAsync(ufp => ufp.UserId == guidUserId && ufp.ProductId == productIntId);

            if (userFavoriteProduct == null)
            {
                return false;
            }

            await this.favoriteService
                .DeleteAsync(userFavoriteProduct.Id);

            await this.favoriteService
                .SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<FavoriteProductViewModel>> GetAllFavoritedProductsByUserIdAsync(string userId)
        {
            bool isUserIdValid = Guid.TryParse(userId, out Guid guidUserId);

            if (!isUserIdValid)
            {
                return new List<FavoriteProductViewModel>();
            }

            List<FavoriteProductViewModel> favoritedProducts = await this.favoriteService
            .GetAllAttached()
            .Where(ufp => ufp.UserId == guidUserId)
            .Include(p => p.Product)
            .Select(ufp => new FavoriteProductViewModel
            {
                Id = ufp.Product.Id.ToString(),
                Name = ufp.Product.Name,
                Brand = ufp.Product.Brand,
                ProductImagePath = ufp.Product.ProductImagePath,
                ProductPrice = ufp.Product.Price.ToString("C"),
            })
            .ToListAsync();


            return favoritedProducts;
        }
    }
}