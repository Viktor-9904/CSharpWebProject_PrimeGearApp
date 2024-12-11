using System.Reflection.Emit;

namespace PrimeGearApp.Web.ViewModels.ShoppingCartViewModels
{
    public class ShoppingCartItemViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImagePath { get; set; }
        public decimal ProductPrice { get; set; }
        public int WarrantyInMonths { get; set; }
        public string Description { get; set; } = null!;
        public int SelectedQuantity { get; set; }
        public int ProductMaxQuantity { get; set; }
    }
}
