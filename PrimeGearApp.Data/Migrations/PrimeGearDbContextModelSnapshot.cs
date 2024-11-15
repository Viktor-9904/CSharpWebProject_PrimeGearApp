﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimeGearApp.Web.Data;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    [DbContext(typeof(PrimeGearDbContext))]
    partial class PrimeGearDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvaibleQuantity")
                        .HasColumnType("int")
                        .HasComment("Avaible Quantity");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Product Brand");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Product Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Product Name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasComment("Product Price");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RelaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WarrantyDurationInMonths")
                        .HasColumnType("int")
                        .HasComment("Warranty Duration in Months");

                    b.Property<double>("Weigth")
                        .HasColumnType("float")
                        .HasComment("Product Weight");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac11e8e3-c4d6-4a04-9fab-b5551e29c621"),
                            AvaibleQuantity = 12,
                            Brand = "Nvidia",
                            Description = "This is the newest and fastest GPU on the market!",
                            Name = "Graphics card - RTX 5090",
                            Price = 9999.9899999999998,
                            ProductTypeId = new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"),
                            RelaseDate = new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WarrantyDurationInMonths = 24,
                            Weigth = 1.1000000000000001
                        },
                        new
                        {
                            Id = new Guid("03826e9d-f48e-412e-a3cf-57abc5be8e5e"),
                            AvaibleQuantity = 3,
                            Brand = "Nvidia",
                            Description = "An older card, still very capable of running modern games on medium setting at 1080p.",
                            Name = "Graphics card - GTX 1050",
                            Price = 84.450000000000003,
                            ProductTypeId = new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"),
                            RelaseDate = new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WarrantyDurationInMonths = 6,
                            Weigth = 0.5
                        });
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductTypePropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductTypePropertyValue")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("ProductDetailValue");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypePropertyId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("ProductType Name");

                    b.HasKey("Id");

                    b.ToTable("ProductType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d72a7a75-38c6-4b6d-ad4c-98ffe0641319"),
                            Name = "CPU"
                        },
                        new
                        {
                            Id = new Guid("32d2c505-47d3-4fef-b0cc-850f1a002c96"),
                            Name = "GPU"
                        },
                        new
                        {
                            Id = new Guid("f4a814cc-8b22-4627-82f4-424f1ec4d3e0"),
                            Name = "Motherboard"
                        },
                        new
                        {
                            Id = new Guid("3a7d1b37-c7cb-403f-8b4b-c4d422803fa4"),
                            Name = "RAM"
                        },
                        new
                        {
                            Id = new Guid("1af93b96-534e-47b5-918c-2ff532471699"),
                            Name = "Power Supply"
                        },
                        new
                        {
                            Id = new Guid("c5106725-af47-4292-8a5a-df70e4faa349"),
                            Name = "HDD"
                        },
                        new
                        {
                            Id = new Guid("8ab557cb-d3c0-4cc0-8119-e14c74cbd777"),
                            Name = "SSD"
                        },
                        new
                        {
                            Id = new Guid("1e63e063-1e39-4125-b2e7-5318e9042f09"),
                            Name = "Cooling Fan"
                        },
                        new
                        {
                            Id = new Guid("ebbc24fc-e1cb-464b-8767-547830b2a5a2"),
                            Name = "CPU Fan Cooler"
                        },
                        new
                        {
                            Id = new Guid("4a1f17cb-a857-4f4f-a764-c632748ac749"),
                            Name = "CPU AIO Cooler"
                        },
                        new
                        {
                            Id = new Guid("614b1588-2cc6-4ac6-9fdb-083894402372"),
                            Name = "PC Case"
                        },
                        new
                        {
                            Id = new Guid("4132a51f-5573-4deb-9543-2176df7f5d09"),
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = new Guid("56704da8-07f6-4713-84ec-9f2733379264"),
                            Name = "Monitor Stand"
                        },
                        new
                        {
                            Id = new Guid("1842cab3-e899-4c42-86cc-9c8eec987e44"),
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = new Guid("20e23719-2111-408d-86d9-53b90becf919"),
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = new Guid("d82299df-adab-4cda-a4de-84d036082424"),
                            Name = "Headset"
                        },
                        new
                        {
                            Id = new Guid("1e394849-354a-4102-ae75-cbdf0621bdab"),
                            Name = "Mouse Pad"
                        });
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductTypeProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductTypePropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductTypeProperty");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PrimeGearApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PrimeGearApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimeGearApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PrimeGearApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.Product", b =>
                {
                    b.HasOne("PrimeGearApp.Data.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductDetail", b =>
                {
                    b.HasOne("PrimeGearApp.Data.Models.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PrimeGearApp.Data.Models.ProductTypeProperty", "ProductTypeProperty")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductTypePropertyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductTypeProperty");
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductTypeProperty", b =>
                {
                    b.HasOne("PrimeGearApp.Data.Models.ProductType", "ProductType")
                        .WithMany("ProductProperties")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductType", b =>
                {
                    b.Navigation("ProductProperties");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductTypeProperty", b =>
                {
                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
