using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PrimeGearApp.Data.Models;
using System.Reflection;

namespace PrimeGearApp.Web.Data
{
    public class PrimeGearDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    // public class PrimeGearDbContext : IdentityDbContext
    {
        public PrimeGearDbContext(DbContextOptions<PrimeGearDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
