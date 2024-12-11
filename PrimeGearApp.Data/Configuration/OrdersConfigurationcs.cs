using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeGearApp.Data.Models;

namespace PrimeGearApp.Data.Configuration
{
    public class OrdersConfigurationcs : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            builder
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId);

            builder
                .Property(o => o.City)
                .IsRequired()
                .HasComment("Order's city")
                .HasMaxLength(100);

            builder
                .Property(o => o.OrderToAddress)
                .IsRequired()
                .HasComment("Order's address")
                .HasMaxLength(200);

            builder
                .Property(o => o.PlacedOn)
                .IsRequired()
                .HasComment("Order created on date")
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(o => o.TotalPrice)
                .IsRequired()
                .HasComment("TotalPrice of order")
                .HasColumnType("decimal(18,2)");
        }
    }
}
