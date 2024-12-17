using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedPrimayIdToUserFavoriteProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteProduct_AspNetUsers_UserId",
                table: "UserFavoriteProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteProduct_Products_ProductId",
                table: "UserFavoriteProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteProduct",
                table: "UserFavoriteProduct");

            migrationBuilder.RenameTable(
                name: "UserFavoriteProduct",
                newName: "UserFavoriteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteProduct_ProductId",
                table: "UserFavoriteProducts",
                newName: "IX_UserFavoriteProducts_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserFavoriteProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteProducts",
                table: "UserFavoriteProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteProducts_UserId",
                table: "UserFavoriteProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteProducts_AspNetUsers_UserId",
                table: "UserFavoriteProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteProducts_Products_ProductId",
                table: "UserFavoriteProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteProducts_AspNetUsers_UserId",
                table: "UserFavoriteProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteProducts_Products_ProductId",
                table: "UserFavoriteProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteProducts",
                table: "UserFavoriteProducts");

            migrationBuilder.DropIndex(
                name: "IX_UserFavoriteProducts_UserId",
                table: "UserFavoriteProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFavoriteProducts");

            migrationBuilder.RenameTable(
                name: "UserFavoriteProducts",
                newName: "UserFavoriteProduct");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteProducts_ProductId",
                table: "UserFavoriteProduct",
                newName: "IX_UserFavoriteProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteProduct",
                table: "UserFavoriteProduct",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteProduct_AspNetUsers_UserId",
                table: "UserFavoriteProduct",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteProduct_Products_ProductId",
                table: "UserFavoriteProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
