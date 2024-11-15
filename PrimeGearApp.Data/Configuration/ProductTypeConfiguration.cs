using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.ApplicationConstants.ProductTypeConstants;

namespace PrimeGearApp.Data.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder
                .HasKey(pt => pt.Id);

            builder
                .Property(pt => pt.Name)
                .IsRequired()
                .HasComment("ProductType Name")
                .HasMaxLength(ProductTypeNameMaxLength);

            builder
                .HasData(this.SeedProductTypes());
        }

        private IEnumerable<ProductType> SeedProductTypes()
        {

            List<ProductType> productTypes = new List<ProductType>()
            {
                new ()
                {
                    Name = "CPU"
                },
                new ()
                {
                    Name = "GPU"
                },
                new ()
                {
                    Name = "Motherboard"
                },
                new ()
                {
                    Name = "RAM"
                },
                new ()
                {
                    Name = "Power Supply"
                },
                new ()
                {
                    Name = "HDD"
                },
                new ()
                {
                    Name = "SSD"
                },
                new ()
                {
                    Name = "Cooling Fan"
                },
                new ()
                {
                    Name = "CPU Fan Cooler"
                },
                new ()
                {
                    Name = "CPU AIO Cooler"
                },
                new ()
                {
                    Name = "PC Case"
                },
                new ()
                {
                    Name = "Monitor"
                },
                new ()
                {
                    Name = "Monitor Stand"
                },
                new ()
                {
                    Name = "Keyboard"
                },
                new ()
                {
                    Name = "Mouse"
                },
                new ()
                {
                    Name = "Headset"
                },
                new ()
                {
                    Name = "Mouse Pad"
                }

            };

            return productTypes;
        }
    }
}
