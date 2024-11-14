namespace PrimeGearApp.Data.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
           = Guid.NewGuid();

        public Guid ProductId { get; set; }

        public Guid ProductTypeProperityId { get; set; }
        public ICollection<ProductTypeProperty> ProductTypeProperties { get; set; }
            = new List<ProductTypeProperty>();

        public string ProductTypePropertyValue { get; set; } = null!;
    }
}
