using System.Reflection;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.SeeingConstants.ProductTypeSeeding;
using static PrimeGearApp.Common.SeeingConstants.ProductTypeProperties.GPUProperties;

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

            modelBuilder.Entity<ProductType>()
                .HasData(SeedProductTypes());

            modelBuilder.Entity<Product>()
                .HasData(SeedProducts());

            modelBuilder.Entity<ProductTypeProperty>()
                .HasData(SeedProductTypeProperties());
        }
        private IEnumerable<ProductType> SeedProductTypes()
        {

            List<ProductType> productTypes = new List<ProductType>()
            {
                new ()
                {
                    Id = CPUId,
                    Name = "CPU"
                },
                new ()
                {
                    Id = GPUId,
                    Name = "GPU"
                },
                new ()
                {
                    Id = MotherBoardId,
                    Name = "Motherboard"
                },
                new ()
                {
                    Id = RAMId,
                    Name = "RAM"
                },
                new ()
                {
                    Id = PowerSupplyId,
                    Name = "Power Supply"
                },
                new ()
                {
                    Id = HDDId,
                    Name = "HDD"
                },
                new ()
                {
                    Id = SSDId,
                    Name = "SSD"
                },
                new ()
                {
                    Id = CoolingFanId,
                    Name = "Cooling Fan"
                },
                new ()
                {
                    Id = CPUFanCoolerId,
                    Name = "CPU Fan Cooler"
                },
                new ()
                {
                    Id = CPUAIOCoolerId,
                    Name = "CPU AIO Cooler"
                },
                new ()
                {
                    Id = PcCaseId,
                    Name = "PC Case"
                },
                new ()
                {
                    Id = MonitorId,
                    Name = "Monitor"
                },
                new ()
                {
                    Id = MonitorStandId,
                    Name = "Monitor Stand"
                },
                new ()
                {
                    Id = KeyboardId,
                    Name = "Keyboard"
                },
                new ()
                {
                    Id = MouseId,
                    Name = "Mouse"
                },
                new ()
                {
                    Id = HeadsetId,
                    Name = "Headset"
                },
                new ()
                {
                    Id = MousePadId,
                    Name = "Mouse Pad"
                }
           };

            return productTypes;
        }
        private IEnumerable<Product> SeedProducts()
        {

            List<Product> products = new List<Product>()
             {
                 new()
                 {
                     Name = "Graphics card - RTX 5090",
                     Brand = "Nvidia",
                     Description = "This is the newest and fastest GPU on the market!",
                     RelaseDate = new DateTime(2025,03,23),
                     ProductTypeId = GPUId,
                     Price = 9999.99,
                     Weigth = 1.1,
                     WarrantyDurationInMonths = 24,
                     AvaibleQuantity = 12
                 },
                 new()
                 {
                     Name = "Graphics card - GTX 1050",
                     Brand = "Nvidia",
                     Description = "An older card, still very capable of running modern games on medium setting at 1080p.",
                     RelaseDate = new DateTime(2015,03,23),
                     ProductTypeId = GPUId,
                     Price = 84.45,
                     Weigth = 0.5,
                     WarrantyDurationInMonths = 6,
                     AvaibleQuantity = 3
                 }
             };
            return products;
        }
        private IEnumerable<ProductTypeProperty> SeedProductTypeProperties()
        {

            List<ProductTypeProperty> productTypeProperties = new List<ProductTypeProperty>();
            for (int i = 1; i < GpuProperties.Count(); i++)
            {
                ProductTypeProperty productTypeProperty = new()
                {
                    Id = i,
                    ProductTypeId = GPUId,
                    ProductTypePropertyName = GpuProperties[i]
                };
                productTypeProperties.Add(productTypeProperty);
            }
                return productTypeProperties;
        }
    }
}