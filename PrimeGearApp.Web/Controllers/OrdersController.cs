using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PrimeGearApp.Web.Controllers
{
    public class OrdersController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
