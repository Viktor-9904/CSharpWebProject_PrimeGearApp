﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimeGearApp.Web.Data;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    [DbContext(typeof(PrimeGearDbContext))]
    [Migration("20241118175550_tempSeederForProductDetails")]
    partial class tempSeederForProductDetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

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

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvaibleQuantity = 12,
                            Brand = "Nvidia",
                            Description = "This is the newest and fastest GPU on the market!",
                            Name = "Graphics card - RTX 5090",
                            Price = 9999.9899999999998,
                            ProductTypeId = 2,
                            RelaseDate = new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WarrantyDurationInMonths = 24,
                            Weigth = 1.1000000000000001
                        },
                        new
                        {
                            Id = 2,
                            AvaibleQuantity = 3,
                            Brand = "Nvidia",
                            Description = "An older card, still very capable of running modern games on medium setting at 1080p.",
                            Name = "Graphics card - GTX 1050",
                            Price = 84.450000000000003,
                            ProductTypeId = 2,
                            RelaseDate = new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WarrantyDurationInMonths = 6,
                            Weigth = 0.5
                        });
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypePropertyId")
                        .HasColumnType("int");

                    b.Property<string>("ProductTypePropertyValue")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("ProductDetailValue");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductTypePropertyId");

                    b.ToTable("ProductDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            ProductTypePropertyId = 1,
                            ProductTypePropertyValue = "1440"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 1,
                            ProductTypePropertyId = 2,
                            ProductTypePropertyValue = "1860"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 1,
                            ProductTypePropertyId = 3,
                            ProductTypePropertyValue = "3584"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 1,
                            ProductTypePropertyId = 4,
                            ProductTypePropertyValue = "8"
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 1,
                            ProductTypePropertyId = 5,
                            ProductTypePropertyValue = "GDDR6"
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 1,
                            ProductTypePropertyId = 6,
                            ProductTypePropertyValue = "220"
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 1,
                            ProductTypePropertyId = 7,
                            ProductTypePropertyValue = "650"
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 1,
                            ProductTypePropertyId = 8,
                            ProductTypePropertyValue = "3"
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 1,
                            ProductTypePropertyId = 9,
                            ProductTypePropertyValue = "true"
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 1,
                            ProductTypePropertyId = 10,
                            ProductTypePropertyValue = "Air"
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 1,
                            ProductTypePropertyId = 11,
                            ProductTypePropertyValue = "320"
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 1,
                            ProductTypePropertyId = 12,
                            ProductTypePropertyValue = "2.5"
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 1,
                            ProductTypePropertyId = 13,
                            ProductTypePropertyValue = "1.5"
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 1,
                            ProductTypePropertyId = 14,
                            ProductTypePropertyValue = "2"
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 1,
                            ProductTypePropertyId = 15,
                            ProductTypePropertyValue = "3"
                        },
                        new
                        {
                            Id = 16,
                            ProductId = 1,
                            ProductTypePropertyId = 16,
                            ProductTypePropertyValue = "1"
                        },
                        new
                        {
                            Id = 17,
                            ProductId = 1,
                            ProductTypePropertyId = 17,
                            ProductTypePropertyValue = "0"
                        },
                        new
                        {
                            Id = 18,
                            ProductId = 2,
                            ProductTypePropertyId = 1,
                            ProductTypePropertyValue = "1455"
                        },
                        new
                        {
                            Id = 19,
                            ProductId = 2,
                            ProductTypePropertyId = 2,
                            ProductTypePropertyValue = "1620"
                        },
                        new
                        {
                            Id = 20,
                            ProductId = 2,
                            ProductTypePropertyId = 3,
                            ProductTypePropertyValue = "640"
                        },
                        new
                        {
                            Id = 21,
                            ProductId = 2,
                            ProductTypePropertyId = 4,
                            ProductTypePropertyValue = "4"
                        },
                        new
                        {
                            Id = 22,
                            ProductId = 2,
                            ProductTypePropertyId = 5,
                            ProductTypePropertyValue = "GDDR5"
                        },
                        new
                        {
                            Id = 23,
                            ProductId = 2,
                            ProductTypePropertyId = 6,
                            ProductTypePropertyValue = "75"
                        },
                        new
                        {
                            Id = 24,
                            ProductId = 2,
                            ProductTypePropertyId = 7,
                            ProductTypePropertyValue = "300"
                        },
                        new
                        {
                            Id = 25,
                            ProductId = 2,
                            ProductTypePropertyId = 8,
                            ProductTypePropertyValue = "1"
                        },
                        new
                        {
                            Id = 26,
                            ProductId = 2,
                            ProductTypePropertyId = 9,
                            ProductTypePropertyValue = "false"
                        },
                        new
                        {
                            Id = 27,
                            ProductId = 2,
                            ProductTypePropertyId = 10,
                            ProductTypePropertyValue = "Air"
                        },
                        new
                        {
                            Id = 28,
                            ProductId = 2,
                            ProductTypePropertyId = 11,
                            ProductTypePropertyValue = "145"
                        },
                        new
                        {
                            Id = 29,
                            ProductId = 2,
                            ProductTypePropertyId = 12,
                            ProductTypePropertyValue = "2"
                        },
                        new
                        {
                            Id = 30,
                            ProductId = 2,
                            ProductTypePropertyId = 13,
                            ProductTypePropertyValue = "0.4"
                        },
                        new
                        {
                            Id = 31,
                            ProductId = 2,
                            ProductTypePropertyId = 14,
                            ProductTypePropertyValue = "1"
                        },
                        new
                        {
                            Id = 32,
                            ProductId = 2,
                            ProductTypePropertyId = 15,
                            ProductTypePropertyValue = "1"
                        },
                        new
                        {
                            Id = 33,
                            ProductId = 2,
                            ProductTypePropertyId = 16,
                            ProductTypePropertyValue = "0"
                        },
                        new
                        {
                            Id = 34,
                            ProductId = 2,
                            ProductTypePropertyId = 17,
                            ProductTypePropertyValue = "0"
                        });
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("ProductType Name");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CPU"
                        },
                        new
                        {
                            Id = 2,
                            Name = "GPU"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Motherboard"
                        },
                        new
                        {
                            Id = 12,
                            Name = "RAM"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Power Supply"
                        },
                        new
                        {
                            Id = 11,
                            Name = "HDD"
                        },
                        new
                        {
                            Id = 7,
                            Name = "SSD"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Cooling Fan"
                        },
                        new
                        {
                            Id = 15,
                            Name = "CPU Fan Cooler"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CPU AIO Cooler"
                        },
                        new
                        {
                            Id = 10,
                            Name = "PC Case"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Monitor"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Monitor Stand"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Keyboard"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Mouse"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Headset"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mouse Pad"
                        });
                });

            modelBuilder.Entity("PrimeGearApp.Data.Models.ProductTypeProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ProductTypePropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductTypeProperties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "CoreClockSpeed"
                        },
                        new
                        {
                            Id = 2,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "BoostClockSpeed"
                        },
                        new
                        {
                            Id = 3,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "CudaCores"
                        },
                        new
                        {
                            Id = 4,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "MemorySize"
                        },
                        new
                        {
                            Id = 5,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "MemoryType"
                        },
                        new
                        {
                            Id = 6,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "TDP"
                        },
                        new
                        {
                            Id = 7,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "RecommendedPSUWattage"
                        },
                        new
                        {
                            Id = 8,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "FanCount"
                        },
                        new
                        {
                            Id = 9,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "HasRGB"
                        },
                        new
                        {
                            Id = 10,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "CoolerType"
                        },
                        new
                        {
                            Id = 11,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "Length"
                        },
                        new
                        {
                            Id = 12,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "SlotWidth"
                        },
                        new
                        {
                            Id = 13,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "Weight"
                        },
                        new
                        {
                            Id = 14,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "HDMIOutputPortsCount"
                        },
                        new
                        {
                            Id = 15,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "DisplayPortOutputPortsCount"
                        },
                        new
                        {
                            Id = 16,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "DVIOutputPortsCount"
                        },
                        new
                        {
                            Id = 17,
                            ProductTypeId = 2,
                            ProductTypePropertyName = "VGAOutputPortsCount"
                        });
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