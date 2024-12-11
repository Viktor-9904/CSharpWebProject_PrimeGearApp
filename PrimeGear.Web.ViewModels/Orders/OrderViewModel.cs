using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Web.ViewModels.Orders
{
    public class OrderViewModel
    {
        public string Id { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int OrderedQuantity { get; set; }
        public DateTime PlacedOn { get; set; }
        public decimal TotalPrice { get; set; }
        public string City { get; set; } = null!;
        public string OrderToAddress { get; set; } = null!;
    }
}
