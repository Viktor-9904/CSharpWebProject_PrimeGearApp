using Microsoft.AspNetCore.Mvc;
using PrimeGearApp.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PrimeGearApp.Web.ViewModels.Orders
{
    public class CheckOutOrderViewModel
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public int CartId { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public List<CheckOutOrdersCartItemViewModel> ShoppingCartItems { get; set; }
            =new List<CheckOutOrdersCartItemViewModel>();
    }
}

