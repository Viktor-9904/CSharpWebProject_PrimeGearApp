using System.ComponentModel.DataAnnotations;

using static PrimeGearApp.Common.EntityValidationConstants.ShoppingCartItem;
using static PrimeGearApp.Common.EntityValidationErrorMessages.ShoppingCartItemErrorMessages;

namespace PrimeGearApp.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Range(ShoppingCartItemQuantityMin, ShoppingCartItemQuantityMax, ErrorMessage = ShoppingCartItemQuantityOutOfRange)]
        public int Quantity { get; set; }
        public bool IsSelected { get; set; }
        public decimal ProductPrice { get; set; }
    }
}