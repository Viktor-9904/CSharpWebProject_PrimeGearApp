using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedPropertyValueTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypeProperties_PropertyType_PropertyValueTypeId",
                table: "ProductTypeProperties");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.RenameColumn(
                name: "PropertyValueTypeId",
                table: "ProductTypeProperties",
                newName: "ValueTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypeProperties_PropertyValueTypeId",
                table: "ProductTypeProperties",
                newName: "IX_ProductTypeProperties_ValueTypeId");

            migrationBuilder.CreateTable(
                name: "PropertyValueType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Value name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValueType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 1,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 3,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 4,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 5,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 6,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 7,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 8,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 9,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 10,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 11,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 12,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 13,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 14,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 15,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 16,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductTypeProperties",
                keyColumn: "Id",
                keyValue: 17,
                column: "ValueTypeId",
                value: 1);

            migrationBuilder.InsertData(
                table: "PropertyValueType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TextValue" },
                    { 2, "IntegerValue" },
                    { 3, "DecimalValue" },
                    { 4, "BooleanValue" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypeProperties_PropertyValueType_ValueTypeId",
                table: "ProductTypeProperties",
                column: "ValueTypeId",
                principalTable: "PropertyValueType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypeProperties_PropertyValueType_ValueTypeId",
                table: "ProductTypeProperties");

            migrationBuilder.DropTable(
                name: "PropertyValueType");

            migrationBuilder.RenameColumn(
                name: "ValueTypeId",
                table: "ProductTypeProperties",
                newName: "PropertyValueTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypeProperties_ValueTypeId",
                table: "ProductTypeProperties",
                newName: "IX_ProductTypeProperties_PropertyValueTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypeProperties_PropertyType_PropertyValueTypeId",
                table: "ProductTypeProperties",
                column: "PropertyValueTypeId",
                principalTable: "PropertyType",
                principalColumn: "ValueType",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
