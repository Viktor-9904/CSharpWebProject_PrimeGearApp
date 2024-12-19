using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Infrastructure.Extensions;
using PrimeGearApp.Web.ViewModels.ManagerViewModels;

namespace PrimeGearApp.Web.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService serviceManager;

        public ManagerController(IManagerService managerService)
        {
            this.serviceManager = managerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            string? userId = this.User.GetUserId();

            bool isUserManager = await this.serviceManager
                .IsUserManagerAsync(userId);

            if (!isUserManager)
            {
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<UserViewModel> users = await this.serviceManager
                .GetAllUsersAsync();

            return View(users);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MakeUserManager(string? userId)
        {
            string? currentUserId = this.User.GetUserId();

            bool isCurrentUserManager = await this.serviceManager
                .IsUserManagerAsync(currentUserId);

            if (!isCurrentUserManager)
            {
                return RedirectToAction("Index", "Home");
            }

            bool wasUserMadeManager = await this.serviceManager
                .MakeUserManagerByIdAsync(userId);

            if (wasUserMadeManager)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveManager(string? userId)
        {

            string? currentUserId = this.User.GetUserId();

            bool isCurrentUserManager = await this.serviceManager
                .IsUserManagerAsync(currentUserId);

            if (!isCurrentUserManager)
            {
                return RedirectToAction("Index", "Home");
            }

            bool wasManagerRemoved = await this.serviceManager
                .RemoveManagerByIdAsync(userId);

            if (wasManagerRemoved)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
