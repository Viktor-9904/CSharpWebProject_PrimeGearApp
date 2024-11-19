using PrimeGearApp.Web.ViewModels.EquipmentViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync();
    }
}
