using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public IRepository<ProductType, int> productTypeRepository;

        public UserCartService(
            IRepository<ShoppingCart, int> shoppingCartRepository,
            IRepository<ShoppingCartItem, int> shoppingCartItemRepository,
            IRepository<Product, int> productRepository,
            IRepository<ProductType, int> productTypeRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.shoppingCartItemRepository = shoppingCartItemRepository;
            this.productRepository = productRepository;
            this.productTypeRepository = productTypeRepository;
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

            if (userShoppingCart == null)   // Add shopping cart to user, if he doesnt have one
            {
                userShoppingCart = new ShoppingCart()
                {
                    UserId = guidId
                };

                await shoppingCartRepository.AddAsync(userShoppingCart);
                await shoppingCartRepository.SaveChangesAsync();
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

                ProductType productTypeName = await this.productTypeRepository
                    .GetByIdAsync(product.ProductTypeId);
                

                ShoppingCartItemViewModel cartItem = new ShoppingCartItemViewModel()
                {
                    Id = item.Id,
                    Type = productTypeName.Name,
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
        public async Task<bool> AddProductToShoppingCartByIdAsync(int id, string? userId)
        {
            Product? product = await this.productRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(p => p.Id == id);

            bool isUserIdGuid = Guid.TryParse(userId, out Guid guidId);

            if (!isUserIdGuid || product == null)
            {
                return false;
            }

            ShoppingCart userShoppingCart = await this.shoppingCartRepository
                .FirstOrDefaultAsync(sc => sc.UserId == guidId);


            if (userShoppingCart == null)   // Add shopping cart to user, if he doesnt have one
            {
                userShoppingCart = new ShoppingCart()
                {
                    UserId = guidId
                };
                await shoppingCartRepository.AddAsync(userShoppingCart);
                await shoppingCartRepository.SaveChangesAsync();
            }

            ShoppingCartItem cartItemToAdd = new ShoppingCartItem()
            {
                ProductId = product.Id,
                Quantity = 1, // TODO: Add an input for quantity, when adding a product to cart, also validate for the max currently avaiable product
                ShoppingCartId = userShoppingCart.Id,
            };

            await this.shoppingCartItemRepository.AddAsync(cartItemToAdd);
            await this.shoppingCartItemRepository.SaveChangesAsync();
            return true;
        }

    }
}
