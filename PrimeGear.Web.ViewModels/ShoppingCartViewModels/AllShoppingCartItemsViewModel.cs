using PrimeGearApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Web.ViewModels.ShoppingCartViewModels
{
    public class AllShoppingCartItemsViewModel
    {
        public int Id { get; set; }
        public Guid UserID { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public List<ShoppingCartItemViewModel> CartItems { get; set; }
            = new List<ShoppingCartItemViewModel>();
    }
}
