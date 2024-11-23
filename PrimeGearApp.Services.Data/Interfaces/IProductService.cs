using PrimeGearApp.Data.Models;
using PrimeGearApp.Web.ViewModels.ProductViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync();
        Task<ProductDetailViewModel> GetProductDetailByIdAsync(int id);
        Task<IEnumerable<ProductTypeViewModel>> GetAllProductTypesAsync();
        Task<IEnumerable<ProductTypePropertyViewModel>> GetAllProductTypePropertiesByProductTypeIdAsync(int id);
    }
}
