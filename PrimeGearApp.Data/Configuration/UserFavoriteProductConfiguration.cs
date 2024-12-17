using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeGearApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGearApp.Data.Configuration
{
    class UserFavoriteProductConfiguration : IEntityTypeConfiguration<UserFavoriteProduct>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteProduct> builder)
        {
            builder
                .HasKey(ufp => ufp.Id);

            builder
                .HasOne(ufp => ufp.User)
                .WithMany(au => au.FavoriteProducts)
                .HasForeignKey(ufp => ufp.UserId);

            builder
                .HasOne(ufp => ufp.Product)
                .WithMany(p => p.UserFavorites)
                .HasForeignKey(ufp => ufp.ProductId);
        }
    }
}
