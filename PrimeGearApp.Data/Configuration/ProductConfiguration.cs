using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.ApplicationConstants.ProductConstants;

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
                .HasComment("Product Price");
            // Price Range as data annotation

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
                .HasData(this.SeedProducts());
        }
        private IEnumerable<Product> SeedProducts()
        {

            List<Product> products = new List<Product>()
             {
                 new()
                 {
                     Name = "Graphics card - RTX 5090",
                     Brand = "Nvidia",
                     Description = "This is the newest and fastest GPU on the market!",
                     RelaseDate = new DateTime(2025,03,23),
                     ProductTypeId = Guid.Parse("5FD048EA-EA0D-4D23-B505-4F2321485398"),
                     Price = 9999.99,
                     Weigth = 1.1,
                     WarrantyDurationInMonths = 24,
                     AvaibleQuantity = 12
                 },
                 new()
                 {
                     Name = "Graphics card - GTX 1050",
                     Brand = "Nvidia",
                     Description = "An older card, still very capable of running modern games on medium setting at 1080p.",
                     RelaseDate = new DateTime(2015,03,23),
                     ProductTypeId = Guid.Parse("5FD048EA-EA0D-4D23-B505-4F2321485398"),
                     Price = 84.45,
                     Weigth = 0.5,
                     WarrantyDurationInMonths = 6,
                     AvaibleQuantity = 3
                 }
             };
            return products;
        }
    }
}
