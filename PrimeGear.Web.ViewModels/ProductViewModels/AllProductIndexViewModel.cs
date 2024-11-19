namespace PrimeGearApp.Web.ViewModels.EquipmentViewModels
{
    public class ProductIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string? ProductImagePath { get; set; }
        public string ProductPrice { get; set; } = null!;
        public string WarrantyInMonths { get; set; } = null!;
        public string AvaibleQuantity { get; set; } = null!;
    }
}
