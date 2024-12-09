using System.Reflection;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PrimeGearApp.Data.Models;
using static PrimeGearApp.Common.SeeingConstants.ProductTypeSeeding;
using static PrimeGearApp.Common.SeeingConstants.ProductTypeProperties.GPUProperties;
using System.Net.NetworkInformation;

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
        public virtual DbSet<PropertyValueType> PropertyValueTypes { get; set; } = null!;
        public virtual DbSet<Manager> Managers{ get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts{ get; set; } = null!;
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

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

            modelBuilder.Entity<ProductDetail>()
                .HasData(SeedProductDetails());

            modelBuilder.Entity<PropertyValueType>()
                .HasData(SeedPropertyValueTypes());
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
                    Id = 1,
                    Name = "Graphics card - RTX 5090",
                    Brand = "Nvidia",
                    Description = "This is the newest and fastest GPU on the market!",
                    RelaseDate = new DateTime(2025,03,23),
                    ProductTypeId = GPUId,
                    Price = 9999.99m,
                    Weigth = 2186d,
                    WarrantyDurationInMonths = 24,
                    AvaibleQuantity = 12,
                    ProductImagePath = "/images/GPU/GPU1.jpg"

                 },
                 new()
                 {
                    Id = 2,
                    Name = "Graphics card - GTX 1050",
                    Brand = "Nvidia",
                    Description = "An older card, still very capable of running modern games on medium setting at 1080p.",
                    RelaseDate = new DateTime(2015,03,23),
                    ProductTypeId = GPUId,
                    Price = 84.45m,
                    Weigth = 400d,
                    WarrantyDurationInMonths = 6,
                    AvaibleQuantity = 3,
                    ProductImagePath = "/images/GPU/GPU2.jpg"
                 }
             };
            return products;
        }
        private IEnumerable<ProductTypeProperty> SeedProductTypeProperties()
        {

            List<ProductTypeProperty> productTypeProperties = new List<ProductTypeProperty>();
            for (int i = 1; i <= GpuProperties.Count; i++)
            {
                ProductTypeProperty productTypeProperty = new()
                {
                    Id = i,
                    ProductTypeId = GPUId,
                    ProductTypePropertyName = GpuProperties[i - 1], //TODO: UpdateSeeder to seed units of measurement.
                    ValueTypeId = 1
                };
                productTypeProperties.Add(productTypeProperty);
            }
            return productTypeProperties;
        }
        private IEnumerable<ProductDetail> SeedProductDetails()
        {
            List<ProductDetail> productDetails = new List<ProductDetail>()
            {
                new()
                {
                    Id = 1,
                    ProductId = 1,
                    ProductTypePropertyId = 1,
                    ProductTypePropertyValue = "1440"
                },
                new()
                {
                    Id = 2,
                    ProductId = 1,
                    ProductTypePropertyId = 2,
                    ProductTypePropertyValue = "1860"
                },
                new()
                {
                    Id = 3,
                    ProductId = 1,
                    ProductTypePropertyId = 3,
                    ProductTypePropertyValue = "3584"
                },
                new()
                {
                    Id = 4,
                    ProductId = 1,
                    ProductTypePropertyId = 4,
                    ProductTypePropertyValue = "8"
                },
                new()
                {
                    Id = 5,
                    ProductId = 1,
                    ProductTypePropertyId = 5,
                    ProductTypePropertyValue = "GDDR6"
                },
                new()
                {
                    Id = 6,
                    ProductId = 1,
                    ProductTypePropertyId = 6,
                    ProductTypePropertyValue = "220"
                },
                new()
                {
                    Id = 7,
                    ProductId = 1,
                    ProductTypePropertyId = 7,
                    ProductTypePropertyValue = "650"
                },
                new()
                {
                    Id = 8,
                    ProductId = 1,
                    ProductTypePropertyId = 8,
                    ProductTypePropertyValue = "3"
                },
                new()
                {
                    Id = 9,
                    ProductId = 1,
                    ProductTypePropertyId = 9,
                    ProductTypePropertyValue = "true"
                },
                new()
                {
                    Id = 10,
                    ProductId = 1,
                    ProductTypePropertyId = 10,
                    ProductTypePropertyValue = "Air"
                },
                new()
                {
                    Id = 11,
                    ProductId = 1,
                    ProductTypePropertyId = 11,
                    ProductTypePropertyValue = "320"
                },
                new()
                {
                    Id = 12,
                    ProductId = 1,
                    ProductTypePropertyId = 12,
                    ProductTypePropertyValue = "2.5"
                },
                new()
                {
                    Id = 13,
                    ProductId = 1,
                    ProductTypePropertyId = 13,
                    ProductTypePropertyValue = "1.5"
                },
                new()
                {
                    Id = 14,
                    ProductId = 1,
                    ProductTypePropertyId = 14,
                    ProductTypePropertyValue = "2"
                },
                new()
                {
                    Id = 15,
                    ProductId = 1,
                    ProductTypePropertyId = 15,
                    ProductTypePropertyValue = "3"
                },
                new()
                {
                    Id = 16,
                    ProductId = 1,
                    ProductTypePropertyId = 16,
                    ProductTypePropertyValue = "1"
                },
                new()
                {
                    Id = 17,
                    ProductId = 1,
                    ProductTypePropertyId = 17,
                    ProductTypePropertyValue = "0"
                },
                new()
                {
                    Id = 18,
                    ProductId = 2,
                    ProductTypePropertyId = 1,
                    ProductTypePropertyValue = "1455"
                },
                new()
                {
                    Id = 19,
                    ProductId = 2,
                    ProductTypePropertyId = 2,
                    ProductTypePropertyValue = "1620"
                },
                new()
                {
                    Id = 20,
                    ProductId = 2,
                    ProductTypePropertyId = 3,
                    ProductTypePropertyValue = "640"
                },
                new()
                {
                    Id = 21,
                    ProductId = 2,
                    ProductTypePropertyId = 4,
                    ProductTypePropertyValue = "4"
                },
                new()
                {
                    Id = 22,
                    ProductId = 2,
                    ProductTypePropertyId = 5,
                    ProductTypePropertyValue = "GDDR5"
                },
                new()
                {
                    Id = 23,
                    ProductId = 2,
                    ProductTypePropertyId = 6,
                    ProductTypePropertyValue = "75"
                },
                new()
                {
                    Id = 24,
                    ProductId = 2,
                    ProductTypePropertyId = 7,
                    ProductTypePropertyValue = "300"
                },
                new()
                {
                    Id = 25,
                    ProductId = 2,
                    ProductTypePropertyId = 8,
                    ProductTypePropertyValue = "1"
                },
                new()
                {
                    Id = 26,
                    ProductId = 2,
                    ProductTypePropertyId = 9,
                    ProductTypePropertyValue = "false"
                },
                new()
                {
                    Id = 27,
                    ProductId = 2,
                    ProductTypePropertyId = 10,
                    ProductTypePropertyValue = "Air"
                },
                new()
                {
                    Id = 28,
                    ProductId = 2,
                    ProductTypePropertyId = 11,
                    ProductTypePropertyValue = "145"
                },
                new()
                {
                    Id = 29,
                    ProductId = 2,
                    ProductTypePropertyId = 12,
                    ProductTypePropertyValue = "2"
                },
                new()
                {
                    Id = 30,
                    ProductId = 2,
                    ProductTypePropertyId = 13,
                    ProductTypePropertyValue = "0.4"
                },
                new()
                {
                    Id = 31,
                    ProductId = 2,
                    ProductTypePropertyId = 14,
                    ProductTypePropertyValue = "1"
                },
                new()
                {
                    Id = 32,
                    ProductId = 2,
                    ProductTypePropertyId = 15,
                    ProductTypePropertyValue = "1"
                },
                new()
                {
                    Id = 33,
                    ProductId = 2,
                    ProductTypePropertyId = 16,
                    ProductTypePropertyValue = "0"
                },
                new()
                {
                    Id = 34,
                    ProductId = 2,
                    ProductTypePropertyId = 17,
                    ProductTypePropertyValue = "0"
                }
            };

            return productDetails;
        }
        private IEnumerable<PropertyValueType> SeedPropertyValueTypes()
        {
            IEnumerable<PropertyValueType> types = new List<PropertyValueType>()
            {
                new()
                {
                    Id = 1,
                    Name = "TextValue"
                },
                new()
                {
                    Id = 2,
                    Name = "IntegerValue"
                },
                new()
                {
                    Id=3,
                    Name = "DecimalValue"
                },
                new()
                {
                    Id = 4,
                    Name="BooleanValue"
                }
            };
            return types;
        }
    }
}