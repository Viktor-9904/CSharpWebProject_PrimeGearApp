namespace PrimeGearApp.Web.ViewModels.Orders
{
    public class CheckOutOrdersCartItemViewModel
    {
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice => Quantity * PricePerUnit;
    }
}
