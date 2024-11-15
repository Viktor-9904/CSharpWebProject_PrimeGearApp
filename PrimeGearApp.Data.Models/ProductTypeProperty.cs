namespace PrimeGearApp.Data.Models
{
    public class ProductTypeProperty
    {
        public Guid Id { get; set; }
            = Guid.NewGuid();

        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;

        public string ProductTypePropertyName { get; set; } = null!;
        public  ICollection<ProductDetail> ProductDetails { get; set; } 
            = new List<ProductDetail>();
    }
}
