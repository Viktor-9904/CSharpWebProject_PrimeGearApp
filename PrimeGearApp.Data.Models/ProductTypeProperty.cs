namespace PrimeGearApp.Data.Models
{
    public class ProductTypeProperty
    {
        public int Id { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;

        public string ProductTypePropertyName { get; set; } = null!;
        public  ICollection<ProductDetail> ProductDetails { get; set; } 
            = new List<ProductDetail>();
    }
}
