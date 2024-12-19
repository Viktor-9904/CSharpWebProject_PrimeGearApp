namespace PrimeGearApp.Web.ViewModels.OrdersViewModels
{
    public class CheckOutOrdersCartItemViewModel
    {
        public string ProductName { get; set; } = null!;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice => Quantity * PricePerUnit;
    }
}
