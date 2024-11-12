namespace PrimeGearApp.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
            = Guid.NewGuid();

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime RelaseDate { get; set; }
        public ProductType productType { get; set; } = null!;
        public decimal price { get; set; } 
        public double weigth { get; set; }
        public int WarrantyDurationInMonths { get; set; }
        public int AvaibleQuantity { get; set; }

    }
}
