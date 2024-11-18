using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedProductTypePropertiesIndexSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductTypePropertyName",
                value: "CoreClockSpeed");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductTypePropertyName",
                value: "BoostClockSpeed");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductTypePropertyName",
                value: "CudaCores");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductTypePropertyName",
                value: "MemorySize");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductTypePropertyName",
                value: "MemoryType");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductTypePropertyName",
                value: "TDP");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductTypePropertyName",
                value: "RecommendedPSUWattage");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductTypePropertyName",
                value: "FanCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductTypePropertyName",
                value: "HasRGB");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductTypePropertyName",
                value: "CoolerType");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductTypePropertyName",
                value: "Length");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductTypePropertyName",
                value: "SlotWidth");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductTypePropertyName",
                value: "Weight");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductTypePropertyName",
                value: "HDMIOutputPortsCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductTypePropertyName",
                value: "DisplayPortOutputPortsCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductTypePropertyName",
                value: "DVIOutputPortsCount");

            migrationBuilder.InsertData(
                table: "ProductTypeProperties",
                columns: new[] { "Id", "ProductTypeId", "ProductTypePropertyName" },
                values: new object[] { 17, 2, "VGAOutputPortsCount" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductTypePropertyName",
                value: "BoostClockSpeed");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductTypePropertyName",
                value: "CudaCores");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductTypePropertyName",
                value: "MemorySize");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 4,
                column: "ProductTypePropertyName",
                value: "MemoryType");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 5,
                column: "ProductTypePropertyName",
                value: "TDP");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 6,
                column: "ProductTypePropertyName",
                value: "RecommendedPSUWattage");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 7,
                column: "ProductTypePropertyName",
                value: "FanCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 8,
                column: "ProductTypePropertyName",
                value: "HasRGB");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 9,
                column: "ProductTypePropertyName",
                value: "CoolerType");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 10,
                column: "ProductTypePropertyName",
                value: "Length");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 11,
                column: "ProductTypePropertyName",
                value: "SlotWidth");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 12,
                column: "ProductTypePropertyName",
                value: "Weight");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 13,
                column: "ProductTypePropertyName",
                value: "HDMIOutputPortsCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 14,
                column: "ProductTypePropertyName",
                value: "DisplayPortOutputPortsCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 15,
                column: "ProductTypePropertyName",
                value: "DVIOutputPortsCount");

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 16,
                column: "ProductTypePropertyName",
                value: "VGAOutputPortsCount");
        }
    }
}
