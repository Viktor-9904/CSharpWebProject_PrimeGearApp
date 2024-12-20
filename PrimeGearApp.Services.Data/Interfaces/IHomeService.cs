using PrimeGearApp.Web.ViewModels.HomeViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<TopProductViewModel>> GetTopProductsAsync();
    }
}
