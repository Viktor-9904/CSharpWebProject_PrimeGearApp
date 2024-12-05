namespace PrimeGearApp.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public decimal TotalAmount { get; set; } 
    }
}
