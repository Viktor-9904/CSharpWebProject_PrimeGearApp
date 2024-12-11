﻿using System.ComponentModel.DataAnnotations;

namespace PrimeGearApp.Web.ViewModels.Orders
{
    public class UserDetailsViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
    }
}

