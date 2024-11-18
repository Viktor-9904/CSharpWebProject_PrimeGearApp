using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addProductTypeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a5f8173-10dc-492c-8b6a-d8a7d3aa82b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69847f0f-b13c-4127-9f64-46afaa808bc7"));

            migrationBuilder.InsertData(
                table: "ProductTypeProperties",
                columns: new[] { "Id", "ProductTypeId", "ProductTypePropertyName" },
                values: new object[,]
                {
                    { 1, 2, "BoostClockSpeed" },
                    { 2, 2, "CudaCores" },
                    { 3, 2, "MemorySize" },
                    { 4, 2, "MemoryType" },
                    { 5, 2, "TDP" },
                    { 6, 2, "RecommendedPSUWattage" },
                    { 7, 2, "FanCount" },
                    { 8, 2, "HasRGB" },
                    { 9, 2, "CoolerType" },
                    { 10, 2, "Length" },
                    { 11, 2, "SlotWidth" },
                    { 12, 2, "Weight" },
                    { 13, 2, "HDMIOutputPortsCount" },
                    { 14, 2, "DisplayPortOutputPortsCount" },
                    { 15, 2, "DVIOutputPortsCount" },
                    { 16, 2, "VGAOutputPortsCount" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvaibleQuantity", "Brand", "Description", "Name", "Price", "ProductTypeId", "RelaseDate", "WarrantyDurationInMonths", "Weigth" },
                values: new object[,]
                {
                    { new Guid("0152fed0-4aa7-44f8-9ba1-2a6922958600"), 12, "Nvidia", "This is the newest and fastest GPU on the market!", "Graphics card - RTX 5090", 9999.9899999999998, 2, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1.1000000000000001 },
                    { new Guid("4ebb9438-74b6-4dbd-91c6-0cbefb07b63f"), 3, "Nvidia", "An older card, still very capable of running modern games on medium setting at 1080p.", "Graphics card - GTX 1050", 84.450000000000003, 2, new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0152fed0-4aa7-44f8-9ba1-2a6922958600"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ebb9438-74b6-4dbd-91c6-0cbefb07b63f"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvaibleQuantity", "Brand", "Description", "Name", "Price", "ProductTypeId", "RelaseDate", "WarrantyDurationInMonths", "Weigth" },
                values: new object[,]
                {
                    { new Guid("1a5f8173-10dc-492c-8b6a-d8a7d3aa82b2"), 3, "Nvidia", "An older card, still very capable of running modern games on medium setting at 1080p.", "Graphics card - GTX 1050", 84.450000000000003, 2, new DateTime(2015, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0.5 },
                    { new Guid("69847f0f-b13c-4127-9f64-46afaa808bc7"), 12, "Nvidia", "This is the newest and fastest GPU on the market!", "Graphics card - RTX 5090", 9999.9899999999998, 2, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1.1000000000000001 }
                });
        }
    }
}
