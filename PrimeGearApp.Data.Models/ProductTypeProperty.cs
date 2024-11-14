namespace PrimeGearApp.Data.Models
{
    public class ProductTypeProperty
    {
        public Guid Id { get; set; } 
            = Guid.NewGuid();

        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;

        public Guid ProductDetailId { get; set; }
        public ProductDetail ProductDetail { get; set; } = null!;

        public string ProductPropertyKey { get; set; } = null!;
    }
}
