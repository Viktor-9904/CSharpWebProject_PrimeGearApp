using PrimeGearApp.Data.Models;

namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public partial class ProductTypePropertyViewModel
    {
        public int Id { get; set; }

        public int ProductTypeId { get; set; }

        public string ProductTypePropertyName { get; set; } = null!;

        public string? ProductTypePropertyUnitOfMeasurementName { get; set; }

        public int ValueTypeId { get; set; }
    }
}
