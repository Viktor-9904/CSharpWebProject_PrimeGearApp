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
        Task<bool> AddProductAsync(CreateProductViewModel viewModel);
        Task<EditProductViewModel> GetEditProductByIdAsync(int id);
        Task<bool> UpdateEditedProductAsync(EditProductViewModel viewModel, string ProductTypePropertiesJson);
        Task<IEnumerable<ProductTypeDropDownListViewModel>> LoadAllProductTypesDropDownList();
        Task<bool> SoftDeleteProductByIdAsync(int id);
    }
}
