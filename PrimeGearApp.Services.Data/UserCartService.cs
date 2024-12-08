﻿using Microsoft.EntityFrameworkCore;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.ShoppingCartViewModels;

namespace PrimeGearApp.Services.Data
{
    public class UserCartService : IUserCartSerivce
    {
        public IRepository<ShoppingCart, int> shoppingCartRepository;
        public IRepository<ShoppingCartItem, int> shoppingCartItemRepository;
        public IRepository<Product, int> productRepository;

        public UserCartService(IRepository<ShoppingCart, int> shoppingCartRepository, IRepository<ShoppingCartItem, int> shoppingCartItemRepository, IRepository<Product,int> productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.shoppingCartItemRepository = shoppingCartItemRepository;
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ShoppingCartItemViewModel>> GetUserShoppingCartItems(string userId)
        {
            bool isUserIdGuid = Guid.TryParse(userId, out Guid guidId);
            if (!isUserIdGuid)
            {
                return null;
            }

            ShoppingCart userShoppingCart = await this.shoppingCartRepository
                .FirstOrDefaultAsync(sc => sc.UserId == guidId);

            if (userShoppingCart == null!)
            {
                ShoppingCart shoppingCart = new ShoppingCart()
                {
                    UserId = guidId
                };
                await shoppingCartRepository.AddAsync(shoppingCart);
                await shoppingCartItemRepository.SaveChangesAsync();
            }

            IEnumerable<ShoppingCartItem> userShoppingCartItems = await this.shoppingCartItemRepository
                .GetAllAttached()
                .Where(sci => sci.ShoppingCartId == userShoppingCart.Id)
                .ToArrayAsync();

            List<ShoppingCartItemViewModel> shoppingCartItemViewModels = new List<ShoppingCartItemViewModel>();

            foreach (var item in userShoppingCartItems)
            {
                Product product = await this.productRepository
                    .GetByIdAsync(item.ProductId);

                ShoppingCartItemViewModel cartItem = new ShoppingCartItemViewModel()
                {
                    Id = item.Id,
                    Name = product.Name,
                    ImagePath = product.ProductImagePath,
                    ProductPrice = product.Price,
                    WarrantyInMonths = product.WarrantyDurationInMonths,
                    Description = product.Description,
                    SelectedQuantity = 1, // TODO: add quantity, when adding product.
                    ProductMaxQuantity = product.AvaibleQuantity,
                };
                shoppingCartItemViewModels.Add(cartItem);
            }

            return shoppingCartItemViewModels;
        }
    }
}
