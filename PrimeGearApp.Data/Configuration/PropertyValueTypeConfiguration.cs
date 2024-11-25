using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.EntityValidationConstants.PropertyValueTypeConstants;

namespace PrimeGearApp.Data.Configuration
{
    public class PropertyValueTypeConfiguration : IEntityTypeConfiguration<PropertyValueType>
    {
        public void Configure(EntityTypeBuilder<PropertyValueType> builder)
        {
            builder
                .HasKey(pvt => pvt.Id);

            builder
                .Property(pvt => pvt.Name)
                .IsRequired()
                .HasComment("Value name")
                .HasMaxLength(PropertyValueTypeNameMaxLength);
        }
    }
}
