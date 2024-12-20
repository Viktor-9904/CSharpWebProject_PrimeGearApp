using Microsoft.EntityFrameworkCore;
using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.ViewModels.HomeViewModels;

namespace PrimeGearApp.Services.Data
{
    public class HomeSerivce : IHomeService
    {
        private readonly IRepository<Product, int> productRepository;

        public HomeSerivce(IRepository<Product, int> productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IEnumerable<TopProductViewModel>> GetTopProductsAsync()
        {
            IEnumerable<TopProductViewModel> topProducts = await this.productRepository
                .GetAllAttached()
                .OrderByDescending(p => p.RelaseDate)
                .Take(5)
                .Select(p => new TopProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Price = p.Price,
                    ImagePath = p.ProductImagePath,
                })
                .ToListAsync();

            return topProducts;
        }
    }
}
