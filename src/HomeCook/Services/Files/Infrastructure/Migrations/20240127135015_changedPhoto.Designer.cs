﻿// <auto-generated />
using System;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(FilesDbContext))]
    [Migration("20240127135015_changedPhoto")]
    partial class changedPhoto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"),
                            Path = "food-photo1.jpg"
                        },
                        new
                        {
                            Id = new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"),
                            Path = "food-photo2.jpg"
                        },
                        new
                        {
                            Id = new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"),
                            Path = "food-photo3.jpg"
                        },
                        new
                        {
                            Id = new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"),
                            Path = "food-photo4.jpg"
                        },
                        new
                        {
                            Id = new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"),
                            Path = "food-photo5.jpg"
                        },
                        new
                        {
                            Id = new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"),
                            Path = "food-photo6.jpg"
                        },
                        new
                        {
                            Id = new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"),
                            Path = "food-photo7.jpg"
                        },
                        new
                        {
                            Id = new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"),
                            Path = "food-photo8.jpg"
                        },
                        new
                        {
                            Id = new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"),
                            Path = "food-photo9.jpg"
                        },
                        new
                        {
                            Id = new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"),
                            Path = "food-photo10.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
