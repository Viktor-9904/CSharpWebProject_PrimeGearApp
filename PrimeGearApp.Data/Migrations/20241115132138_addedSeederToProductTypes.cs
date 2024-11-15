using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedSeederToProductTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03f7a756-203b-4418-84f5-2e819f3cc22d"), "Power Supply" },
                    { new Guid("057b95cf-ad90-451b-bca5-3ce2ccab69cf"), "Motherboard" },
                    { new Guid("32da00ef-aa3f-4575-ad14-bc23e14e15c0"), "CPU Fan Cooler" },
                    { new Guid("5199f126-30de-475c-904e-9ea7dc0af8f4"), "Monitor Stand" },
                    { new Guid("557c501d-2b43-41f4-bd36-ca12d96cef98"), "HDD" },
                    { new Guid("6d1f3883-e35a-4ff4-b2f2-5f6e19741adb"), "Monitor" },
                    { new Guid("73d83f5b-d12e-4e60-8686-b1d2682c5b94"), "CPU AIO Cooler" },
                    { new Guid("79f4508b-6552-4e37-a286-23ff1220bc4a"), "Mouse" },
                    { new Guid("7c270203-0ef4-48a6-8c33-0c9b1cd182f8"), "Headset" },
                    { new Guid("807e7131-fed6-4b93-a9c9-afbed7584e54"), "GPU" },
                    { new Guid("8330576e-68db-4763-97f9-b74925832251"), "SSD" },
                    { new Guid("8794d3b0-a8b5-414b-b14a-98ce0e042751"), "PC Case" },
                    { new Guid("951087fd-83b0-4799-96cf-b0d5decb1881"), "Cooling Fan" },
                    { new Guid("c2f50756-240a-4ded-b1b6-f99d737102ff"), "CPU" },
                    { new Guid("dc7be4c3-6867-410e-a49d-07bac1e50de0"), "Mouse Pad" },
                    { new Guid("e9bfc010-6cee-49c9-9099-1e119acb9e39"), "RAM" },
                    { new Guid("f0371ba8-8a67-4390-b132-8c3570015207"), "Keyboard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("03f7a756-203b-4418-84f5-2e819f3cc22d"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("057b95cf-ad90-451b-bca5-3ce2ccab69cf"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("32da00ef-aa3f-4575-ad14-bc23e14e15c0"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("5199f126-30de-475c-904e-9ea7dc0af8f4"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("557c501d-2b43-41f4-bd36-ca12d96cef98"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("6d1f3883-e35a-4ff4-b2f2-5f6e19741adb"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("73d83f5b-d12e-4e60-8686-b1d2682c5b94"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("79f4508b-6552-4e37-a286-23ff1220bc4a"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("7c270203-0ef4-48a6-8c33-0c9b1cd182f8"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("807e7131-fed6-4b93-a9c9-afbed7584e54"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8330576e-68db-4763-97f9-b74925832251"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8794d3b0-a8b5-414b-b14a-98ce0e042751"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("951087fd-83b0-4799-96cf-b0d5decb1881"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("c2f50756-240a-4ded-b1b6-f99d737102ff"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("dc7be4c3-6867-410e-a49d-07bac1e50de0"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e9bfc010-6cee-49c9-9099-1e119acb9e39"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("f0371ba8-8a67-4390-b132-8c3570015207"));
        }
    }
}
