using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using PrimeGearApp.Data.Models;

namespace PrimeGearApp.Data.Configuration
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder
                .HasKey(sc => sc.Id);

            builder
                .HasOne(sc => sc.User)
                .WithOne(au => au.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc=> sc.UserID);

            builder
                .HasMany(sc=> sc.CartItems)
                .WithOne(sci => sci.ShoppingCart)
                .HasForeignKey(sci => sci.ShoppingCartId);
        }
    }
}
