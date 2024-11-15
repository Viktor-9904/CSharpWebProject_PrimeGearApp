using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrimeGearApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProductBrandProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("03f7a756-203b-4418-84f5-2e819f3cc22d"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("057b95cf-ad90-451b-bca5-3ce2ccab69cf"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("32da00ef-aa3f-4575-ad14-bc23e14e15c0"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("5199f126-30de-475c-904e-9ea7dc0af8f4"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("557c501d-2b43-41f4-bd36-ca12d96cef98"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("6d1f3883-e35a-4ff4-b2f2-5f6e19741adb"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("73d83f5b-d12e-4e60-8686-b1d2682c5b94"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("79f4508b-6552-4e37-a286-23ff1220bc4a"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("7c270203-0ef4-48a6-8c33-0c9b1cd182f8"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("807e7131-fed6-4b93-a9c9-afbed7584e54"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8330576e-68db-4763-97f9-b74925832251"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8794d3b0-a8b5-414b-b14a-98ce0e042751"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("951087fd-83b0-4799-96cf-b0d5decb1881"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("c2f50756-240a-4ded-b1b6-f99d737102ff"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("dc7be4c3-6867-410e-a49d-07bac1e50de0"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e9bfc010-6cee-49c9-9099-1e119acb9e39"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("f0371ba8-8a67-4390-b132-8c3570015207"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Product Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Product Name");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Product",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Product Brand");

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0772a540-0c2f-4b70-8ddb-2e869037f8f2"), "CPU AIO Cooler" },
                    { new Guid("085d9380-a7fe-436c-ae92-e90d740c7174"), "Power Supply" },
                    { new Guid("0e300b87-9656-4c30-b3c5-eaa5c9905360"), "CPU Fan Cooler" },
                    { new Guid("235ea290-8423-41cd-957a-b8085e9dfd60"), "PC Case" },
                    { new Guid("2f0b5740-d6d3-4301-8285-409b81768153"), "Monitor" },
                    { new Guid("32aacff9-66e4-482a-9a05-758e9c78adf7"), "Mouse Pad" },
                    { new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"), "GPU" },
                    { new Guid("615d6b00-ecbd-4136-ae48-c9addf27beab"), "RAM" },
                    { new Guid("6aa4abfe-1de3-4748-a00f-3c6fcf6376cb"), "Headset" },
                    { new Guid("6b8d9cd4-6b64-4435-aba9-bb165a763fd7"), "HDD" },
                    { new Guid("8d6e8323-d16d-44cd-9ab1-ef64eb5ab366"), "Motherboard" },
                    { new Guid("bb3e6ff8-7ba6-48ca-82a1-8ad0c80bb3b2"), "SSD" },
                    { new Guid("c3465b98-cf93-4619-b1f4-ce359f3e4710"), "Keyboard" },
                    { new Guid("dc66b28c-5967-47c3-8e8f-b47ed02ca687"), "Mouse" },
                    { new Guid("e288a732-6804-401c-a0cf-aacb4c6f2298"), "Monitor Stand" },
                    { new Guid("e5fe5a16-c615-4738-bc08-15102bba2c7f"), "CPU" },
                    { new Guid("f70a0a64-12d3-4590-91f4-f736c5b5f4a9"), "Cooling Fan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("0772a540-0c2f-4b70-8ddb-2e869037f8f2"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("085d9380-a7fe-436c-ae92-e90d740c7174"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("0e300b87-9656-4c30-b3c5-eaa5c9905360"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("235ea290-8423-41cd-957a-b8085e9dfd60"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("2f0b5740-d6d3-4301-8285-409b81768153"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("32aacff9-66e4-482a-9a05-758e9c78adf7"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("5fd048ea-ea0d-4d23-b505-4f2321485398"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("615d6b00-ecbd-4136-ae48-c9addf27beab"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("6aa4abfe-1de3-4748-a00f-3c6fcf6376cb"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("6b8d9cd4-6b64-4435-aba9-bb165a763fd7"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("8d6e8323-d16d-44cd-9ab1-ef64eb5ab366"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("bb3e6ff8-7ba6-48ca-82a1-8ad0c80bb3b2"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("c3465b98-cf93-4619-b1f4-ce359f3e4710"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("dc66b28c-5967-47c3-8e8f-b47ed02ca687"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e288a732-6804-401c-a0cf-aacb4c6f2298"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("e5fe5a16-c615-4738-bc08-15102bba2c7f"));

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: new Guid("f70a0a64-12d3-4590-91f4-f736c5b5f4a9"));

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Product Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Product Name");

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03f7a756-203b-4418-84f5-2e819f3cc22d"), "Power Supply" },
                    { new Guid("057b95cf-ad90-451b-bca5-3ce2ccab69cf"), "Motherboard" },
                    { new Guid("32da00ef-aa3f-4575-ad14-bc23e14e15c0"), "CPU Fan Cooler" },
                    { new Guid("5199f126-30de-475c-904e-9ea7dc0af8f4"), "Monitor Stand" },
                    { new Guid("557c501d-2b43-41f4-bd36-ca12d96cef98"), "HDD" },
                    { new Guid("6d1f3883-e35a-4ff4-b2f2-5f6e19741adb"), "Monitor" },
                    { new Guid("73d83f5b-d12e-4e60-8686-b1d2682c5b94"), "CPU AIO Cooler" },
                    { new Guid("79f4508b-6552-4e37-a286-23ff1220bc4a"), "Mouse" },
                    { new Guid("7c270203-0ef4-48a6-8c33-0c9b1cd182f8"), "Headset" },
                    { new Guid("807e7131-fed6-4b93-a9c9-afbed7584e54"), "GPU" },
                    { new Guid("8330576e-68db-4763-97f9-b74925832251"), "SSD" },
                    { new Guid("8794d3b0-a8b5-414b-b14a-98ce0e042751"), "PC Case" },
                    { new Guid("951087fd-83b0-4799-96cf-b0d5decb1881"), "Cooling Fan" },
                    { new Guid("c2f50756-240a-4ded-b1b6-f99d737102ff"), "CPU" },
                    { new Guid("dc7be4c3-6867-410e-a49d-07bac1e50de0"), "Mouse Pad" },
                    { new Guid("e9bfc010-6cee-49c9-9099-1e119acb9e39"), "RAM" },
                    { new Guid("f0371ba8-8a67-4390-b132-8c3570015207"), "Keyboard" }
                });
        }
    }
}
