using Microsoft.Extensions.Logging.Abstractions;

namespace PrimeGearApp.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
            = Guid.NewGuid();

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;

        public int ProductId {  get; set; }

        public Product Product { get; set; } = null!;

        public DateTime PlacedOn { get; set; }
            = DateTime.Now;

        public decimal TotalPrice { get; set; }

        public string City { get; set; } = null!;

        public string OrderToAddress { get; set; } = null!;
    }
}
