using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedPurchasedQuantityToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchasedQuantity",
                table: "Order",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0,
                comment: "Order product quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasedQuantity",
                table: "Order");
        }
    }
}
