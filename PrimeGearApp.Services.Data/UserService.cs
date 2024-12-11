using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data.Interfaces;

namespace PrimeGearApp.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser, Guid> userRepository;

        public UserService(IRepository<ApplicationUser, Guid> userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<ApplicationUser> GetUserById(Guid id)
        {
            ApplicationUser user = await this.userRepository
                    .GetByIdAsync(id);

            return user;
        }
    }
}
