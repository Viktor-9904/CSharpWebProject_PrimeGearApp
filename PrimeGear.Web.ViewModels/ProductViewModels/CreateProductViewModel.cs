using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

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
        public int SelectedProductTypeId { get; set; } // For dropdown selection
        public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; } 
            = new List<ProductTypeViewModel>();
        public IEnumerable<ProductTypePropertyViewModel> ProductTypeProperties { get; set; } 
            = new List<ProductTypePropertyViewModel>();

        [Required]
        public Dictionary<int, string> ProductProperties { get; set; } = new Dictionary<int, string>();

         

    }
}
