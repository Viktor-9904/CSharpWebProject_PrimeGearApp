using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;
using static PrimeGearApp.Common.EntityValidationErrorMessages.ProductErrorMessages;

namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public int ProductId { get; set; } 

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

        [Required(ErrorMessage = WarrantyIsRequired)]
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

        [Required]
        public IEnumerable<ProductTypeDropDownListViewModel> DropDownList { get; set; } 
            = new List<ProductTypeDropDownListViewModel>();

        [Required]
        public IEnumerable<EditPropertyField> ProductTypeProperties { get; set; }
            = new List<EditPropertyField>();

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public string ProductTypeName { get; set; } = null!;

        [Required]
        public Dictionary<int, string> ProductProperties { get; set; } // error messeges on view page dont display without this. temp patch 
            = new Dictionary<int, string>();

    }
}