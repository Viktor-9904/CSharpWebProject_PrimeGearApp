namespace PrimeGearApp.Data.Models
{
    public class ProductTypeProperty
    {
        public Guid Guid { get; set; } 
            = Guid.NewGuid();
        public Guid ProductTypeId { get; set; }
        public string ProductProperty { get; set; } = null!;
    }
}
