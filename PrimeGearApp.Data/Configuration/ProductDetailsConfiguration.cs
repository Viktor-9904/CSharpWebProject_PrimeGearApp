using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.ApplicationConstants.ProductDetailsConstants;

namespace PrimeGearApp.Data.Configuration
{
    public class ProductDetailsConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder
                .HasKey(pd => pd.Id);

            builder
                .HasOne(pd => pd.Product)
                .WithMany(ptp => ptp.ProductDetails)
                .HasForeignKey(pd => pd.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pd => pd.ProductTypeProperty)
                .WithMany(ptp => ptp.ProductDetails)
                .HasForeignKey(pd => pd.ProductTypePropertyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(pd => pd.ProductTypePropertyValue)
                .IsRequired()
                .HasComment("ProductDetailValue")
                .HasMaxLength(ProductTypePropertyValueMaxLength);

        }
    }
}
