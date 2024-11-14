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

            //builder
            //    .HasOne(pd => pd.Product)
            //    .WithMany(ptp => ptp.ProductDetails)
            //    .HasForeignKey(pd => pd.ProductId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasKey(pd => pd.Id);

            builder
                .HasMany(pd => pd.ProductTypeProperties)
                .WithOne(ptp => ptp.ProductDetail)
                .HasForeignKey(ptp => ptp.ProductDetailId);

            builder
                .Property(pd => pd.ProductTypePropertyValue)
                .IsRequired()
                .HasComment("ProductDetailValue")
                .HasMaxLength(ProductTypePropertyValueMaxLength);

        }
    }
}
