﻿namespace PrimeGearApp.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        public ShoppingCart ShoppingCart { get; set; } = null!;

        public ICollection<UserFavoriteProduct> FavoriteProducts { get; set; }
    }
}
