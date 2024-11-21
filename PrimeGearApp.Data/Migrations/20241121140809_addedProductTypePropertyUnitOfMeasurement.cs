using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProductTypePropertyUnitOfMeasurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductTypePropertyUnitOfMeasurement",
                table: "ProductTypeProperties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 17,
                column: "ProductTypePropertyUnitOfMeasurement",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImagePath",
                value: "/images/GPU/GPU1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductImagePath",
                value: "/images/GPU/GPU2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTypePropertyUnitOfMeasurement",
                table: "ProductTypeProperties");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductImagePath",
                value: null);
        }
    }
}
