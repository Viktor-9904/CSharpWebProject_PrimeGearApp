namespace PrimeGearApp.Data.Models
{
    public class ProductTypeProperty
    {
        public Guid Id { get; set; }
            = Guid.NewGuid();

        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;

        // Foreign key for ProductDetail
        public Guid ProductDetailId { get; set; }

        // Navigation property to the associated ProductDetail
        public ProductDetail ProductDetail { get; set; } = null!;
        public string ProductPropertyKey { get; set; } = null!;
    }
}
