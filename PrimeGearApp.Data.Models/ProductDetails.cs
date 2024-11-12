namespace PrimeGearApp.Data.Models
{
    public class ProductDetails
    {
        public Guid Id { get; set; }
           = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Guid ProductTypeProperityId { get; set; }
        public string ProductTypePropertyValue { get; set; } = null!;   
    }
}
