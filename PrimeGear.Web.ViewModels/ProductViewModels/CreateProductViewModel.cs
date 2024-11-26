using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;
using static PrimeGearApp.Common.EntityValidationErrorMessages.ProductErrorMessages;

namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = NameIsRequired)]
        [MinLength(ProductNameMinLength, ErrorMessage = NameIsTooShort)]
        [MaxLength(ProductNameMaxLength, ErrorMessage = NameIsTooLong)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = BrandIsRequired)]
        [MinLength(ProductBrandMinLength, ErrorMessage = BrandIsTooShort)]
        [MaxLength(ProductBrandMaxLength, ErrorMessage = BrandIsTooLong)]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = DescriptionIsRequired)]
        [MinLength(ProductDescriptionMinLength, ErrorMessage = DescriptionIsTooShort)]
        [MaxLength(ProductDescriptionMaxLength, ErrorMessage = DescriptionIsTooLong)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ReleaseDateIsRequired)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = PriceIsRequired)]
        [Range((double)ProductMinPrice, (double)ProductMaxPrice, ErrorMessage = PriceNotInRange)] // TODO: Implement custom attribute for too low or too high
        public decimal Price { get; set; }

        [Required(ErrorMessage = PriceIsRequired)]
        [Range(ProductMinWarrantyDurationInMonths, ProductMaxWarrantyDurationInMonths, ErrorMessage = WarrantyNotInRange)]
        public int WarrantyDurationInMonths { get; set; }

        [Required(ErrorMessage = QuantityIsRequired)]
        [Range(ProductMinAvaibleQuantity, ProductMaxAvaibleQuantity, ErrorMessage = QuantityNotInRange)]
        public int AvaibleQuantity { get; set; }

        [Required(ErrorMessage = WeigthIsRequired)]
        [Range(ProductMinWeigth, ProductMaxWeigth, ErrorMessage = WeigthNotInRange)]
        public double Weigth { get; set; }

        public IFormFile? ProductImagePath { get; set; }

        [Required(ErrorMessage = ProductTypeSelectionRequired)]
        public int SelectedProductTypeId { get; set; } // For dropdown selection

        public IEnumerable<ProductTypeViewModel> ProductTypes { get; set; } 
            = new List<ProductTypeViewModel>();

        public IEnumerable<ProductTypePropertyViewModel> ProductTypeProperties { get; set; } 
            = new List<ProductTypePropertyViewModel>();

        [Required]
        public Dictionary<int, string> ProductProperties { get; set; }
            = new Dictionary<int, string>();      
    }
}
