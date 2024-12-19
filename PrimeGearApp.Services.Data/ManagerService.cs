using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using PrimeGearApp.Web.ViewModels.ManagerViewModels;

namespace PrimeGearApp.Services.Data
{
    public class ManagerService : IManagerService
    {
        private readonly IRepository<Manager, Guid> managerRepository;
        private readonly IRepository<ApplicationUser, Guid> applicationUserRepository;
        public ManagerService(IRepository<Manager, Guid> managerRepository, IRepository<ApplicationUser, Guid> applicationUserRepository)
        {
            this.managerRepository = managerRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            IEnumerable<UserViewModel> users = await this.applicationUserRepository
                .GetAllAttached()
                .Select(user => new UserViewModel
                {
                    Id = user.Id.ToString(),
                    Name = user.UserName!,
                    Email = user.Email!,
                    PhoneNumber = user.PhoneNumber!,
                    IsManager = this.managerRepository
                        .GetAllAttached()
                        .Any(m => m.UserId.ToString().ToLower() == user.Id.ToString())
                })
                .ToListAsync();

            return users;
        }

        public async Task<bool> IsUserManagerAsync(string? userId)
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

        public async Task<bool> MakeUserManagerByIdAsync(string? userId)
        {
            bool isUserIdGuid = Guid.TryParse(userId, out Guid userGuid);
            if (!isUserIdGuid)
            {
                return false;
            }

            ApplicationUser user = await this.applicationUserRepository
                .GetByIdAsync(userGuid);

            if (user == null)
            {
                return false;
            }

            Manager manager = new Manager()
            {
                UserId = user.Id,
            };

            await this.managerRepository.AddAsync(manager);
            await this.managerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveManagerByIdAsync(string? userId)
        {
            bool isUserIdGuid = Guid.TryParse(userId, out Guid userGuid);
            if (!isUserIdGuid)
            {
                return false;
            }

            Manager? manager = await this.managerRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(m => m.UserId == userGuid);

            if (manager == null)
            {
                return false;
            }

            bool wasManagerDeleted = await this.managerRepository
                .DeleteAsync(manager.Id);

            if (wasManagerDeleted)
            {
                await this.managerRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
