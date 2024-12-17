using System.ComponentModel.DataAnnotations;

using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;

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

        public decimal Price { get; set; }

        [Range(ProductMinWeigth, ProductMaxWeigth)]
        public double Weigth { get; set; }

        [Range(ProductMinWarrantyDurationInMonths, ProductMaxWarrantyDurationInMonths)]
        public int WarrantyDurationInMonths { get; set; }

        [Range(ProductMinAvaibleQuantity, ProductMaxAvaibleQuantity)]
        public int AvaibleQuantity { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ProductDetail> ProductDetails { get; set; }
            = new List<ProductDetail>();

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
            = new List<ShoppingCartItem>();

        public List<Order> Orders { get; set; }
            = new List<Order>();

        public ICollection<UserFavoriteProduct> UserFavorites { get; set; } = new HashSet<UserFavoriteProduct>();
    }
}
