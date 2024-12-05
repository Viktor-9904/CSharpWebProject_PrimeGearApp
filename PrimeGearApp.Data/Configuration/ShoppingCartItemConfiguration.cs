﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;

namespace PrimeGearApp.Data.Configuration
{
    public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder
                .HasKey(sci => sci.Id);

            builder
                .HasOne(sci => sci.Product)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(sci => sci.ProductId);

            builder
                .Property(sci => sci.Quantity)
                .IsRequired()
                .HasComment("Desired quantity");
            // Range as data annotation

            builder
                .Property(sci => sci.IsSelected)
                .IsRequired()
                .HasComment("Is the current cart item selected")
                .HasDefaultValue(false);

            builder
                .Property(sci => sci.ProductPrice)
                .IsRequired()
                .HasColumnType(ProducPriceColumnType)
                .HasComment("Product Price");

        }
    }
}
