using System.ComponentModel.DataAnnotations;

namespace PrimeGearApp.Web.ViewModels.ProductViewModels
{
    public class ProductTypeDropDownListViewModel
    {
        [Required]
        public int ProductTypeId { get; set; }
        [Required]
        public string ProductTypeName { get; set; } = null!;
    }
}
