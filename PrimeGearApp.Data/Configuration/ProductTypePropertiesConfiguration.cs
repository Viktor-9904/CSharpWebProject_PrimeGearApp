using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeGearApp.Data.Models;

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

            builder.HasOne(ptp => ptp.ProductDetail)
           .WithMany(pd => pd.ProductTypeProperties)
           .HasForeignKey(ptp => ptp.ProductDetailId);
        }
    }
}