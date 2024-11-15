using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PrimeGearApp.Data.Models;
using System.Reflection;

namespace PrimeGearApp.Web.Data
{
    public class PrimeGearDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PrimeGearDbContext()
        {
            
        }

        public PrimeGearDbContext(DbContextOptions<PrimeGearDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<ProductTypeProperty> ProductTypeProperties { get; set; } = null!;
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
