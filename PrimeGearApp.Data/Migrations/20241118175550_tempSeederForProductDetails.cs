using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class tempSeederForProductDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "Id", "ProductId", "ProductTypePropertyId", "ProductTypePropertyValue" },
                values: new object[,]
                {
                    { 1, 1, 1, "1440" },
                    { 2, 1, 2, "1860" },
                    { 3, 1, 3, "3584" },
                    { 4, 1, 4, "8" },
                    { 5, 1, 5, "GDDR6" },
                    { 6, 1, 6, "220" },
                    { 7, 1, 7, "650" },
                    { 8, 1, 8, "3" },
                    { 9, 1, 9, "true" },
                    { 10, 1, 10, "Air" },
                    { 11, 1, 11, "320" },
                    { 12, 1, 12, "2.5" },
                    { 13, 1, 13, "1.5" },
                    { 14, 1, 14, "2" },
                    { 15, 1, 15, "3" },
                    { 16, 1, 16, "1" },
                    { 17, 1, 17, "0" },
                    { 18, 2, 1, "1455" },
                    { 19, 2, 2, "1620" },
                    { 20, 2, 3, "640" },
                    { 21, 2, 4, "4" },
                    { 22, 2, 5, "GDDR5" },
                    { 23, 2, 6, "75" },
                    { 24, 2, 7, "300" },
                    { 25, 2, 8, "1" },
                    { 26, 2, 9, "false" },
                    { 27, 2, 10, "Air" },
                    { 28, 2, 11, "145" },
                    { 29, 2, 12, "2" },
                    { 30, 2, 13, "0.4" },
                    { 31, 2, 14, "1" },
                    { 32, 2, 15, "1" },
                    { 33, 2, 16, "0" },
                    { 34, 2, 17, "0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
