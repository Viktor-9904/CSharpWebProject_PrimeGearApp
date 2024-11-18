namespace PrimeGearApp.Data.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int ProductTypePropertyId { get; set; }
        public ProductTypeProperty ProductTypeProperty { get; set; } = null!;
        public string ProductTypePropertyValue { get; set; } = null!;
    }
}
