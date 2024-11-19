using System.ComponentModel.DataAnnotations;

using static PrimeGearApp.Common.ApplicationConstants.ProductConstants;

namespace PrimeGearApp.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime RelaseDate { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; } = null!;

        public string? ProductImagePath { get; set; }

        [Range(ProductMinPrice, ProductMaxPrice)]
        public double Price { get; set; }

        [Range(ProductMinWeigth,ProductMaxWeigth)]
        public double Weigth { get; set; }

        [Range(ProductMinWarrantyDurationInMonths,ProductMaxWarrantyDurationInMonths)]
        public int WarrantyDurationInMonths { get; set; }

        [Range(ProductMinAvaibleQuantity,ProductMaxAvaibleQuantity)]
        public int AvaibleQuantity { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
            = new List<ProductDetail>();
    }
}
