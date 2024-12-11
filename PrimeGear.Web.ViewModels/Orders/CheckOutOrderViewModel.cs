using PrimeGearApp.Data.Models;

namespace PrimeGearApp.Web.ViewModels.Orders
{
    public class CheckOutOrderViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public List<CheckOutOrdersCartItemViewModel> ShoppingCarts { get; set; }
            =new List<CheckOutOrdersCartItemViewModel>();
    }
}
