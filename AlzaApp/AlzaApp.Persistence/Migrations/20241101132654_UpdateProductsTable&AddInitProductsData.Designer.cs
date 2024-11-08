﻿// <auto-generated />
using System;
using AlzaApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlzaApp.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241101132654_UpdateProductsTable&AddInitProductsData")]
    partial class UpdateProductsTableAddInitProductsData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlzaApp.Persistence.DatabaseObjects.ProductDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 1, 13, 26, 54, 633, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Description of product 1",
                            ImgUri = "photoPlaceholder1.jpg",
                            Name = "Product 1",
                            Price = 100m,
                            UpdatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 1, 13, 25, 54, 633, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Description of product 2",
                            ImgUri = "photoPlaceholder2.jpg",
                            Name = "Product 2",
                            Price = 200m,
                            UpdatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 1, 13, 24, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Description of product 3",
                            ImgUri = "photoPlaceholder3.jpg",
                            Name = "Product 3",
                            Price = 300m,
                            UpdatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 1, 13, 23, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Description of product 4",
                            ImgUri = "photoPlaceholder4.jpg",
                            Name = "Product 4",
                            Price = 400m,
                            UpdatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 11, 1, 13, 22, 54, 633, DateTimeKind.Unspecified).AddTicks(6260), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Description of product 5",
                            ImgUri = "photoPlaceholder5.jpg",
                            Name = "Product 5",
                            Price = 500m,
                            UpdatedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
