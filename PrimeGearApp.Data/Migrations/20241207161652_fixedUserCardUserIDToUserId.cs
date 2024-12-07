using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixedUserCardUserIDToUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserID",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ShoppingCart",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_UserID",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCart",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers_UserID",
                table: "ShoppingCart",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
