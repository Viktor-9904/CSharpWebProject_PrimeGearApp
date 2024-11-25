using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedPropertyTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductTypePropertyUnitOfMeasurement",
                table: "ProductTypeProperties",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                comment: "Property's unit of measurement",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypePropertyName",
                table: "ProductTypeProperties",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Property Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PropertyValueTypeId",
                table: "ProductTypeProperties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    ValueType = table.Column<int>(type: "int", nullable: false, comment: "Enum with property value type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.ValueType);
                });

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 3,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 4,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 5,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 6,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 7,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 8,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 9,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 10,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 11,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 12,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 13,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 14,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 15,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 16,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 17,
                column: "PropertyValueTypeId",
                value: 0);

            migrationBuilder.InsertData(
                table: "PropertyType",
                column: "ValueType",
                values: new object[]
                {
                    0,
                    1,
                    2,
                    3
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypeProperties_PropertyValueTypeId",
                table: "ProductTypeProperties",
                column: "PropertyValueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypeProperties_PropertyType_PropertyValueTypeId",
                table: "ProductTypeProperties",
                column: "PropertyValueTypeId",
                principalTable: "PropertyType",
                principalColumn: "ValueType",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypeProperties_PropertyType_PropertyValueTypeId",
                table: "ProductTypeProperties");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypeProperties_PropertyValueTypeId",
                table: "ProductTypeProperties");

            migrationBuilder.DropColumn(
                name: "PropertyValueTypeId",
                table: "ProductTypeProperties");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypePropertyUnitOfMeasurement",
                table: "ProductTypeProperties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Property's unit of measurement");

            migrationBuilder.AlterColumn<string>(
                name: "ProductTypePropertyName",
                table: "ProductTypeProperties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Property Name");
        }
    }
}
