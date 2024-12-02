using System.ComponentModel.DataAnnotations;

namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public class EditPropertyField
    {
        [Required]
        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; } = null!;

        [Required]
        public int PropertyId { get; set; }

        [Required]
        public string ProductTypePropertyName { get; set; } = null!;

        [Required]
        public string? ProductTypePropertyUnitOfMeasurementName { get; set; }

        [Required]
        public int ValueTypeId { get; set; }

        [Required]
        public string Value { get; set; } = null!;
    }
}
