using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.EntityValidationConstants.ProductTypePropertyConstants;

namespace PrimeGearApp.Data.Configuration
{
    public class ProductTypePropertiesConfiguration : IEntityTypeConfiguration<ProductTypeProperty>
    {
        public void Configure(EntityTypeBuilder<ProductTypeProperty> builder)
        {
            builder
                .HasKey(ptp => ptp.Id);
                        
            builder
                .HasOne(ptp => ptp.ProductType)
                .WithMany(pt => pt.ProductProperties)
                .HasForeignKey(ptp => ptp.ProductTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder .HasOne(ptp => ptp.ValueType)
                .WithMany(pvt => pvt.ProductTypes)
                .HasForeignKey(ptp => ptp.ValueTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(ptp => ptp.ProductTypePropertyName)
                .IsRequired()
                .HasComment("Property Name")
                .HasMaxLength(ProductTypePropertyNameMaxLength);

            builder
                .Property(ptp => ptp.ProductTypePropertyUnitOfMeasurement)
                .HasComment("Property's unit of measurement")
                .HasMaxLength(ProductTypePropertyUnitMaxLength);
        }
    }
}