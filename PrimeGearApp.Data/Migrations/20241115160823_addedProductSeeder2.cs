using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProductSeeder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvaibleQuantity", "Brand", "Description", "Name", "Price", "ProductTypeId", "RelaseDate", "WarrantyDurationInMonths", "Weigth" },
                values: new object[,]
                {
                    { new Guid("2af51b77-3b66-408f-a81f-99ef12fd3405"), 12, "Nvidia", "This is the newest and fastest GPU on the market!", "Graphics card - RTX 5090", 9999.9899999999998, new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"), new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1.1000000000000001 },
                    { new Guid("65dcd090-198f-4d5b-be4c-cb5e865eb859"), 3, "Nvidia", "An older card, still very capable of running modern games on medium setting at 1080p.", "Graphics card - GTX 1050", 84.450000000000003, new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"), new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "AvaibleQuantity", "Brand", "Description", "Name", "Price", "ProductTypeId", "RelaseDate", "WarrantyDurationInMonths", "Weigth" },
                values: new object[,]
                {
                    { new Guid("03826e9d-f48e-412e-a3cf-57abc5be8e5e"), 3, "Nvidia", "An older card, still very capable of running modern games on medium setting at 1080p.", "Graphics card - GTX 1050", 84.450000000000003, new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"), new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0.5 },
                    { new Guid("ac11e8e3-c4d6-4a04-9fab-b5551e29c621"), 12, "Nvidia", "This is the newest and fastest GPU on the market!", "Graphics card - RTX 5090", 9999.9899999999998, new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"), new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1.1000000000000001 }
                });
        }
    }
}
