namespace PrimeGearApp.Data.Models
{
    public class ProductType
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
            = new List<Product>();  

        public ICollection<ProductTypeProperty> ProductProperties { get; set; }
            = new List<ProductTypeProperty>();
    }
}