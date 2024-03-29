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
    [DbContext(typeof(RecipeDbContext))]
    [Migration("20231216123817_seedingFiles")]
    partial class seedingFiles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MainPhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b6eb4feb-41d2-40ea-95d3-2b5b2d03a379"),
                            AuthorEmail = "author1@example.com",
                            Content = "Content 1",
                            MainPhotoId = new Guid("13d9b14d-b06f-4a50-90c5-71435bdbe75e"),
                            Title = "Recipe 1"
                        },
                        new
                        {
                            Id = new Guid("bf1252a3-d6a7-4355-bb1d-cf04307cb274"),
                            AuthorEmail = "author1@example.com",
                            Content = "Content 2",
                            MainPhotoId = new Guid("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"),
                            Title = "Recipe 2"
                        },
                        new
                        {
                            Id = new Guid("d518e1a1-d0e3-459e-8f75-2e77a2055446"),
                            AuthorEmail = "author2@example.com",
                            Content = "Content 3",
                            MainPhotoId = new Guid("a1b2c3d4-e5f6-4768-abcd-1234567890ab"),
                            Title = "Recipe 3"
                        },
                        new
                        {
                            Id = new Guid("3aa73c46-3907-4be8-a837-e4617a9d3138"),
                            AuthorEmail = "author2@example.com",
                            Content = "Content 4",
                            MainPhotoId = new Guid("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"),
                            Title = "Recipe 4"
                        },
                        new
                        {
                            Id = new Guid("9ab3d8d3-fb07-4c70-9c9a-3aaa7697c139"),
                            AuthorEmail = "author3@example.com",
                            Content = "Content 5",
                            MainPhotoId = new Guid("b2c3d4e5-f6a7-5899-abcd-1234567890bc"),
                            Title = "Recipe 5"
                        },
                        new
                        {
                            Id = new Guid("686be816-80f2-4298-8abe-80679f366b48"),
                            AuthorEmail = "author3@example.com",
                            Content = "Content 6",
                            MainPhotoId = new Guid("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"),
                            Title = "Recipe 6"
                        },
                        new
                        {
                            Id = new Guid("f589a9b6-3470-4f4d-8c2e-ea3e1f2b40fc"),
                            AuthorEmail = "author4@example.com",
                            Content = "Content 7",
                            MainPhotoId = new Guid("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"),
                            Title = "Recipe 7"
                        },
                        new
                        {
                            Id = new Guid("75e94b5e-0ab0-424b-8ac3-47e6b8c58632"),
                            AuthorEmail = "author4@example.com",
                            Content = "Content 8",
                            MainPhotoId = new Guid("d4e5f6a7-b8c9-7bac-abcd-1234567890de"),
                            Title = "Recipe 8"
                        },
                        new
                        {
                            Id = new Guid("50616e81-d7bc-452c-a37c-9dd03490c94d"),
                            AuthorEmail = "author5@example.com",
                            Content = "Content 9",
                            MainPhotoId = new Guid("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"),
                            Title = "Recipe 9"
                        },
                        new
                        {
                            Id = new Guid("6fbaeba0-85ad-4f6a-b84d-cf13f2df3e46"),
                            AuthorEmail = "author5@example.com",
                            Content = "Content 10",
                            MainPhotoId = new Guid("f6a7b8c9-daeb-9dce-abcd-1234567890f1"),
                            Title = "Recipe 10"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
