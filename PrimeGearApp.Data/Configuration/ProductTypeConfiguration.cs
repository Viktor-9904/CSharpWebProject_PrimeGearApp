using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.EntityValidationConstants.ProductTypeConstants;
using static PrimeGearApp.Common.SeeingConstants.ProductTypeSeeding;

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

            //builder
            //    .HasData(this.SeedProductTypes());
        }
    }
}
