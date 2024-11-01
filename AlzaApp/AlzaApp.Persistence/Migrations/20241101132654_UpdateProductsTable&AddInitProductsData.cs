using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlzaApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductsTableAddInitProductsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 11, 1, 13, 26, 54, 633, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 1", "photoPlaceholder1.jpg", "Product 1", 100m },
                    { 2, new DateTimeOffset(new DateTime(2024, 11, 1, 13, 25, 54, 633, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 2", "photoPlaceholder2.jpg", "Product 2", 200m },
                    { 3, new DateTimeOffset(new DateTime(2024, 11, 1, 13, 24, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 3", "photoPlaceholder3.jpg", "Product 3", 300m },
                    { 4, new DateTimeOffset(new DateTime(2024, 11, 1, 13, 23, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 4", "photoPlaceholder4.jpg", "Product 4", 400m },
                    { 5, new DateTimeOffset(new DateTime(2024, 11, 1, 13, 22, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)), "Description of product 5", "photoPlaceholder5.jpg", "Product 5", 500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");
        }
    }
}
