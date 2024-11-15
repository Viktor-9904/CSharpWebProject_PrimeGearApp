namespace PrimeGearApp.Data.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
           = Guid.NewGuid();

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid ProductTypePropertyId { get; set; }
        public ProductTypeProperty ProductTypeProperty { get; set; } = null!;
        public string ProductTypePropertyValue { get; set; } = null!;
    }
}
