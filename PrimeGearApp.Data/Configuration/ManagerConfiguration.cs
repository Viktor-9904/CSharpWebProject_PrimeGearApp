using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.EntityValidationConstants.ManagerConstants;

namespace PrimeGearApp.Data.Configuration
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.WorkPhoneNumber)
                .IsRequired()
                .HasComment("Manager's work phone number")
                .HasMaxLength(ManagerWorkPhoneMaxLenght);

            builder
                .Property(m => m.UserId)
                .IsRequired()
                .HasComment("Manager's user Id");

            builder
                .HasOne(m => m.User)
                .WithOne()
                .HasForeignKey<Manager>(m => m.UserId);

        }
    }
}
