using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace PrimeGearApp.Services.Data
{
    public class ManagerService : IManagerService
    {
        private readonly IRepository<Manager, Guid> managerRepository;
        public ManagerService(IRepository<Manager, Guid> managerRepository)
        {
            this.managerRepository = managerRepository;
        }
        public async Task<bool> IsUserManagerAsync(string userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            bool result = await this.managerRepository
                .GetAllAttached()
                .AnyAsync(m => m.UserId.ToString().ToLower() == userId);

            return result;
        }
    }
}
