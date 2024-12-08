using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeUnusedPropertiesFromShoppingCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "ShoppingCartItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "ShoppingCartItem",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the current cart item selected");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "ShoppingCartItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Product Price");
        }
    }
}
