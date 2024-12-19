using PrimeGearApp.Web.ViewModels.ManagerViewModels;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IManagerService
    {
        Task<bool> IsUserManagerAsync(string? userId);
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
        Task<bool> MakeUserManagerByIdAsync(string? userId);
        Task<bool> RemoveManagerByIdAsync(string? userId);
    }
}
