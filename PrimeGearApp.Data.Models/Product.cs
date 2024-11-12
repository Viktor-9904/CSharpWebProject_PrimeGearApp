using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static PrimeGearApp.Common.ApplicationConstants.ProductConstants;

namespace PrimeGearApp.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; }
            = Guid.NewGuid();

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime RelaseDate { get; set; }

        public Guid ProductTypeId { get; set; }

        public ProductType ProductType { get; set; } = null!;

        [Range(ProductMinPrice, ProductMaxPrice)]
        public double Price { get; set; }

        [Range(ProductMinWeigth,ProductMaxWeigth)]
        public double Weigth { get; set; }

        [Range(ProductMinWarrantyDurationInMonths,ProductMaxWarrantyDurationInMonths)]
        public int WarrantyDurationInMonths { get; set; }

        [Range(ProductMinAvaibleQuantity,ProductMaxAvaibleQuantity)]
        public int AvaibleQuantity { get; set; }
    }
}
