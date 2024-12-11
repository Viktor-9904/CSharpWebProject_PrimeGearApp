using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PrimeGearApp.Data.Migrations;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.ShoppingCartViewModels;

namespace PrimeGearApp.Services.Data
{
    public class UserCartService : IUserCartSerivce
    {
        private readonly IRepository<ShoppingCart, int> shoppingCartRepository;
        private readonly IRepository<ShoppingCartItem, int> shoppingCartItemRepository;
        private readonly IRepository<Product, int> productRepository;
        private readonly IRepository<ProductType, int> productTypeRepository;

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
                    ProductPrice = product.Price * item.Quantity,
                    WarrantyInMonths = product.WarrantyDurationInMonths,
                    Description = product.Description,
                    SelectedQuantity = item.Quantity, // TODO: add quantity, when adding product.
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
            ShoppingCartItem alreadyExistingCartItem = await this.shoppingCartItemRepository
                .FirstOrDefaultAsync(sci => sci.ProductId == product.Id);

            if (alreadyExistingCartItem != null) // update product if it already exists
            {
                alreadyExistingCartItem.Quantity += 1; // TODO: Add input when adding a product 

                bool wasProductUpdated = await this.shoppingCartItemRepository
                    .UpdateAsync(alreadyExistingCartItem);

                if (wasProductUpdated)
                {
                    await this.shoppingCartItemRepository
                        .SaveChangesAsync();

                    return true;
                }
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
        public async Task<bool> UpdateCartItemQuantity(string cartId, int productUpdatedQuantity)
        {
            var isCartIdValid = int.TryParse(cartId, out int validCartId);
            if (!isCartIdValid)
            {
                return false;
            }
            ShoppingCartItem shoppingCartItem = await this.shoppingCartItemRepository
                .GetByIdAsync(validCartId);
            if (shoppingCartItem == null)
            {
                return false;
            }

            Product product = await this.productRepository
                .GetByIdAsync(shoppingCartItem.ProductId);

            if (product == null)
            {
                return false;
            }
            if (productUpdatedQuantity <= 0 || productUpdatedQuantity > product.AvaibleQuantity)
            {
                return false;
            }
            shoppingCartItem.Quantity = productUpdatedQuantity;

            bool result = await this.shoppingCartItemRepository
                .UpdateAsync(shoppingCartItem);
            if (result)
            {
                await this.shoppingCartItemRepository.SaveChangesAsync();
            }
            return result;
        }

        public async Task RemoveCartItemById(int id)
        {
            bool wasCartItemRemoved = await this.shoppingCartItemRepository
                .DeleteAsync(id);

            if (wasCartItemRemoved)
            {
                await this.shoppingCartItemRepository
                    .SaveChangesAsync();
            }
        }
    }
}
