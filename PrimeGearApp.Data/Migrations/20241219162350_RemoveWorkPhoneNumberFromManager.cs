using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWorkPhoneNumberFromManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkPhoneNumber",
                table: "Managers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                comment: "Manager's work phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Manager's work phone number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkPhoneNumber",
                table: "Managers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "Manager's work phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true,
                oldComment: "Manager's work phone number");
        }
    }
}
