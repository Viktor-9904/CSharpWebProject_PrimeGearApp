namespace PrimeGearApp.Data.Models
{
    public class PropertyValueType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ProductTypeProperty> ProductTypes { get; set; }
            = new List<ProductTypeProperty>();
    }
}
