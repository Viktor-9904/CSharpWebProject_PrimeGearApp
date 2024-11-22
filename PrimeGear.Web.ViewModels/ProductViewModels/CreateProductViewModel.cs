using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;
using static PrimeGearApp.Common.EntityValidationErrorMessages.ProductErrorMessages;

namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        [MinLength(ProductNameMinLength, ErrorMessage = NameIsTooShort)]
        [MaxLength(ProductNameMaxLength, ErrorMessage = NameIsTooLong)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ProductBrandMinLength, ErrorMessage = BrandIsTooShort)]
        [MaxLength(ProductBrandMaxLength, ErrorMessage = BrandIsTooLong)]
        public string Brand { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range((double)ProductMinPrice, (double)ProductMaxPrice, ErrorMessage = PriceNotInRange)] // TODO: Implement custom attribute for too low or too high
        public decimal Price { get; set; }

        [Range(ProductMinWarrantyDurationInMonths, ProductMaxWarrantyDurationInMonths, ErrorMessage = WarrantyNotInRange)]
        public int WarrantyDurationInMonths { get; set; }

        [Range(ProductMinAvaibleQuantity, ProductMaxAvaibleQuantity, ErrorMessage = QuantityNotInRange)]
        public int AvaibleQuantity { get; set; }

        public IFormFile? ProductImagePath { get; set; }

    }
}
