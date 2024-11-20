using PrimeGearApp.Web.ViewModels.ProductViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync();
        Task<ProductDetailViewModel> GetProductDetailByIdAsync(int id);
    }
}
