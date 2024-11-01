using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlzaApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SetProductsStringLimitsAddMoreInitProductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImgUri",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 14, 24, 15, 786, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 0, 0, 0, 0)), "https://photoPlaceholder1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 14, 23, 15, 786, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 0, 0, 0, 0)), "https://photoPlaceholder2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 14, 22, 15, 786, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 0, 0, 0, 0)), "https://photoPlaceholder3.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 14, 21, 15, 786, DateTimeKind.Unspecified).AddTicks(2290), new TimeSpan(0, 0, 0, 0, 0)), "https://photoPlaceholder4.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 14, 20, 15, 786, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 0, 0, 0, 0)), "https://photoPlaceholder5.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 19, 15, 786, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 6", "https://photoPlaceholder6.jpg", "Product 6", 600m },
                    { 7, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 18, 15, 786, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 7", "https://photoPlaceholder7.jpg", "Product 7", 700m },
                    { 8, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 17, 15, 786, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 8", "https://photoPlaceholder8.jpg", "Product 8", 800m },
                    { 9, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 16, 15, 786, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 9", "https://photoPlaceholder9.jpg", "Product 9", 900m },
                    { 10, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 15, 15, 786, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 10", "https://photoPlaceholder10.jpg", "Product 10", 1000m },
                    { 11, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 14, 15, 786, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 11", "https://photoPlaceholder11.jpg", "Product 11", 1100m },
                    { 12, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 13, 15, 786, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 12", "https://photoPlaceholder12.jpg", "Product 12", 1200m },
                    { 13, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 12, 15, 786, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 13", "https://photoPlaceholder13.jpg", "Product 13", 1300m },
                    { 14, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 11, 15, 786, DateTimeKind.Unspecified).AddTicks(2320), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 14", "https://photoPlaceholder14.jpg", "Product 14", 1400m },
                    { 15, new DateTimeOffset(new DateTime(2024, 11, 1, 14, 10, 15, 786, DateTimeKind.Unspecified).AddTicks(2320), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 15", "https://photoPlaceholder15.jpg", "Product 15", 1500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImgUri",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 13, 26, 54, 633, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 0, 0, 0, 0)), "photoPlaceholder1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 13, 25, 54, 633, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 0, 0, 0, 0)), "photoPlaceholder2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 13, 24, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)), "photoPlaceholder3.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 13, 23, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)), "photoPlaceholder4.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ImgUri" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 1, 13, 22, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)), "photoPlaceholder5.jpg" });
        }
    }
}
