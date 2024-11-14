namespace PrimeGearApp.Data.Models
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
           = Guid.NewGuid();

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid ProductTypePropertyId { get; set; } // DONT REMOVE !!!!!!!!!!!!!!!!!!!!

        // Navigation property for the related ProductTypeProperty
        public ICollection<ProductTypeProperty> ProductTypeProperties { get; set; } = new List<ProductTypeProperty>();
        public string ProductTypePropertyValue { get; set; } = null!;
    }
}
