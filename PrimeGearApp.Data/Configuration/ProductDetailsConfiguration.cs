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
                .Property(pd => pd.ProductTypePropertyValue)
                .IsRequired()
                .HasComment("ProductDetailValue")
                .HasMaxLength(ProductTypePropertyValueMaxLength);
        }
    }
}
