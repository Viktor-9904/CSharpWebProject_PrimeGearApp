namespace PrimeGearApp.Data.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public List<ShoppingCartItem> CartItems { get; set; }
            = new List<ShoppingCartItem>();
    }
}
