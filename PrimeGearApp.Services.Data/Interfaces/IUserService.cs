using PrimeGearApp.Data.Models;

namespace PrimeGearApp.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserById(Guid id);
    }
}
