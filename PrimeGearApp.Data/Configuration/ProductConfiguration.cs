﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.EntityValidationConstants.ProductConstants;
using static PrimeGearApp.Common.SeeingConstants.ProductTypeSeeding;

namespace PrimeGearApp.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasComment("Product Name")
                .HasMaxLength(ProductNameMaxLength);

            builder
                .Property(p => p.Brand)
                .IsRequired()
                .HasComment("Product Brand")
                .HasMaxLength(ProductBrandMaxLength);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasComment("Product Description")
                .HasMaxLength(ProductDescriptionMaxLength);

            builder     //ForeignKey with ProductType
                .HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType(ProducPriceColumnType)
                .HasComment("Product Price");

            builder
                .Property(p => p.Weigth)
                .IsRequired()
                .HasComment("Product Weight");
            // Weight Range as data annotaion

            builder
                .Property(p => p.WarrantyDurationInMonths)
                .IsRequired()
                .HasComment("Warranty Duration in Months");
            // Warranty Duration Range as data annotation

            builder
                .Property(p => p.AvaibleQuantity)
                .IsRequired()
                .HasComment("Avaible Quantity");
            // Availability Range as data annotation

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            //builder
            //    .HasData(this.SeedProducts());
        }
    }
}
